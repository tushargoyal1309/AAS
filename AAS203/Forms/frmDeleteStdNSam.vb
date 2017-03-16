Imports AAS203.Common
Imports AAS203Library
Imports AAS203Library.Method

Public Class frmDeleteStdNSam ''class behind the class.
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByRef objMethodIn As clsMethod, ByVal intSelectedRunNumberIndex As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mobjclsMethod = objMethodIn
        mintSelectedRunNumberIndex = intSelectedRunNumberIndex

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
    Friend WithEvents btnOk As NETXP.Controls.XPButton
    Friend WithEvents dgViewResults As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDeleteStdNSam))
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.btnOk = New NETXP.Controls.XPButton
        Me.dgViewResults = New System.Windows.Forms.DataGrid
        Me.CustomPanel1.SuspendLayout()
        CType(Me.dgViewResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanel1.Controls.Add(Me.btnOk)
        Me.CustomPanel1.Controls.Add(Me.dgViewResults)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(506, 301)
        Me.CustomPanel1.TabIndex = 2
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(210, 259)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 34)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "&OK"
        '
        'dgViewResults
        '
        Me.dgViewResults.CaptionVisible = False
        Me.dgViewResults.DataMember = ""
        Me.dgViewResults.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgViewResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgViewResults.Location = New System.Drawing.Point(15, 11)
        Me.dgViewResults.Name = "dgViewResults"
        Me.dgViewResults.Size = New System.Drawing.Size(476, 240)
        Me.dgViewResults.TabIndex = 0
        '
        'frmDeleteStdNSam
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(506, 301)
        Me.Controls.Add(Me.CustomPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeleteStdNSam"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delete Standards/Samples"
        Me.CustomPanel1.ResumeLayout(False)
        CType(Me.dgViewResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Private Variables"

    Private mobjDtStandards As DataTable
    Private mobjDtStandardsDataGrid As DataGridClass
    Private mobjclsMethod As clsMethod
    Private mintSelectedRunNumberIndex As Integer
    Private strColumnAbsorbance As String = "Absorbance"
#End Region

#Region " Private Constants "

    Private Const ConstColumnSrNo = "SrNo"
    Private Const ConstColumnStandardName = "StandardName"
    Private Const ConstColumnAbsorbance = "Absorbance"
    Private Const ConstColumnNameEmission = "%Emission"

    Private Const ConstColumnConcentration = "Concentration"
    Private Const ConstColumnRemove = "Remove"
    Private Const ConstColumnIsStandard = "IsStandard"

    Private Const ConstTitleSrNo = "Sr.No."
    Private Const ConstTitleStandardName = "Standard Name"
    Private Const ConstTitleAbsorbance = "Absorbance"
    Private Const ConstTitleEmission = "Emission"

    Private Const ConstTitleConcentration = "Concentrations"
    Private Const ConstTitleRemove = "Remove"

    Private Const ConstWidthSrNo = 55
    Private Const ConstWidthStandardName = 100
    Private Const ConstWidthAbsorbance = 120
    Private Const ConstWidthConcentration = 120
    Private Const ConstWidthRemove = 60

    Private Const ConstParentFormLoad = "-DataFiles"
    Private Const ConstFormLoad = "-DataFiles-Delete Standard/Sample"

#End Region

#Region " Form Events "

    Private Sub frmViewResults_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmViewResults_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialize and load the form
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim intCounter As Integer
        Dim objRow As DataRow
        Dim intCount As Integer

        Try
            Call gobjMain.ShowProgressBar(gstrTitleInstrumentType & ConstFormLoad)
            ''for showing some instrument info.
            'Call funcLoadInitialData()
            If Not (mobjclsMethod Is Nothing) Then
                If mobjclsMethod.OperationMode = EnumOperationMode.MODE_EMMISSION Then
                    strColumnAbsorbance = ConstTitleEmission
                Else
                    strColumnAbsorbance = ConstTitleAbsorbance
                End If
            End If
            Call AddHandlers()
            ''for adding event to a control.
            '---add columns to the datatable
            mobjDtStandards = New DataTable
            ''creat a new object for a datastructure.
            mobjDtStandards.Columns.Add(ConstColumnSrNo, GetType(Integer))
            mobjDtStandards.Columns.Add(ConstColumnStandardName, GetType(String))
            'mobjDtStandards.Columns.Add(ConstColumnAbsorbance, GetType(Double))
            'mobjDtStandards.Columns.Add(ConstColumnConcentration, GetType(Double))
            mobjDtStandards.Columns.Add(ConstColumnAbsorbance, GetType(String))  'Added By Pankaj on 04 Jun 07
            mobjDtStandards.Columns.Add(ConstColumnConcentration, GetType(String)) 'Added By Pankaj on 04 07
            mobjDtStandards.Columns.Add(ConstColumnRemove, GetType(Boolean))
            mobjDtStandards.Columns.Add(ConstColumnIsStandard, GetType(Boolean))
            mobjDtStandardsDataGrid = New DataGridClass(ConstDataGridPropertiesFileName)
            mobjDtStandardsDataGrid.AllowNew = False
            mobjDtStandardsDataGrid.AdjustColumnWidthToGrid = False

            mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnSrNo).ColumnName, dgViewResults, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleSrNo, ConstWidthSrNo, True, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
            mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnStandardName).ColumnName, dgViewResults, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleStandardName, ConstWidthStandardName, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Left)
            mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnAbsorbance).ColumnName, dgViewResults, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, strColumnAbsorbance, ConstWidthAbsorbance, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
            mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnConcentration).ColumnName, dgViewResults, mobjDtStandards, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, ConstTitleConcentration, ConstWidthConcentration, False, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)
            mobjDtStandardsDataGrid.AddDataGridColumnStyle(mobjDtStandards.Columns(ConstColumnRemove).ColumnName, dgViewResults, mobjDtStandards, DataGridClass.enumColumnType.BoolColumn, HorizontalAlignment.Center, ConstTitleRemove, ConstWidthRemove, True, DataGridClass.ColumnDataType.Text, HorizontalAlignment.Center)

            '---load initial data on screen
            Call funcLoadInitialData()

            '---bind datatable to the datagrid
            Call mobjDtStandardsDataGrid.SetDataGridProperties(dgViewResults, mobjDtStandards)

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
            gobjMain.HideProgressBar()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmDeleteStdNSam_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '=====================================================================
        ' Procedure Name        : frmDeleteStdNSam_Closing
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : THIS IS USED TO close the form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 
        ' Revisions             : 
        '=====================================================================
        ''note:
        ''this is called when user close the form.
        gobjMain.ShowRunTimeInfo(gstrTitleInstrumentType & ConstParentFormLoad)
    End Sub

