Imports AAS203.Common
Imports AAS203Library.Method
Public Class frmStatus
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal intTurrNo As Integer, Optional ByVal intEleID As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ElementID = intEleID
        TurretNumber = intTurrNo
    End Sub

    Public Sub New(ByVal intTurrNo As Integer, ByVal strEleName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        TurretNumber = intTurrNo
        ElementName = strEleName
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
    Friend WithEvents lblElementName As System.Windows.Forms.Label
    Friend WithEvents lblTurretNo As System.Windows.Forms.Label
    Friend WithEvents pbFlame As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStatus))
        Me.lblElementName = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTurretNo = New System.Windows.Forms.Label
        Me.pbFlame = New System.Windows.Forms.Label
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.SuspendLayout()
        '
        'lblElementName
        '
        Me.lblElementName.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lblElementName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblElementName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElementName.ForeColor = System.Drawing.Color.White
        Me.lblElementName.ImageList = Me.ImageList1
        Me.lblElementName.Location = New System.Drawing.Point(6, 4)
        Me.lblElementName.Name = "lblElementName"
        Me.lblElementName.Size = New System.Drawing.Size(32, 32)
        Me.lblElementName.TabIndex = 0
        Me.lblElementName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblTurretNo
        '
        Me.lblTurretNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTurretNo.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lblTurretNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTurretNo.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurretNo.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.lblTurretNo.Location = New System.Drawing.Point(47, 4)
        Me.lblTurretNo.Name = "lblTurretNo"
        Me.lblTurretNo.Size = New System.Drawing.Size(32, 32)
        Me.lblTurretNo.TabIndex = 1
        Me.lblTurretNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbFlame
        '
        Me.pbFlame.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.pbFlame.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.pbFlame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbFlame.Location = New System.Drawing.Point(87, 4)
        Me.pbFlame.Name = "pbFlame"
        Me.pbFlame.Size = New System.Drawing.Size(32, 32)
        Me.pbFlame.TabIndex = 2
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(53, 96)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(22, 17)
        Me.btnIgnite.TabIndex = 13
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(80, 56)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(38, 18)
        Me.btnExtinguish.TabIndex = 14
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(112, 24)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(5, 5)
        Me.btnN2OIgnite.TabIndex = 19
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Gainsboro
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(140, 61)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.Color.Gainsboro
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(152, 61)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 23
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'frmStatus
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(128, 40)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnR)
        Me.Controls.Add(Me.btnExtinguish)
        Me.Controls.Add(Me.btnIgnite)
        Me.Controls.Add(Me.pbFlame)
        Me.Controls.Add(Me.lblTurretNo)
        Me.Controls.Add(Me.lblElementName)
        Me.Controls.Add(Me.btnN2OIgnite)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(590, 20)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStatus"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Constants"
    Private Const Const_Multi = "Multi"
    Private Const Const_CaMg = "Ca-Mg"
    Private Const Const_NaK = "Na-K"
    Private Const Const_CuZn = "Cu-Zn"
#End Region

#Region " Private Variables "

    Private mintTurretNumber As Integer
    Private mintElementID As Integer
    Private mstrEleName As String
    Private mintFlameType As ClsAAS203.enumIgniteType
    Private mblnIsHydrideMode As Boolean
    Private mRect As Rectangle = Screen.GetWorkingArea(New frmAASInitialisation)
    Private mblnAvoidProcessing As Boolean = False
#End Region

