Public Class frmPeakPicks
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
    Friend WithEvents CustomPanelPeakPick As GradientPanel.CustomPanel
    Friend WithEvents dgPeakPick As System.Windows.Forms.DataGrid
    Friend WithEvents CustomPanelPeak_Ref As GradientPanel.CustomPanel
    Friend WithEvents dgPeakPick_Ref As System.Windows.Forms.DataGrid
    Friend WithEvents CustomPanelButtons As GradientPanel.CustomPanel
    Friend WithEvents btnClose As NETXP.Controls.XPButton
    Friend WithEvents btnPrintWithSpectrum As NETXP.Controls.XPButton
    Friend WithEvents btnPrintWOSpectrum As NETXP.Controls.XPButton
    Friend WithEvents lblSampleBeam As System.Windows.Forms.Label
    Friend WithEvents lblRefBeam As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPeakPicks))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.CustomPanelButtons = New GradientPanel.CustomPanel
        Me.btnClose = New NETXP.Controls.XPButton
        Me.btnPrintWithSpectrum = New NETXP.Controls.XPButton
        Me.btnPrintWOSpectrum = New NETXP.Controls.XPButton
        Me.CustomPanelPeak_Ref = New GradientPanel.CustomPanel
        Me.lblRefBeam = New System.Windows.Forms.Label
        Me.dgPeakPick_Ref = New System.Windows.Forms.DataGrid
        Me.CustomPanelPeakPick = New GradientPanel.CustomPanel
        Me.lblSampleBeam = New System.Windows.Forms.Label
        Me.dgPeakPick = New System.Windows.Forms.DataGrid
        Me.CustomPanel1.SuspendLayout()
        Me.CustomPanelButtons.SuspendLayout()
        Me.CustomPanelPeak_Ref.SuspendLayout()
        CType(Me.dgPeakPick_Ref, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomPanelPeakPick.SuspendLayout()
        CType(Me.dgPeakPick, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.CustomPanelButtons)
        Me.CustomPanel1.Controls.Add(Me.CustomPanelPeak_Ref)
        Me.CustomPanel1.Controls.Add(Me.CustomPanelPeakPick)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(648, 383)
        Me.CustomPanel1.TabIndex = 0
        '
        'CustomPanelButtons
        '
        Me.CustomPanelButtons.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelButtons.Controls.Add(Me.btnClose)
        Me.CustomPanelButtons.Controls.Add(Me.btnPrintWithSpectrum)
        Me.CustomPanelButtons.Controls.Add(Me.btnPrintWOSpectrum)
        Me.CustomPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CustomPanelButtons.Location = New System.Drawing.Point(0, 319)
        Me.CustomPanelButtons.Name = "CustomPanelButtons"
        Me.CustomPanelButtons.Size = New System.Drawing.Size(648, 64)
        Me.CustomPanelButtons.TabIndex = 7
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.No
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(421, 15)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 38)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "&Close"
        '
        'btnPrintWithSpectrum
        '
        Me.btnPrintWithSpectrum.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnPrintWithSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintWithSpectrum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintWithSpectrum.Image = CType(resources.GetObject("btnPrintWithSpectrum.Image"), System.Drawing.Image)
        Me.btnPrintWithSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintWithSpectrum.Location = New System.Drawing.Point(245, 15)
        Me.btnPrintWithSpectrum.Name = "btnPrintWithSpectrum"
        Me.btnPrintWithSpectrum.Size = New System.Drawing.Size(110, 38)
        Me.btnPrintWithSpectrum.TabIndex = 5
        Me.btnPrintWithSpectrum.Text = "&Print"
        '
        'btnPrintWOSpectrum
        '
        Me.btnPrintWOSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintWOSpectrum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintWOSpectrum.Image = CType(resources.GetObject("btnPrintWOSpectrum.Image"), System.Drawing.Image)
        Me.btnPrintWOSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintWOSpectrum.Location = New System.Drawing.Point(85, 15)
        Me.btnPrintWOSpectrum.Name = "btnPrintWOSpectrum"
        Me.btnPrintWOSpectrum.Size = New System.Drawing.Size(110, 38)
        Me.btnPrintWOSpectrum.TabIndex = 4
        Me.btnPrintWOSpectrum.Text = "Print W/&O Spectrum"
        Me.btnPrintWOSpectrum.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPrintWOSpectrum.Visible = False
        '
        'CustomPanelPeak_Ref
        '
        Me.CustomPanelPeak_Ref.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelPeak_Ref.Controls.Add(Me.lblRefBeam)
        Me.CustomPanelPeak_Ref.Controls.Add(Me.dgPeakPick_Ref)
        Me.CustomPanelPeak_Ref.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelPeak_Ref.Location = New System.Drawing.Point(0, 152)
        Me.CustomPanelPeak_Ref.Name = "CustomPanelPeak_Ref"
        Me.CustomPanelPeak_Ref.Size = New System.Drawing.Size(648, 231)
        Me.CustomPanelPeak_Ref.TabIndex = 6
        '
        'lblRefBeam
        '
        Me.lblRefBeam.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefBeam.Location = New System.Drawing.Point(16, 5)
        Me.lblRefBeam.Name = "lblRefBeam"
        Me.lblRefBeam.Size = New System.Drawing.Size(128, 24)
        Me.lblRefBeam.TabIndex = 6
        Me.lblRefBeam.Text = "Reference Beam"
        '
        'dgPeakPick_Ref
        '
        Me.dgPeakPick_Ref.DataMember = ""
        Me.dgPeakPick_Ref.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgPeakPick_Ref.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPeakPick_Ref.Location = New System.Drawing.Point(16, 34)
        Me.dgPeakPick_Ref.Name = "dgPeakPick_Ref"
        Me.dgPeakPick_Ref.Size = New System.Drawing.Size(616, 112)
        Me.dgPeakPick_Ref.TabIndex = 5
        '
        'CustomPanelPeakPick
        '
        Me.CustomPanelPeakPick.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelPeakPick.Controls.Add(Me.lblSampleBeam)
        Me.CustomPanelPeakPick.Controls.Add(Me.dgPeakPick)
        Me.CustomPanelPeakPick.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomPanelPeakPick.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelPeakPick.Name = "CustomPanelPeakPick"
        Me.CustomPanelPeakPick.Size = New System.Drawing.Size(648, 152)
        Me.CustomPanelPeakPick.TabIndex = 5
        '
        'lblSampleBeam
        '
        Me.lblSampleBeam.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSampleBeam.Location = New System.Drawing.Point(16, 3)
        Me.lblSampleBeam.Name = "lblSampleBeam"
        Me.lblSampleBeam.Size = New System.Drawing.Size(128, 24)
        Me.lblSampleBeam.TabIndex = 2
        Me.lblSampleBeam.Text = "Sample Beam"
        '
        'dgPeakPick
        '
        Me.dgPeakPick.DataMember = ""
        Me.dgPeakPick.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgPeakPick.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPeakPick.Location = New System.Drawing.Point(16, 29)
        Me.dgPeakPick.Name = "dgPeakPick"
        Me.dgPeakPick.Size = New System.Drawing.Size(616, 112)
        Me.dgPeakPick.TabIndex = 1
        '
        'frmPeakPicks
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(648, 383)
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPeakPicks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Peak Picks"
        Me.CustomPanel1.ResumeLayout(False)
        Me.CustomPanelButtons.ResumeLayout(False)
        Me.CustomPanelPeak_Ref.ResumeLayout(False)
        CType(Me.dgPeakPick_Ref, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomPanelPeakPick.ResumeLayout(False)
        CType(Me.dgPeakPick, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Class Variables "

    Private mobjDataGridClass As DataGridClass

#End Region

#Region " Public functions "

    Public Function funcDisplayPicPeakResults(ByVal objInDataTable As DataTable) As Boolean
        '=====================================================================
        ' Procedure Name        : funcDisplayPicPeakResults
        ' Parameters Passed     : datatable
        ' Returns               : boolean
        ' Purpose               : To display pick peak result for sample beam
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin D.
        ' Created               : 
        ' Revisions             :
        '=====================================================================
        Dim intColumnCount As Integer
        Dim strColumnName As String

        Try
            '---display pick peak result in datagrid
            If Not objInDataTable Is Nothing Then
                '---Added By Mangesh on 02-Apr-2007
                mobjDataGridClass = New DataGridClass(ConstDataGridPropertiesFileName)
                mobjDataGridClass.AllowNew = False
                mobjDataGridClass.AdjustColumnWidthToGrid = True
                For intColumnCount = 0 To objInDataTable.Columns.Count - 1
                    strColumnName = objInDataTable.Columns.Item(intColumnCount).ColumnName
                    Call mobjDataGridClass.AddDataGridColumnStyle(strColumnName, dgPeakPick, objInDataTable.DefaultView, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, strColumnName, True)
                Next
                Call mobjDataGridClass.SetDataGridProperties(dgPeakPick, objInDataTable.DefaultView)
                '---Added By Mangesh on 02-Apr-2007
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Public Function funcDisplayPicPeakResults_Ref(ByVal objInDataTable As DataTable) As Boolean
        '=====================================================================
        ' Procedure Name        : funcDisplayPicPeakResults_Ref
        ' Parameters Passed     : datatable
        ' Returns               : boolean
        ' Purpose               : To display pick peak result for reference beam
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin D.
        ' Created               : 
        ' Revisions             :
        '=====================================================================
        Dim intColumnCount As Integer
        Dim strColumnName As String

        Try
            '---display pick peak result in datagrid
            If Not objInDataTable Is Nothing Then
                '---Added By Mangesh on 02-Apr-2007
                mobjDataGridClass = New DataGridClass(ConstDataGridPropertiesFileName)
                mobjDataGridClass.AllowNew = False
                mobjDataGridClass.AdjustColumnWidthToGrid = True
                For intColumnCount = 0 To objInDataTable.Columns.Count - 1
                    strColumnName = objInDataTable.Columns.Item(intColumnCount).ColumnName
                    Call mobjDataGridClass.AddDataGridColumnStyle(strColumnName, dgPeakPick_Ref, objInDataTable.DefaultView, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, strColumnName, True)
                Next
                Call mobjDataGridClass.SetDataGridProperties(dgPeakPick_Ref, objInDataTable.DefaultView)
                '---Added By Mangesh on 02-Apr-2007
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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

    Private Sub frmPeakPicks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmPeakPicks_Load
        ' Parameters Passed     : object,eventargs
        ' Returns               : None
        ' Purpose               : To initialize pick peak form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin D.
        ' Created               : 
        ' Revisions             :
        '=====================================================================
        Try
            'validate instrument type & update data structure of custom panel peak ref.
            If gintInstrumentBeamType = AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam Then
                lblSampleBeam.Visible = False
                lblRefBeam.Visible = False
                Me.Height -= CustomPanelPeak_Ref.Height - CustomPanelButtons.Height

                CustomPanelPeak_Ref.SendToBack()
                CustomPanelPeak_Ref.Dock = DockStyle.None
                CustomPanelPeak_Ref.Visible = False


                CustomPanelButtons.BringToFront()
                CustomPanelButtons.Dock = DockStyle.Top + DockStyle.Left
                CustomPanelButtons.Anchor = AnchorStyles.Top + AnchorStyles.Left
                CustomPanelButtons.Refresh()

            Else
                lblSampleBeam.Visible = False
                lblRefBeam.Visible = False
                Me.Height -= CustomPanelPeak_Ref.Height - CustomPanelButtons.Height

                CustomPanelPeak_Ref.SendToBack()
                CustomPanelPeak_Ref.Dock = DockStyle.None
                CustomPanelPeak_Ref.Visible = False

                CustomPanelButtons.BringToFront()
                CustomPanelButtons.Dock = DockStyle.Top + DockStyle.Left
                CustomPanelButtons.Anchor = AnchorStyles.Top + AnchorStyles.Left
                CustomPanelButtons.Refresh()
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
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