#End Region

#Region " Private Functions"

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : 
        ' Returns               : None
        ' Purpose               :for adding a event to a control.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 
        ' Revisions             : praveen
        '=====================================================================
        ''note:
        ''this is called during a loading of a form.
        'add event handlers
        AddHandler btnOk.Click, AddressOf btnOk_Click
        AddHandler dgViewResults.MouseDown, AddressOf subdgStdConcentrationListMouseDown
    End Sub

    Private Function funcLoadInitialData() As Boolean
        '=====================================================================
        ' Procedure Name        : funcLoadInitialData
        ' Parameters Passed     : None
        ' Returns               : True or False
        ' Purpose               : To load initial data
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 08.10.06
        ' Revisions             : 2
        ' Revision By           : Mangesh S. on 28-Jan-2007
        ' Revision for          : Changes in AAS203Library
        '=====================================================================
        Dim intCounter As Integer
        Dim dblConc As Double
        Dim objRow As DataRow

        Try
            '---to add standard rows to the datatable
            '---Standards
            If mobjDtStandards Is Nothing Then
                Exit Function
            End If
            If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex) Is Nothing Then
                Exit Function
            End If
            For intCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Count - 1
                objRow = mobjDtStandards.NewRow
                objRow.Item(ConstColumnSrNo) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).StdNumber
                objRow.Item(ConstColumnStandardName) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).StdName

                'Saurabh To format the Abs value upto 3 decimal places 20.07.07
                objRow.Item(ConstColumnAbsorbance) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).Abs, "0.000")
                'Saurabh To format the concentration value upto 2 decimal places 20.07.07

                '---commented on 27.03.09
                ''objRow.Item(ConstColumnConcentration) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).Concentration, "0.00")
                '-------

                '---written on 27.03.09
                If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPM Then
                    objRow.Item(ConstColumnConcentration) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).Concentration, "0.00")
                ElseIf mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit = enumUnit.Percent Then
                    objRow.Item(ConstColumnConcentration) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).Concentration, "0.00")
                ElseIf mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                    objRow.Item(ConstColumnConcentration) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intCounter).Concentration, "0.0000")
                End If
                '---------

                objRow.Item(ConstColumnRemove) = False
                objRow.Item(ConstColumnIsStandard) = True
                mobjDtStandards.Rows.Add(objRow)
            Next


            '---- Added by Mangesh on 10-May-2007

            '---to add sample rows to the datatable
            '---Samples
            For intCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Count - 1
                objRow = mobjDtStandards.NewRow
                objRow.Item(ConstColumnSrNo) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).SampNumber
                'objRow.Item(ConstColumnStandardName) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).SampleName
                objRow.Item(ConstColumnStandardName) = mobjclsMethod.SampleDataCollection.item(intCounter).SampleName
                objRow.Item(ConstColumnAbsorbance) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Abs, "0.000")
                'objRow.Item(ConstColumnConcentration) = Format(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Conc, "0.000000")
                If mobjclsMethod.StandardAddition = True Then
                    dblConc = CStr(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Conc)
                Else
                    dblConc = gobjclsStandardGraph.Get_Conc(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0)
                End If

                '----commented on 27.03.09
                '''objRow.Item(ConstColumnConcentration) = Format(dblConc, "0.00")
                '------

                '----written on 27.03.09
                If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPM Then
                    objRow.Item(ConstColumnConcentration) = Format(dblConc, "0.00")
                ElseIf mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit = enumUnit.Percent Then
                    objRow.Item(ConstColumnConcentration) = Format(dblConc, "0.00")
                ElseIf mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).AnalysisParameters.Unit = enumUnit.PPB Then
                    objRow.Item(ConstColumnConcentration) = Format(dblConc, "0.0000")
                End If
                '----------

                If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Used Then
                    objRow.Item(ConstColumnRemove) = False
                Else
                    objRow.Item(ConstColumnRemove) = True
                End If
                '---------Added By Pankaj on 04 Jun 07 
                If CDbl(objRow.Item(ConstColumnAbsorbance)) = -1 Then
                    objRow.Item(ConstColumnAbsorbance) = " "
                    objRow.Item(ConstColumnConcentration) = " "
                End If
                '--------
                objRow.Item(ConstColumnIsStandard) = False
                mobjDtStandards.Rows.Add(objRow)
            Next
            mobjDtStandards.Columns.Item(ConstColumnSrNo).ReadOnly = True
            mobjDtStandards.Columns.Item(ConstColumnStandardName).ReadOnly = True
            mobjDtStandards.Columns.Item(ConstColumnConcentration).ReadOnly = True
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

    Private Function funcUpdataMethodCollection() As Boolean
        '=====================================================================
        ' Procedure Name        : funcUpdataMethodCollection
        ' Parameters Passed     : None
        ' Returns               : True/False
        ' Purpose               :  To remove the user selected Standards/Sample from Method
        ' Description           : On mouse down Update the selected Standard/Sample
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Wednesday, May 14, 2008
        ' Revisions             : Sachin Dokhale
        '=====================================================================
        Dim intRowsCounter As Integer
        Dim intMethodCounter As Integer
        Dim intSampleCounter As Integer
        Dim intStdCounter As Integer
        Dim blnIsSampleDeleted As Boolean

        Try
            For intMethodCounter = 0 To gobjMethodCollection.Count - 1
                ''make a counter up to a last data.
                If mobjclsMethod.MethodID = gobjMethodCollection.item(intMethodCounter).MethodID Then
                    Exit For
                End If
            Next

            'remove selected standard or sample by using used flag

            For intRowsCounter = 0 To mobjDtStandards.Rows.Count - 1
                If Not mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnIsStandard) Then
                    For intSampleCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Count - 1
                        If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnSrNo) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).SampNumber And _
                            Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnStandardName)) = Trim(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).SampleName) Then
                            If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnRemove) Then
                                If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
                                    mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = False
                                End If
                                If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
                                    gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = False
                                End If
                            Else
                                If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
                                    mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = True
                                End If
                                If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
                                    gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = True
                                End If
                            End If
                            'Saurabh 19.07.07 To check DBNull
                            If Not IsDBNull(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) Then
                                If Not Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) = "" Then
                                    If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
                                        mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
                                    End If
                                    If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
                                        gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
                                    End If
                                End If
                            End If
                            'Saurabh 19.07.07 To check DBNull
                        End If
                    Next

                End If
            Next intRowsCounter

            For intRowsCounter = 0 To mobjDtStandards.Rows.Count - 1
                If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnIsStandard) = True Then
                    For intStdCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Count - 1
                        If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnSrNo) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).StdNumber And _
                            Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnStandardName)) = Trim(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).StdName) Then
                            If Not IsDBNull(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) Then
                                If Not Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) = "" Then
                                    If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
                                        mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
                                    End If
                                    If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
                                        gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            Next intRowsCounter

            '---save all methods to method collection
            Call funcSaveAllMethods(gobjMethodCollection)
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnOk_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : To remove the user selected Standards from Method
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 05-Apr-2007 04:05 pm
        ' Revisions             : 
        '=====================================================================

        ''note;
        ''this is called when user click OK button.
        ''this will handle a OK button event.
        ''To remove the user selected Standards from Method

        'Dim intRowsCounter As Integer
        'Dim intMethodCounter As Integer
        'Dim intSampleCounter As Integer
        'Dim intStdCounter As Integer
        'Dim blnIsSampleDeleted As Boolean
        Dim objWait As New CWaitCursor
        Try
            'For intMethodCounter = 0 To gobjMethodCollection.Count - 1
            '    ''make a counter up to a last data.
            '    If mobjclsMethod.MethodID = gobjMethodCollection.item(intMethodCounter).MethodID Then
            '        Exit For
            '    End If
            'Next

            ''remove selected standard or sample by using used flag

            'For intRowsCounter = 0 To mobjDtStandards.Rows.Count - 1
            '    If Not mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnIsStandard) Then
            '        For intSampleCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.Count - 1
            '            If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnSrNo) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).SampNumber And _
            '                Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnStandardName)) = Trim(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).SampleName) Then
            '                If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnRemove) Then
            '                    If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
            '                        mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = False
            '                    End If
            '                    If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
            '                        gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = False
            '                    End If
            '                Else
            '                    If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
            '                        mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = True
            '                    End If
            '                    If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
            '                        gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Used = True
            '                    End If
            '                End If
            '                'Saurabh 19.07.07 To check DBNull
            '                If Not IsDBNull(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) Then
            '                    If Not Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) = "" Then
            '                        If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
            '                            mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
            '                        End If
            '                        If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
            '                            gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intSampleCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
            '                        End If
            '                    End If
            '                End If
            '                'Saurabh 19.07.07 To check DBNull
            '            End If
            '        Next

            '    End If
            'Next intRowsCounter

            'For intRowsCounter = 0 To mobjDtStandards.Rows.Count - 1
            '    If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnIsStandard) = True Then
            '        For intStdCounter = 0 To mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.Count - 1
            '            If mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnSrNo) = mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).StdNumber And _
            '                Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnStandardName)) = Trim(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).StdName) Then
            '                If Not IsDBNull(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) Then
            '                    If Not Trim(mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)) = "" Then
            '                        If mobjclsMethod.QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
            '                            mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
            '                        End If
            '                        If gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Count > mintSelectedRunNumberIndex Then
            '                            gobjMethodCollection.item(intMethodCounter).QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).StandardDataCollection.item(intStdCounter).Abs = mobjDtStandards.Rows.Item(intRowsCounter).Item(ConstColumnAbsorbance)
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        Next
            '    End If
            'Next intRowsCounter

            ''---save all methods to method collection
            'Call funcSaveAllMethods(gobjMethodCollection)
            Call funcUpdataMethodCollection()
            Me.DialogResult = DialogResult.OK

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Me.DialogResult = DialogResult.Cancel
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
            Application.DoEvents()
            objWait.Dispose()
        End Try
    End Sub

    Private Sub subdgStdConcentrationListMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        '=====================================================================
        ' Procedure Name        : subdgStdConcentrationListMouseDown
        ' Parameters Passed     : Object,MouseEventArgs
        ' Returns               : None
        ' Purpose               : To remove the selected standard from datatable
        ' Description           : On mouse down remove the selected standard
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Wednesday, December 08, 2004
        ' Revisions             : praveencheck 08.10.06
        '=====================================================================
        Dim hit As DataGrid.HitTestInfo
        ''datagrid variable for holding a info.
        Dim intCounter As Integer
        Dim objRow As DataRow

        Try
            hit = dgViewResults.HitTest(e.X, e.Y)
            ''get a current info to be displayed.

            If hit.Type = DataGrid.HitTestType.Cell Then
                mobjDtStandards.Columns.Item(ConstColumnConcentration).ReadOnly = True
                Select Case hit.Column
                    Case 4
                        If mobjDtStandards.Rows.Item(hit.Row).Item(ConstColumnIsStandard) Then
                            mobjDtStandards.Rows.Item(hit.Row).Item(ConstColumnRemove) = False
                        Else
                            mobjDtStandards.Rows.Item(hit.Row).Item(ConstColumnRemove) = Not mobjDtStandards.Rows.Item(hit.Row).Item(ConstColumnRemove)
                        End If
                    Case 2
                        'Call funcUpdataMethodCollection()
                        'mobjDtStandards.Columns.Item(ConstColumnConcentration).ReadOnly = False
                        'If mobjDtStandards Is Nothing Then
                        '    Exit Sub
                        'End If
                        'If mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex) Is Nothing Then
                        '    Exit Sub
                        'End If
                        'Dim dblConc As Double
                        'If mobjclsMethod.StandardAddition = True Then
                        '    dblConc = CStr(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Conc)
                        'Else
                        '    dblConc = gobjclsStandardGraph.Get_Conc(mobjclsMethod.QuantitativeDataCollection.Item(mintSelectedRunNumberIndex).SampleDataCollection.item(intCounter).Abs, 0.0)
                        'End If
                        'mobjDtStandards.Rows.Item(hit.Row).Item(ConstColumnConcentration) = Format(dblConc, "0.00")
                        'mobjDtStandards.Columns.Item(ConstColumnConcentration).ReadOnly = True
                        'objRow.Item(ConstColumnConcentration) = Format(dblConc, "0.00")
                End Select
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
            Application.DoEvents()
        End Try
    End Sub

#End Region

End Class