#Region " Public Properties "

    Public Property TurretNumber() As Integer
        Get
            Return mintTurretNumber
        End Get
        Set(ByVal Value As Integer)
            Try
                mintTurretNumber = Value
                Select Case TurretNumber
                    Case 1
                        lblTurretNo.Image = Image.FromFile(Application.StartupPath & "\" & "images\turret_po_1.ico")
                    Case 2
                        lblTurretNo.Image = Image.FromFile(Application.StartupPath & "\" & "images\turret_po_2.ico")
                    Case 3
                        lblTurretNo.Image = Image.FromFile(Application.StartupPath & "\" & "images\turret_po_3.ico")
                    Case 4
                        lblTurretNo.Image = Image.FromFile(Application.StartupPath & "\" & "images\turret_po_4.ico")
                    Case 5
                        lblTurretNo.Image = Image.FromFile(Application.StartupPath & "\" & "images\turret_po_5.ico")
                    Case 6
                        lblTurretNo.Image = Image.FromFile(Application.StartupPath & "\" & "images\turret_po_6.ico")
                End Select

                'lblTurretNo.Text = TurretNumber
                lblTurretNo.Refresh()

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

    Public Property ElementName() As String
        Get
            Return mstrEleName
        End Get
        Set(ByVal Value As String)
            mstrEleName = Value
            'Saurabh 09.08.07
            If ElementName = Const_Multi Then
                ElementName = "Cr-Co-Cu-Fe-Mn-Ni"
                Me.Left = mRect.Width - 278
                Me.Size = New Size(258, 42)
                lblElementName.Size = New Size(162, 32)
            ElseIf ElementName = Const_CaMg Or ElementName = Const_NaK Or ElementName = Const_CuZn Then
                Me.Left = mRect.Width - 178
                Me.Size = New Size(158, 42)
                lblElementName.Size = New Size(62, 32)
            Else
                Me.Left = mRect.Width - 150
                Me.Size = New Size(130, 42)
                lblElementName.Size = New Size(32, 32)
            End If
            'Saurabh 09.08.07
            lblElementName.Text = ElementName
            lblElementName.Refresh()
        End Set
    End Property

    Public Property ElementID() As Integer
        Get
            Return mintElementID
        End Get
        Set(ByVal Value As Integer)
            Try
                mintElementID = Value
                Call funcFindEleName()

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

    Public Property FlameType() As ClsAAS203.enumIgniteType
        Get
            Return mintFlameType
        End Get
        Set(ByVal Value As ClsAAS203.enumIgniteType)
            mintFlameType = Value

            Dim objImage As Image

            'Application.DoEvents()
            If mblnIsHydrideMode Then
                objImage = Image.FromFile(Application.StartupPath & "\Images\Hydride_Mode.ico")
            Else
                Select Case mintFlameType
                    Case ClsAAS203.enumIgniteType.Blue
                        objImage = Image.FromFile(Application.StartupPath & "\Images\BLUEF.bmp")
                    Case ClsAAS203.enumIgniteType.Yellow
                        objImage = Image.FromFile(Application.StartupPath & "\Images\YELLOWF.bmp")
                    Case ClsAAS203.enumIgniteType.Red
                        objImage = Image.FromFile(Application.StartupPath & "\Images\REDF.bmp")
                    Case ClsAAS203.enumIgniteType.Green
                        objImage = Image.FromFile(Application.StartupPath & "\Images\GREENF.bmp")
                End Select
            End If

            Dim objBitmap As New System.Drawing.Bitmap(objImage)
            pbFlame.Image = objBitmap
            pbFlame.Refresh()
            Application.DoEvents()
        End Set
    End Property

    Public Property IsHydrideMode() As Boolean
        Get
            Return mblnIsHydrideMode
        End Get
        Set(ByVal Value As Boolean)
            mblnIsHydrideMode = Value
        End Set
    End Property

#End Region

#Region " Form Events "

    Private Sub frmStatus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmStatus_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak & Saurabh
        ' Created               : 05.11.06
        ' Revisions             : praveen
        '=====================================================================
        Dim strElementName As String
        Dim objDtElements As New DataTable
        ''this is a object for data structure.
        Dim objWait As New CWaitCursor
        Try
            '---to add handlers
            Me.Top = 20
            Me.Left = mRect.Width - 150
            AddHandler btnIgnite.Click, AddressOf btnIgnite_Click
            ''for eg if we click on ignite button then btnIgnite_Click will called.
            AddHandler btnExtinguish.Click, AddressOf btnExtinguish_Click
            AddHandler btnN2OIgnite.Click, AddressOf btnN2OIgnite_Click
            AddHandler btnDelete.Click, AddressOf btnDelete_Click
            AddHandler btnR.Click, AddressOf btnR_Click
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
                ''Destructure

            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Function funcFindEleName() As Boolean
        '=====================================================================
        ' Procedure Name        : funcFindEleName
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To find the element Name.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak & Saurabh & Sachin Dokhale
        ' Created               : 05.11.06
        ' Revisions             : praveen
        '=====================================================================
        Dim strElementName As String
        Dim objDtElements As New DataTable

        Try
            '---to get element name of selected element id
            If Not ElementID = 0 Then
                objDtElements = gobjDataAccess.GetCookBookData(mintElementID)
                If Not objDtElements Is Nothing Then
                    If objDtElements.Rows.Count > 0 Then
                        strElementName = objDtElements.Rows(0).Item(ConstColumnElementName)
                    End If
                End If
                ElementName = strElementName
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

    Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnIgnite_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To auto ignite the flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 05.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user clicked on ignite button
        ''this will call a auto ignition event.
        If mblnAvoidProcessing = True Then
            ''check a flag for avoiding a process.
            Exit Sub
        End If

        Try
            '---for auto ignition

            If Not IsNothing(gobjMain) Then
                mblnAvoidProcessing = True
                gobjMain.AutoIgnition()
                mblnAvoidProcessing = False
                ''function for auto ignition.)
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnIgnite_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To extinguish the flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 05.11.06
        ' Revisions             : praveen
        '=====================================================================
        If mblnAvoidProcessing = True Then
            Exit Sub
        End If
        Try
            '---to extinguish flame

            If Not IsNothing(gobjMain) Then
                mblnAvoidProcessing = True
                gobjMain.Extinguish()
                ''function for Extinguish
                mblnAvoidProcessing = False
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try

    End Sub

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnN2OIgnite_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To auto ignite N2O flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh
        ' Created               : 05.11.06
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called when user clicked on N2O ignite button
        Try
            '---for auto ignition of N2O flame
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call gobjMain.N2OAutoIgnition()
            ''for N2O ignition.
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnDelete_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call gobjMain.funcAltDelete()
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnR_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call gobjMain.funcAltR()
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


End Class
