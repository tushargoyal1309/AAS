Public Class frmAutoSampPosn
    Inherits System.Windows.Forms.Form
    'Dim mobjDataTable As New DataTable("AutoSamplerPosition")
    'Dim mobjGridTableStyle As New DataGridTableStyle
    'Dim mdataView As New DataView
    Dim mobjDataTable As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef objDataTable As DataTable)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        mobjDataTable = objDataTable
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
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTimings As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dgSamplerPosition As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAutoSampPosn))
        Me.lblInfo = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnHome = New System.Windows.Forms.Button
        Me.btnTimings = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.dgSamplerPosition = New System.Windows.Forms.DataGrid
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgSamplerPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblInfo
        '
        Me.lblInfo.Image = CType(resources.GetObject("lblInfo.Image"), System.Drawing.Image)
        Me.lblInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInfo.Location = New System.Drawing.Point(8, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(280, 24)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "Note : Enter position between 2 and 65 only "
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnHome)
        Me.GroupBox2.Controls.Add(Me.btnTimings)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 328)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 72)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btnHome
        '
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnHome.Location = New System.Drawing.Point(144, 24)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(112, 32)
        Me.btnHome.TabIndex = 2
        Me.btnHome.Text = "&Home"
        '
        'btnTimings
        '
        Me.btnTimings.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTimings.Location = New System.Drawing.Point(16, 24)
        Me.btnTimings.Name = "btnTimings"
        Me.btnTimings.Size = New System.Drawing.Size(112, 32)
        Me.btnTimings.TabIndex = 1
        Me.btnTimings.Text = "&Change Timings"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(120, 408)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 24)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "&Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(200, 408)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgSamplerPosition
        '
        Me.dgSamplerPosition.AlternatingBackColor = System.Drawing.Color.AliceBlue
        Me.dgSamplerPosition.BackColor = System.Drawing.Color.AliceBlue
        Me.dgSamplerPosition.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgSamplerPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgSamplerPosition.CaptionBackColor = System.Drawing.Color.AliceBlue
        Me.dgSamplerPosition.CaptionForeColor = System.Drawing.Color.FloralWhite
        Me.dgSamplerPosition.CaptionVisible = False
        Me.dgSamplerPosition.DataMember = ""
        Me.dgSamplerPosition.HeaderBackColor = System.Drawing.Color.FloralWhite
        Me.dgSamplerPosition.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSamplerPosition.LinkColor = System.Drawing.Color.FloralWhite
        Me.dgSamplerPosition.Location = New System.Drawing.Point(24, 32)
        Me.dgSamplerPosition.Name = "dgSamplerPosition"
        Me.dgSamplerPosition.ParentRowsBackColor = System.Drawing.Color.FloralWhite
        Me.dgSamplerPosition.PreferredColumnWidth = 100
        Me.dgSamplerPosition.RowHeadersVisible = False
        Me.dgSamplerPosition.SelectionBackColor = System.Drawing.Color.FloralWhite
        Me.dgSamplerPosition.Size = New System.Drawing.Size(227, 280)
        Me.dgSamplerPosition.TabIndex = 5
        '
        'frmAutoSampPosn
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(274, 439)
        Me.Controls.Add(Me.dgSamplerPosition)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblInfo)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutoSampPosn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auto Sampler Positions"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgSamplerPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        If gobjCommProtocol.funcAutoSamplerHome() Then
            gstructAutoSampler.blnHome = True
            gstructAutoSampler.blnCommunication = True
            gstructAutoSampler.intCoordinateX = 0
            gstructAutoSampler.intCoordinateY = 0
        End If
    End Sub

    Private Sub btnTimings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimings.Click
        Dim objfrmTimings As New frmTimings
        objfrmTimings.ShowDialog()
        objfrmTimings.Dispose()
    End Sub


    'Public Function funcFormatDataGrid()
    '    Dim objTextColumn As DataGridTextBoxColumn

    '    dgSamplerPosition.TableStyles.Clear()
    '    mdataView.Table = mobjDataTable
    '    mdataView.AllowNew = False

    '    dgSamplerPosition.DataSource = mdataView
    '    dgSamplerPosition.ReadOnly = False

    '    mobjGridTableStyle.RowHeadersVisible = False
    '    mobjGridTableStyle.BackColor = Color.FloralWhite
    '    mobjGridTableStyle.GridLineColor = Color.SandyBrown
    '    mobjGridTableStyle.HeaderBackColor = Color.FloralWhite
    '    mobjGridTableStyle.HeaderForeColor = Color.Black
    '    mobjGridTableStyle.AlternatingBackColor = Color.FloralWhite
    '    mobjGridTableStyle.AllowSorting = False
    '    mobjGridTableStyle.MappingName = "AutoSamplerPosition"

    '    objTextColumn = New DataGridTextBoxColumn
    '    objTextColumn.MappingName = "SampleID"
    '    objTextColumn.HeaderText = "SampleID"
    '    objTextColumn.Width = 90
    '    objTextColumn.ReadOnly = True
    '    objTextColumn.NullText = " "
    '    mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

    '    objTextColumn = New DataGridTextBoxColumn
    '    objTextColumn.MappingName = "SamplerPosition"
    '    objTextColumn.HeaderText = "Sampler Position"
    '    objTextColumn.Width = 105
    '    objTextColumn.ReadOnly = False
    '    objTextColumn.NullText = " "
    '    mobjGridTableStyle.GridColumnStyles.Add(objTextColumn)

    '    mobjGridTableStyle.GridLineColor = Color.Black
    '    dgSamplerPosition.TableStyles.Add(mobjGridTableStyle)
    'End Function

    Private Sub funcFormInitialise()
        ' funcCreateDataTable()
        'subFormatDataGrid()
    End Sub

    'Public Function funcCreateDataTable(ByRef structAutoSamplerPosn As structAutoSamplerPosition, ByVal strSampleName As String, ByVal intMaxSample As Integer, ByVal intMaxStandard As Integer, ByVal enumMode As EnumService_Mode)
    '    Dim NoOfChannels, temp_cnt, rec_cnt As Integer
    '    Dim objDataRow As DataRow
    '    Dim j As Integer
    '    mobjDataTable.Columns.Add(New DataColumn("SampleID", GetType(String)))
    '    mobjDataTable.Columns.Add(New DataColumn("SamplerPosition", GetType(String)))



    '    For temp_cnt = gstructAutoSamplerPosition.intSpectrumPosition + 1 To 100

    '        If temp_cnt <= 10 Then
    '            If gstructAutoSamplerPosition.intSpectrumPosition = 0 Then
    '                objDataRow = mobjDataTable.NewRow
    '                objDataRow("SamplerPosition") = (temp_cnt + 1)
    '                objDataRow("SampleID") = "Sample # " & temp_cnt
    '                mobjDataTable.Rows.Add(objDataRow)
    '            Else
    '                objDataRow = mobjDataTable.NewRow
    '                objDataRow("SamplerPosition") = 0
    '                objDataRow("SampleID") = "Sample # " & temp_cnt
    '                mobjDataTable.Rows.Add(objDataRow)
    '            End If
    '        Else
    '            objDataRow = mobjDataTable.NewRow
    '            objDataRow("SamplerPosition") = 0
    '            objDataRow("SampleID") = "Sample # " & temp_cnt
    '            mobjDataTable.Rows.Add(objDataRow)
    '        End If

    '    Next

    'End Function

    Private Sub frmAutoSampPosn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgSamplerPosition.DataSource = mobjDataTable
        dgSamplerPosition.Refresh()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim intCounter As Integer = 0
        Dim arrAutoSamplerIn As New ArrayList
        'gstructAutoSampler.arrAutoSamplerPosition = New ArrayList
        ' For intCounter = 0 To mobjDataTable.Rows.Count - 1
        Try
            For intCounter = 0 To gstructAutoSampler.arrAutoSamplerPosition.Count - 1
                arrAutoSamplerIn.Add(gstructAutoSampler.arrAutoSamplerPosition.Item(intCounter))
            Next
            If Not funcValidateSamplerPosition(mobjDataTable) Then
                Me.DialogResult = DialogResult.None
            Else
                'While dgSamplerPosition.Item(intCounter, 1) <> 0
                '    gstructAutoSampler.arrAutoSamplerPosition.Add(dgSamplerPosition.Item(intCounter, 1))
                '    intCounter += 1
                'End While
                '  Call funcSavePosition(gstructAutoSamplerPosition, gstructAutoSampler.arrAutoSamplerPosition.Count)
                ' gstructAutoSamplerPosition.intSpectrumPosition = gstructAutoSamplerPosition.intSpectrumPosition + gstructAutoSampler.arrAutoSamplerPosition.Count
                Me.DialogResult = DialogResult.OK
            End If

            'added and commented by kamal on 19March2004
            '----------------------------
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

    Public Function funcValidateSamplerPosition(ByVal objDataTable As DataTable) As Boolean

        Dim intRowCounter As Integer
        Dim intColCounter As Integer
        Dim intCurrentCol As Integer
        Dim intCurrentRow As Integer
        Dim blnFlag As Boolean

        Try
            '--- checking for invalid data entered in the
            '--- Grid and invoke the Error Message
            intCurrentCol = dgSamplerPosition.CurrentCell.ColumnNumber
            intCurrentRow = dgSamplerPosition.CurrentCell.RowNumber
            For intRowCounter = 0 To objDataTable.Rows.Count - 1
                intColCounter = intRowCounter
                If IsNumeric(dgSamplerPosition.Item(intRowCounter, 1)) Then
                    If Not gfuncValidateGrid(dgSamplerPosition.Item(intRowCounter, 1), 0) Then
                        dgSamplerPosition.Focus()
                        Return False
                    End If
                    If dgSamplerPosition.Item(0, 1) = 0 Then
                        'gFuncShowMessage("Invalid Input", "Enter sampler position for analysis", EnumMessageType.Information)
                        Call gobjMessageAdapter.ShowMessage(constAutoSamplerPosition)
                        dgSamplerPosition.Focus()
                        Return False
                    End If
                    If dgSamplerPosition.Item(intRowCounter, 1) <> 0 Then
                        If dgSamplerPosition.Item(intRowCounter, 1) < 2 Or dgSamplerPosition.Item(intRowCounter, 1) > 65 Then
                            'gFuncShowMessage("Invalid Input", "Enter sampler positions between 2 and 65 ", EnumMessageType.Information)
                            Call gobjMessageAdapter.ShowMessage(constAutoSamplerBetween2and65)
                            dgSamplerPosition.Focus()
                            Return False
                        End If
                    Else
                        If intRowCounter <= objDataTable.Rows.Count - 2 Then
                            If dgSamplerPosition.Item(intColCounter + 1, 1) <> 0 Or dgSamplerPosition.Item(intColCounter + 1, 1) = "" Then
                                'gFuncShowMessage("Invalid Input", "Enter sampler positions between 2 and 65 ", EnumMessageType.Information)
                                Call gobjMessageAdapter.ShowMessage(constAutoSamplerBetween2and65)
                                dgSamplerPosition.Focus()
                                Return False
                            End If
                        End If
                    End If
                Else
                    If dgSamplerPosition.Item(intRowCounter, 1) = "" Then
                        'gFuncShowMessage("Invalid Input", "Do not leave blank positions for intermediate samples! ", EnumMessageType.Information)
                        Call gobjMessageAdapter.ShowMessage(constAutoSamplerBlankPositions)
                        dgSamplerPosition.Focus()
                        Return False
                    Else
                        'gFuncShowMessage("Invalid Input", "Please enter  numeric values ! ", EnumMessageType.Information)
                        Call gobjMessageAdapter.ShowMessage(constAutoSamplerNumericValues)
                        dgSamplerPosition.Focus()
                        Return False
                    End If
                End If
            Next intRowCounter

            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error logging
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function funcSavePosition(ByRef structAutoSamplerPosn As structAutoSamplerPosition, ByVal intRowCounter As Integer)
        '**************  To be do ******************
        'Select Case OPERATION_MODE
        '    Case EnumService_Mode.Spectrum
        '        structAutoSamplerPosn.intSpectrumPosition = structAutoSamplerPosn.intSpectrumPosition + intRowCounter
        '    Case EnumService_Mode.Photometry
        '        structAutoSamplerPosn.intPhotometryPosition = structAutoSamplerPosn.intPhotometryPosition + intRowCounter
        '    Case EnumService_Mode.Quantitative
        '        structAutoSamplerPosn.intQuantPosition = structAutoSamplerPosn.intQuantPosition + intRowCounter
        '    Case EnumService_Mode.Multiomponent
        '        structAutoSamplerPosn.intMultiPosition = structAutoSamplerPosn.intMultiPosition + intRowCounter
        '    Case EnumService_Mode.Kinetics
        '        structAutoSamplerPosn.intKineticPosition = structAutoSamplerPosn.intKineticPosition + intRowCounter
        '    Case EnumService_Mode.TimeScan
        '        structAutoSamplerPosn.intTimeScanPosition = structAutoSamplerPosn.intTimeScanPosition + intRowCounter
        '    Case Else
        '        structAutoSamplerPosn.intSpectrumPosition = structAutoSamplerPosn.intSpectrumPosition + intRowCounter
        '        'structAutoSamplerPosn.intQuantPosition = structAutoSamplerPosn.intQuantPosition + intRowCounter

        'End Select

    End Function

End Class
