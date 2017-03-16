Option Explicit On 
Imports AAS203.Common
Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Public Class frmActivityLog
    Inherits System.Windows.Forms.Form

#Region "Module level Declarations "
    Private mobjTreeNode As New TreeNode
    Private mdtActivityMaxDt As Date
    Private mdtActivityStartDt As Date
    Private mdtActivityEndDt As Date
    Private mblnProcessing As Boolean = False

    Private Enum ENUM_RecordsReqd
        InitialValues = 1
        PreviousValues = 2
        NextValues = 3
    End Enum

    '--- Enum for the toolbar indexes 
    Private Enum EnumToolBarButtons
        PreviousDate = 0
        NextDate = 1
        FileRetrieve = 3
        AppClose = 5
    End Enum

    '--- Enum for the image indices
    Private Enum EnumImageIndex
        EnablePreviousDate = 0
        EnableNextDate = 1
        EnableFileRetrieve = 2
        EnableClose = 3
        DisableFileRetrieve = 5
    End Enum

#End Region

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
    Friend WithEvents imglstActivitylog As System.Windows.Forms.ImageList
    Friend WithEvents tlbrActivitylog As System.Windows.Forms.ToolBar
    Friend WithEvents lblDateRange As System.Windows.Forms.Label
    Friend WithEvents Previous As System.Windows.Forms.ToolBarButton
    Friend WithEvents btn_Next As System.Windows.Forms.ToolBarButton
    Friend WithEvents Separator As System.Windows.Forms.ToolBarButton
    Friend WithEvents FileRetrieve As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlbClose As System.Windows.Forms.ToolBarButton
    Friend WithEvents ImageList_TreeView As System.Windows.Forms.ImageList
    Friend WithEvents StbrStatus As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents trvLogData As System.Windows.Forms.TreeView
    Friend WithEvents SplitterTreeView As System.Windows.Forms.Splitter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lstViewDetails As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmActivityLog))
        Me.tlbrActivitylog = New System.Windows.Forms.ToolBar
        Me.Previous = New System.Windows.Forms.ToolBarButton
        Me.btn_Next = New System.Windows.Forms.ToolBarButton
        Me.Separator = New System.Windows.Forms.ToolBarButton
        Me.FileRetrieve = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton
        Me.tlbClose = New System.Windows.Forms.ToolBarButton
        Me.imglstActivitylog = New System.Windows.Forms.ImageList(Me.components)
        Me.lblDateRange = New System.Windows.Forms.Label
        Me.ImageList_TreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.StbrStatus = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.trvLogData = New System.Windows.Forms.TreeView
        Me.SplitterTreeView = New System.Windows.Forms.Splitter
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lstViewDetails = New System.Windows.Forms.ListView
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlbrActivitylog
        '
        Me.tlbrActivitylog.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbrActivitylog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlbrActivitylog.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Previous, Me.btn_Next, Me.Separator, Me.FileRetrieve, Me.ToolBarButton1, Me.tlbClose})
        Me.tlbrActivitylog.DropDownArrows = True
        Me.tlbrActivitylog.ImageList = Me.imglstActivitylog
        Me.tlbrActivitylog.Location = New System.Drawing.Point(0, 0)
        Me.tlbrActivitylog.Name = "tlbrActivitylog"
        Me.tlbrActivitylog.ShowToolTips = True
        Me.tlbrActivitylog.Size = New System.Drawing.Size(672, 38)
        Me.tlbrActivitylog.TabIndex = 16
        '
        'Previous
        '
        Me.Previous.ImageIndex = 0
        Me.Previous.Tag = "Previous"
        Me.Previous.ToolTipText = "Previous Log"
        '
        'btn_Next
        '
        Me.btn_Next.ImageIndex = 1
        Me.btn_Next.Tag = "Next"
        Me.btn_Next.ToolTipText = "Next Log"
        '
        'Separator
        '
        Me.Separator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.Separator.Tag = ""
        Me.Separator.Text = "FileRetrieve"
        '
        'FileRetrieve
        '
        Me.FileRetrieve.Tag = "FileRetrieve"
        Me.FileRetrieve.ToolTipText = "File Retrieve"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tlbClose
        '
        Me.tlbClose.ImageIndex = 3
        Me.tlbClose.Tag = "Close"
        Me.tlbClose.ToolTipText = "Close"
        '
        'imglstActivitylog
        '
        Me.imglstActivitylog.ImageSize = New System.Drawing.Size(25, 25)
        Me.imglstActivitylog.ImageStream = CType(resources.GetObject("imglstActivitylog.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglstActivitylog.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblDateRange
        '
        Me.lblDateRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateRange.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateRange.Location = New System.Drawing.Point(337, 6)
        Me.lblDateRange.Name = "lblDateRange"
        Me.lblDateRange.Size = New System.Drawing.Size(328, 28)
        Me.lblDateRange.TabIndex = 21
        Me.lblDateRange.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ImageList_TreeView
        '
        Me.ImageList_TreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList_TreeView.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList_TreeView.ImageStream = CType(resources.GetObject("ImageList_TreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_TreeView.TransparentColor = System.Drawing.Color.Transparent
        '
        'StbrStatus
        '
        Me.StbrStatus.Cursor = System.Windows.Forms.Cursors.Help
        Me.StbrStatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StbrStatus.Location = New System.Drawing.Point(0, 437)
        Me.StbrStatus.Name = "StbrStatus"
        Me.StbrStatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StbrStatus.ShowPanels = True
        Me.StbrStatus.Size = New System.Drawing.Size(672, 24)
        Me.StbrStatus.SizingGrip = False
        Me.StbrStatus.TabIndex = 25
        Me.StbrStatus.Text = "StatusBar1"
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Text = "Shows extra information"
        Me.StatusBarPanel1.Width = 672
        '
        'trvLogData
        '
        Me.trvLogData.BackColor = System.Drawing.Color.AliceBlue
        Me.trvLogData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trvLogData.Dock = System.Windows.Forms.DockStyle.Left
        Me.trvLogData.ImageList = Me.ImageList_TreeView
        Me.trvLogData.Location = New System.Drawing.Point(0, 38)
        Me.trvLogData.Name = "trvLogData"
        Me.trvLogData.Size = New System.Drawing.Size(216, 399)
        Me.trvLogData.TabIndex = 27
        '
        'SplitterTreeView
        '
        Me.SplitterTreeView.BackColor = System.Drawing.Color.Gray
        Me.SplitterTreeView.Location = New System.Drawing.Point(216, 38)
        Me.SplitterTreeView.Name = "SplitterTreeView"
        Me.SplitterTreeView.Size = New System.Drawing.Size(2, 399)
        Me.SplitterTreeView.TabIndex = 28
        Me.SplitterTreeView.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lstViewDetails)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(218, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(454, 399)
        Me.Panel1.TabIndex = 29
        '
        'lstViewDetails
        '
        Me.lstViewDetails.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstViewDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstViewDetails.BackColor = System.Drawing.Color.AliceBlue
        Me.lstViewDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstViewDetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstViewDetails.ForeColor = System.Drawing.Color.Black
        Me.lstViewDetails.Location = New System.Drawing.Point(0, 0)
        Me.lstViewDetails.Name = "lstViewDetails"
        Me.lstViewDetails.Size = New System.Drawing.Size(452, 399)
        Me.lstViewDetails.SmallImageList = Me.ImageList_TreeView
        Me.lstViewDetails.TabIndex = 1
        Me.lstViewDetails.View = System.Windows.Forms.View.List
        '
        'frmActivityLog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(672, 461)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SplitterTreeView)
        Me.Controls.Add(Me.trvLogData)
        Me.Controls.Add(Me.StbrStatus)
        Me.Controls.Add(Me.lblDateRange)
        Me.Controls.Add(Me.tlbrActivitylog)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmActivityLog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activity log - History of all the acitivities"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events"

    Private Sub frmActivityLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmAddUser_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Activity Log form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            funcInitialize()

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

    Private Sub trvLogData_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvLogData.AfterSelect
        '=====================================================================
        ' Procedure Name        : trvLogData_AfterSelect
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To view the log of particular selected date.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim tag_data As String
        Dim tag_type As String()
        Dim objWait As New CWaitCursor
        Try
            If mblnProcessing = True Then
                Exit Sub
            End If
            mblnProcessing = True

            'btnRetrive.Visible = False
            'tlbrActivitylog.Buttons.Item(3).Enabled = False
            tlbrActivitylog.Buttons.Item(EnumToolBarButtons.FileRetrieve).ImageIndex = EnumImageIndex.DisableFileRetrieve

            If (e.Action.ByKeyboard Or e.Action.ByMouse) Then
                tag_data = e.Node.Tag
                tag_type = tag_data.Split("|")

                If (tag_type(0) = "DT") Then
                    Dim l_date As DateTime
                    l_date = Convert.ToDateTime(tag_type(1))
                    funcShowLogsForDate(l_date)
                ElseIf (tag_type(0) = "MD") Then
                    Dim l_log_id As Long
                    l_log_id = Convert.ToInt64(tag_type(1))
                    funcGetLogDetailsForModule(l_log_id)
                End If
            End If

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
            objWait.dispose()
            '---------------------------------------------------------
            mblnProcessing = False
        End Try
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnPrevious_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To view the previous selected log details.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            funcGetActivityDateRange(ENUM_RecordsReqd.PreviousValues)
            lstViewDetails.Clear()
            trvLogData.Nodes.Clear()
            funcGetLogRecords()
            trvLogData.Nodes.Add(mobjTreeNode)

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

#Region " Private functions"

    '--------------------------------------------------------
    '    General functions used for Activity Log.
    '--- funcInitialize - To Initialize the form and show all the activities from database.
    '--- funcGetLogRecords - To Get the Current Users from the database and display them.
    '--- funcGetModuleDetails - To Add Module Names to the Date Node.
    '--- funcGetLogDetailsForModule - To Show Activity Logs for the Module Clicked.
    '--- funcShowLogsForModule - To Show Logs Details for the Module Clicked.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitialize
        ' Description           :   To Initialize the form and show all the activities from database.
        ' Purpose               :   To Initialize the form and show all the activities from database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007 
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            If funcGetMaxActivityDate() Then
                funcGetActivityDateRange(ENUM_RecordsReqd.InitialValues)
            Else
                Exit Sub
            End If

            If Not funcGetLogRecords() Then
                Throw New Exception("Error in Initialization.")
            End If

            trvLogData.Nodes.Add(mobjTreeNode)

            tlbrActivitylog.Buttons.Item(EnumToolBarButtons.FileRetrieve).ImageIndex = EnumImageIndex.DisableFileRetrieve

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Sub

    Private Function funcGetLogRecords() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGetLogRecords
        ' Description           :   To Get the Current Users from the database and display them.
        ' Purpose               :   To Get the Current Users from the database and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007 
        ' Revisions             :   
        '=====================================================================
        Dim result As Boolean
        Dim str_sql, str_sql1 As String
        Dim objOledbConnection As OleDbConnection
        Dim objReader As OleDbDataReader
        Dim objNode As TreeNode
        Dim objWait As New CWaitCursor

        mobjTreeNode.Nodes.Clear()
        mobjTreeNode.Text = "Activity Log"
        mobjTreeNode.Tag = "RT|"

        Try
            objOledbConnection = gOleDBConnection_LogBook

            '--- Generating dynamic query for selection type
            str_sql = "Select ActivityLog.ActivityDateTime " & _
                      "From ActivityLog " & _
                      "Where ActivityLog.ActivityDateTime between " & _
                      "#" & FormatDateTime(mdtActivityStartDt.AddDays(-1), DateFormat.ShortDate) & "#" & " And " & _
                      "#" & FormatDateTime(mdtActivityEndDt.AddDays(1), DateFormat.ShortDate) & "# " & _
                      "Order by ActivityDateTime Desc "


            result = gclsDBFunctions.OpenConnection(objOledbConnection)
            If Not (result) Then
                Return False
            End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            gclsDBFunctions.GetRecords(str_sql, objOledbConnection, objReader)

            While objReader.Read
                Dim l_date As Date
                objNode = New TreeNode
                If Not FormatDateTime(l_date, DateFormat.ShortDate) = FormatDateTime(objReader.Item("ActivityDateTime"), DateFormat.ShortDate) Then
                    l_date = objReader.Item("ActivityDateTime")

                    objNode.Tag = "DT|" & l_date.ToString()
                    objNode.Text = l_date.ToString("MMM dd yyyy")

                    objNode = funcGetModuleDetails(l_date, objNode)

                    mobjTreeNode.Nodes.Add(objNode)
                End If
            End While

            objReader.Close()

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcGetModuleDetails(ByVal logdate As Date, ByVal objNode As TreeNode) As TreeNode
        '=====================================================================
        ' Procedure Name        :   funcGetModuleDetails
        ' Description           :   To Add Module Names to the Date Node.
        ' Purpose               :   To Add Module Names to the Date Node.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim str_sql, module_name As String
        Dim objOledbConnection As OleDbConnection
        Dim objReaderModule As OleDbDataReader
        Dim objTrn As TreeNode
        Dim str_connection As String
        Dim objWait As New CWaitCursor

        Try
            '--- Passing database name to clsstrConnString property
            str_connection = gclsDBFunctions.ConnectionString(CONSTSTR_LOGERRORDATABASENAME)
            objOledbConnection = New OleDbConnection(str_connection)

            str_sql = "Select ActivityLog.ActivityLogID ,ActivityLog.ModuleID ,Modules.ModuleName " & _
                      "from ActivityLog ,Modules " & _
                      "where ActivityLog.ActivityDateTime = CDate('" & logdate & "') " & _
                      "and ActivityLog.ModuleID = Modules.ModuleID "

            result = gclsDBFunctions.OpenConnection(objOledbConnection)
            If Not (result) Then
                Return objNode
            End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            gclsDBFunctions.GetRecords(str_sql, objOledbConnection, objReaderModule)

            While objReaderModule.Read
                objTrn = New TreeNode
                objTrn.Tag = "MD|" & objReaderModule.Item("ActivityLogID")
                objTrn.ImageIndex = 2
                module_name = objReaderModule.Item("ModuleName")
                objTrn.Text = module_name
                objNode.Nodes.Add(objTrn)
            End While

            objReaderModule.Close()
            Return objNode

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return Nothing
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

    End Function

    Private Function funcGetLogDetailsForModule(ByVal logId As Long) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGetLogDetailsForModule
        ' Description           :   To Show Activity Logs for the Module Clicked.
        ' Purpose               :   To Show Activity Logs for the Module Clicked.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007 
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim str_sql As String
        Dim module_id As Long
        Dim log_date As Date
        Dim objReader As OleDb.OleDbDataReader
        Dim objWait As New CWaitCursor

        '--- TO Collect Date and Module ID for the Log Selected.
        Try
            str_sql = "Select ActivityLog.ActivityDateTime ,ActivityLog.ModuleID " & _
                      "from ActivityLog where ActivityLog.ActivityLogID = " & logId & ""

            result = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook)
            If Not (result) Then
                Return False
            End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            gclsDBFunctions.GetRecords(str_sql, gOleDBConnection_LogBook, objReader)

            While objReader.Read
                log_date = Convert.ToDateTime(objReader.Item("ActivityDateTime"))
                module_id = Convert.ToInt64(objReader.Item("ModuleID"))
            End While

            objReader.Close()

            result = funcShowLogsForModule(log_date, module_id)
            If Not (result) Then
                Return False
            End If

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcShowLogsForModule(ByVal log_date As Date, ByVal module_id As Long) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcShowLogsForModule
        ' Description           :   To Show Logs Details for the Module Clicked.
        ' Purpose               :   To Show Logs Details for the Module Clicked.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007 
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim str_sql As String
        Dim strFile As String
        Dim objReader As OleDb.OleDbDataReader
        Dim objWait As New CWaitCursor

        '--- TO Collect Activity Log Data.
        Try
            str_sql = "Select ActivityLog.ActivityLogID ,ActivityLog.ActivityDateTime ,ActivityLog.SessionID ,ActivityLog.UserID ,ActivityLog.ProcessName " & _
                                  "from ActivityLog where ActivityLog.ActivityDateTime = CDate('" & log_date & "') and ActivityLog.ModuleID = " & module_id & " "

            result = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook)
            If Not (result) Then
                Return False
            End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            gclsDBFunctions.GetRecords(str_sql, gOleDBConnection_LogBook, objReader)

            '--- Initialising ListViewHeading Control
            lstViewDetails.View = View.Details
            lstViewDetails.LabelEdit = False
            lstViewDetails.FullRowSelect = True
            lstViewDetails.Activation = ItemActivation.OneClick
            lstViewDetails.Sorting = SortOrder.Ascending
            lstViewDetails.MultiSelect = False
            lstViewDetails.Clear()

            'Creating ListViewItem and passing value Selected  to Constructor 
            Dim itemParent As ListViewItem

            'Adding columns Header To Control 
            lstViewDetails.Columns.Add("File", 30, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("ActivitLog ID", 0, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("User Name", 100, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("Date/Time", 150, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("Action", 100, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("Password Tried", 100, HorizontalAlignment.Left)


            While objReader.Read
                Dim dt_date As String
                Dim dtOnly_date As String
                Dim dtOnly_Time As DateTime
                Dim user_id, activitylog_id As Long
                Dim user_name, str_filelog As String
                activitylog_id = Convert.ToInt64(objReader.Item("ActivityLogID"))
                dtOnly_date = Format(objReader.Item("ActivityDateTime"), "dd MMM yyyy")
                dtOnly_Time = FormatDateTime(Convert.ToDateTime(objReader.Item("ActivityDateTime")), DateFormat.ShortTime)
                dt_date = dtOnly_date & " " & dtOnly_Time

                user_id = Convert.ToInt64(objReader.Item("UserID"))
                user_name = funcGetUserName(user_id)

                If (funcCheckFileLogExist(activitylog_id, strFile)) Then
                    str_filelog = "YES"
                Else
                    str_filelog = ""
                End If

                If str_filelog = "yes" Then
                    itemParent = New ListViewItem(str_filelog, 1)
                Else
                    itemParent = New ListViewItem(str_filelog)
                End If

                'Adding Subitems to ItemParent Object
                itemParent.SubItems.Add(CStr(objReader.Item("ActivityLogID")))
                itemParent.SubItems.Add(user_name)
                itemParent.SubItems.Add(dt_date)
                itemParent.SubItems.Add(CStr(objReader.Item("ProcessName")))

                'Adding ListviewItem(ItemParent)to ListViewDetails Control
                lstViewDetails.Items.Add(itemParent)

            End While
            objReader.Close()
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------

        End Try

    End Function

    Private Function funcShowLogsForDate(ByVal log_date As Date) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcShowLogsForDate
        ' Description           :   To Show Logs Details for all Modules on the selected Date.
        ' Purpose               :   To Show Logs Details for all Modules on the selected Date.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007 
        ' Revisions             :   
        '=====================================================================
        Dim result As Boolean
        Dim str_sql As String
        Dim strFile As String
        Dim objReader As OleDb.OleDbDataReader
        Dim dtDate As String
        Dim objWait As New CWaitCursor

        dtDate = FormatDateTime(log_date, DateFormat.ShortDate)
        '--- TO Collect Activity Log Data.
        Try

            str_sql = "select ActivityLog.ActivityLogID, ActivityLog.ActivityDateTime, ActivityLog.SessionID, ActivityLog.ModuleID, ActivityLog.UserID, ActivityLog.ProcessName, Modules.ModuleName, ActivityLog.PasswordTried " & _
                      "from ActivityLog INNER JOIN Modules ON ActivityLog.ModuleID = Modules.ModuleID " & _
                      "WHERE ActivityLog.ActivityDateTime  like  '" & dtDate & "%' and ActivityLog.ModuleID = Modules.ModuleID "

            '--- Calling function to get Records. 
            gclsDBFunctions.GetRecords(str_sql, gOleDBConnection_LogBook, objReader)

            '--- Initialising ListViewHeading Control
            lstViewDetails.View = View.Details
            lstViewDetails.LabelEdit = False
            lstViewDetails.FullRowSelect = True
            lstViewDetails.Activation = ItemActivation.OneClick
            lstViewDetails.Sorting = SortOrder.Ascending
            lstViewDetails.MultiSelect = False
            lstViewDetails.Clear()

            'Creating ListViewItem and passing value Selected  to Constructor 
            Dim itemParent As ListViewItem

            'Adding columns Header To Control 
            lstViewDetails.Columns.Add("File", 50, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("ActivityLog ID", 0, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("User Name", 100, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("Date/Time", 150, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("Action", 100, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("Mode Name", 100, HorizontalAlignment.Left)
            lstViewDetails.Columns.Add("Password Tried", 100, HorizontalAlignment.Left)


            While objReader.Read
                Dim dt_date As String
                Dim dtOnly_date As String
                Dim dtOnly_Time As DateTime
                Dim user_id, activitylog_id As Long
                Dim user_name, str_filelog As String
                Dim password_tried As String

                gobjCommProtocol.mobjCommdll.subTime_Delay(1)

                activitylog_id = Convert.ToInt64(objReader.Item("ActivitylogID"))

                dtOnly_date = Format(objReader.Item("ActivityDateTime"), "MMM dd yyyy")
                dtOnly_Time = FormatDateTime(Convert.ToDateTime(objReader.Item("ActivityDateTime")), DateFormat.ShortTime)
                dt_date = dtOnly_date & " " & dtOnly_Time

                user_id = Convert.ToInt64(objReader.Item("UserID"))
                user_name = funcGetUserName(user_id)


                If (funcCheckFileLogExist(activitylog_id, strFile)) Then
                    str_filelog = "YES"
                Else
                    str_filelog = ""
                End If

                If str_filelog = "YES" Then
                    str_filelog = ""
                    itemParent = New ListViewItem(str_filelog, 0)
                Else
                    itemParent = New ListViewItem(str_filelog)
                End If


                'Adding Subitems to ItemParent Object
                itemParent.SubItems.Add(CStr(objReader.Item("ActivityLogID")))
                itemParent.SubItems.Add(user_name)
                itemParent.SubItems.Add(dt_date)
                itemParent.SubItems.Add(CStr(objReader.Item("ProcessName")))
                itemParent.SubItems.Add(CStr(objReader.Item("ModuleName")))
                If IsDBNull(objReader.Item("PasswordTried")) Then
                Else
                    itemParent.SubItems.Add(CStr(objReader.Item("PasswordTried")))
                End If

                lstViewDetails.Items.Add(itemParent)
            End While

            objReader.Close()

            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
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

    End Function

    Private Function funcGetModuleName(ByVal module_id As Long) As String
        '=====================================================================
        ' Procedure Name        :   funcGetModuleName
        ' Description           :   To Get Module Name from Database for the module id given.
        ' Purpose               :   To Get Module Name from Database for the module id given.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim str_sql, module_name As String
        Dim objOledbConnection As OleDbConnection
        Dim objReader As OleDb.OleDbDataReader
        Dim objWait As New CWaitCursor
        Try
            'objOledbConnection = New OleDbConnection(mstrConnectionString)
            objOledbConnection = gOleDBConnection_LogBook

            str_sql = "Select ModuleName " & _
                      "from Modules where ModuleID = " & module_id & ""

            result = gclsDBFunctions.OpenConnection(objOledbConnection)
            If Not (result) Then
                Return module_name
            End If

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            gclsDBFunctions.GetRecords(str_sql, objOledbConnection, objReader)

            While objReader.Read
                module_name = CStr(objReader.Item("ModuleName"))
            End While

            objReader.Close()
            'objOledbConnection = Nothing

            Return module_name

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return ""
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

    End Function

    Private Function funcGetMaxActivityDate() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGetMaxActivityDate
        ' Description           :   To Get the Maximum Activity Log Date.
        ' Purpose               :   To Get the Maximum Activity Log Date.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim str_sql As String
        Dim objOledbConnection As OleDbConnection
        Dim objReader As OleDbDataReader
        Dim objWait As New CWaitCursor
        Try
            'objOledbConnection = New OleDbConnection(mstrConnectionString)
            objOledbConnection = gOleDBConnection_LogBook

            '--- Generating dynamic query for selection. 
            str_sql = "Select max(ActivityLog.ActivityDateTime) " & _
                      "from ActivityLog "

            result = gclsDBFunctions.OpenConnection(objOledbConnection)
            If Not (result) Then
                Return False
            End If

            gclsDBFunctions.GetRecords(str_sql, objOledbConnection, objReader)

            While objReader.Read
                Dim l_date As Date
                If Not IsDBNull(objReader.Item(0)) Then
                    l_date = CDate(objReader.Item(0))

                    mdtActivityMaxDt = l_date
                Else
                    Return False
                End If
            End While
            objReader.Close()

            Return True
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

    End Function

    Private Function funcGetActivityDateRange(ByVal intCondition As Integer) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcGetActivityDateRange
        ' Description           :   To Get the Date Range of Activity Logs.
        ' Purpose               :   To Get the Date Range of Activity Logs.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007
        ' Revisions             : 
        '=====================================================================
        Dim interval As New TimeSpan(7, 0, 0, 0)
        Dim objWait As New CWaitCursor
        Try
            Select Case intCondition
                Case ENUM_RecordsReqd.InitialValues
                    mdtActivityEndDt = mdtActivityMaxDt
                    mdtActivityStartDt = mdtActivityMaxDt.Subtract(interval)

                Case ENUM_RecordsReqd.PreviousValues
                    mdtActivityEndDt = mdtActivityStartDt
                    mdtActivityStartDt = mdtActivityStartDt.Subtract(interval)

                Case ENUM_RecordsReqd.NextValues
                    mdtActivityStartDt = mdtActivityEndDt
                    mdtActivityEndDt = mdtActivityEndDt.Add(interval)

                    If (mdtActivityEndDt >= mdtActivityMaxDt) Then
                        mdtActivityEndDt = mdtActivityMaxDt
                        mdtActivityStartDt = mdtActivityMaxDt.Subtract(interval)
                    End If
            End Select

            lblDateRange.Text = "Date: " & Format(mdtActivityStartDt, "MMM dd yyyy") & " To " & Format(mdtActivityEndDt, "MMM dd yyyy")

            Return True
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

    End Function

    Private Function funcGetUserName(ByVal user_id As Long) As String
        '=====================================================================
        ' Procedure Name        :   funcGetUserName
        ' Description           :   To Get User Name from Database for the user id given.
        ' Purpose               :   To Get User Name from Database for the user id given.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007
        ' Revisions             :
        '=====================================================================
        Dim result As Boolean
        Dim str_sql, user_name As String
        Dim objReader As OleDbDataReader
        Dim objWait As New CWaitCursor

        Try

            str_sql = "Select UserName " & _
                      "from Users where UserID = " & user_id & ""

            '--- Calling gfuncGetRecords to Get myreader populated with provided Query( strsqlServiceComments (Global String) Records
            gclsDBFunctions.GetRecords(str_sql, gOleDBUserInfoConnection, objReader)

            While objReader.Read
                user_name = CStr(objReader.Item("UserName"))
            End While

            objReader.Close()

            Return user_name
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            Return ""
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

    End Function

    Private Function funcCheckFileLogExist(ByVal activitylog_id As Long, ByRef strInFileName As String) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcCheckFileLogExist
        ' Description           :   To check whether File Log Record exists.
        ' Purpose               :   To check whether File Log Record exists.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007
        ' Revisions             :
        '=====================================================================
        Dim objReader As OleDbDataReader
        Dim str_sql As String
        Dim intNoOfRecords As Long
        Dim record_exists As Boolean
        Dim str_connection As String
        Dim objOledbFileConnection As OleDbConnection
        Dim objWait As New CWaitCursor

        Try
            '--- Passing database name to clsstrConnString property
            str_connection = gclsDBFunctions.ConnectionString(CONSTSTR_LOGERRORDATABASENAME)
            objOledbFileConnection = New OleDbConnection(str_connection)

            If (gclsDBFunctions.OpenConnection(objOledbFileConnection) = False) Then
                Return False
            End If

            str_sql = "select * from FileLog where FileLog.ActivityLogID =" & activitylog_id & ""

            record_exists = gclsDBFunctions.GetRecords(str_sql, objOledbFileConnection, objReader)

            If objReader.HasRows = False Then
                strInFileName = ""
                objReader.Close()
                Return False
            Else
                While objReader.Read
                    strInFileName = objReader.Item("FileName")
                End While

                objReader.Close()

            End If

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------

        End Try

    End Function

    Private Function funcGetFileLogFilePath(ByVal activitylog_id) As String
        '=====================================================================
        ' Procedure Name        :   funcGetFileLogFilePath
        ' Description           :   To get saved File Path.
        ' Purpose               :   To get saved File Path.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007
        ' Revisions             :
        '=====================================================================
        Dim objReader As OleDbDataReader
        Dim str_sql, strFilePath As String
        Dim record_exists As Boolean
        Dim str_connection As String
        Dim objOledbConnection As OleDbConnection
        Dim objWait As New CWaitCursor

        Try
            '--- Passing database name to clsstrConnString property
            str_connection = gclsDBFunctions.ConnectionString(CONSTSTR_LOGERRORDATABASENAME)
            objOledbConnection = New OleDbConnection(str_connection)

            If (gclsDBFunctions.OpenConnection(objOledbConnection) = False) Then
                Return False
            End If

            str_sql = "select FilePath from FileLog where FileLog.ActivityLogID =" & activitylog_id & ""

            gclsDBFunctions.GetRecords(str_sql, objOledbConnection, objReader)

            While objReader.Read
                strFilePath = CStr(objReader.Item("FilePath"))
            End While

            objReader.Close()

            Return strFilePath

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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Sub lstViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstViewDetails.Click
        '=====================================================================
        ' Procedure Name        : lstViewDetails_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : List view to show the dates on which log was created.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim strFileName_Show As String
        Dim objlistItem As New ListViewItem
        Dim lngActivityID As Long
        Dim objWait As New CWaitCursor
        Try
            lstViewDetails.MultiSelect = True
            objlistItem = lstViewDetails.SelectedItems.Item(0)
            lngActivityID = CLng(objlistItem.SubItems(1).Text)
            If (funcCheckFileLogExist(lngActivityID, strFileName_Show)) Then
                StatusBarPanel1.Text = strFileName_Show
                tlbrActivitylog.Buttons.Item(EnumToolBarButtons.FileRetrieve).ImageIndex = EnumImageIndex.EnableFileRetrieve
            Else
                StatusBarPanel1.Text = strFileName_Show
                tlbrActivitylog.Buttons.Item(EnumToolBarButtons.FileRetrieve).ImageIndex = EnumImageIndex.DisableFileRetrieve
            End If
            objlistItem = Nothing
            lstViewDetails.Refresh()

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

#Region "Global Functions"

    '--------------------------------------------------------
    '    Global functions used to insert into Activity Log and File Log.
    '--- funcInsertActivityLog - To Add / Insert a record in Activity Log table.
    '--- funcInsertFileLog - To Add / Insert a record in File Log table.

    Private Function funcInsertActivityLog(ByVal Session_ID As Long, ByVal User_ID As Long, ByVal Module_ID As Long, ByVal Log_desc As String) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcInsertActivityLog
        ' Description           :   To Add / Insert a record in Activity Log table.
        ' Purpose               :   To Add / Insert a record in Activity Log table.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007
        ' Revisions             :
        '=====================================================================
        Dim str_sql As String
        Dim Status As Boolean
        Dim objcommand As New OleDbCommand
        Dim Log_ID As Long
        Dim objWait As New CWaitCursor
        Try
            Status = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook)
            If Not (Status) Then
                Return False
            End If

            Log_ID = gclsDBFunctions.GetNextID("ActivityLog", "ActivityLogID", gOleDBConnection_LogBook)

            str_sql = "Insert into ActivityLog " & _
                      "(ActivityLogID ,SessionID ,ActivityDateTime ,UserID ,ProcessName ,ModuleID)" & _
                      " values(?,?,?,?,?,?)"

            '--- Providing command object for Infomaster
            With objcommand
                .Connection = gOleDBConnection_LogBook
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("ActivityLogID", OleDbType.BigInt).Value = Log_ID
                .Parameters.Add("SessionID", OleDbType.BigInt).Value = Session_ID
                .Parameters.Add("ActivityDateTime", OleDbType.Date).Value = DateTime.Now
                .Parameters.Add("UserID", OleDbType.BigInt).Value = User_ID
                .Parameters.Add("ProcessName", OleDbType.LongVarChar).Value = Log_desc
                .Parameters.Add("ModuleID", OleDbType.BigInt).Value = Module_ID
                .ExecuteNonQuery()
            End With

            objcommand.Dispose()
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try


    End Function

    Private Function funcInsertFileLog(ByVal ActivityLog_ID As Long, ByVal file_name As String, ByVal file_data As Object) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcInsertFileLog
        ' Description           :   To Add / Insert a record in File Log table.
        ' Purpose               :   To Add / Insert a record in File Log table.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Saurabh S.
        ' Created               :   05-01-2007
        ' Revisions             :
        '=====================================================================
        Dim str_sql As String
        Dim Status As Boolean
        Dim objcommand As New OleDbCommand
        Dim FileLog_ID As Long
        Dim objWait As New CWaitCursor
        Try
            Status = gclsDBFunctions.OpenConnection(gOleDBConnection_LogBook)
            If Not (Status) Then
                Return False
            End If

            FileLog_ID = gclsDBFunctions.GetNextID("FileLogID", "FileLog", gOleDBConnection_LogBook)

            str_sql = "Insert into FileLog " & _
                      "(FileLogID ,ActivityLogID ,FileName ,FilePath )" & _
                      " values(?,?,?,?)"

            '--- Providing command object for Infomaster
            With objcommand
                .Connection = gOleDBConnection_LogBook
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Parameters.Add("FileLogID", OleDbType.BigInt).Value = FileLog_ID
                .Parameters.Add("ActivityLogID", OleDbType.BigInt).Value = ActivityLog_ID
                .Parameters.Add("FileName", OleDbType.LongVarWChar).Value = file_name
                .Parameters.Add("FilePath", OleDbType.LongVarWChar).Value = file_data
                .ExecuteNonQuery()
            End With

            objcommand.Dispose()
            Return True

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

    End Function

#End Region

#Region " String/Byte Array conversion code "

    Private Function funcStringToByte(ByVal szString As String) As Byte()
        '=====================================================================
        ' Procedure Name        : funcStringToByte
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To convert String to Byte.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim i As Integer
        Dim btRet(szString.Length - 1) As Byte

        Try
            If szString.Length = 0 Then
                Exit Function
            End If

            For i = 0 To szString.Length - 1
                btRet(i) = Asc(szString.Chars(i))
            Next
            Return btRet

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
    End Function

    Private Function funcByteToString(ByVal btBytes() As Byte) As String
        '=====================================================================
        ' Procedure Name        : funcByteToString
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To convert the passed Bytes to String.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim szRet As String
        Dim i As Integer
        Try
            For i = LBound(btBytes) To UBound(btBytes)
                szRet = szRet & Chr(btBytes(i))
            Next
            Return szRet

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
    End Function

#End Region

#Region " Toolbar"

    Private Sub tlbrActivitylog_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbrActivitylog.ButtonClick
        '=====================================================================
        ' Procedure Name        : tlbrActivitylog_ButtonClick
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To initialise the buttons on Toolbar.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            If e.Button.ImageIndex > 4 Then
                Exit Sub
            End If

            Select Case UCase(e.Button.Tag)

                Case UCase("Next")
                    Call subNextDates()

                Case UCase("Previous")
                    Call subPreviousDates()

                Case UCase("FileRetrieve")
                    Call subFileRetrieve()

                Case UCase("Close")
                    Me.Close()
            End Select

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

    Private Sub subFileRetrieve()
        '=====================================================================
        ' Procedure Name        : subFileRetrieve
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To retrieve the encrypted file.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Dim objlistItem As ListViewItem
        objlistItem = lstViewDetails.SelectedItems.Item(0)
        Dim lngActivityID As Long = CInt(objlistItem.SubItems(1).Text)
        Dim objsfd As New SaveFileDialog
        Dim strPath As String = Application.StartupPath
        Dim strOrgFilePath As String = funcGetFileLogFilePath(lngActivityID)
        Dim objfileinfo As New FileInfo(strOrgFilePath)
        Dim strOrgFilename As String = objfileinfo.Name
        Dim strOrgFileext As String = objfileinfo.Extension

        Try
            objlistItem = lstViewDetails.FocusedItem
            If objfileinfo.Exists = False Then
                gobjMessageAdapter.ShowMessage(constFileNotFound)
                Return
            End If

            '--- Show the save dialog to accept the file.
            objsfd.InitialDirectory = strPath
            objsfd.RestoreDirectory = True
            objsfd.Filter = "Files(*" & strOrgFileext & ")|*" & strOrgFileext
            objsfd.FileName = strOrgFilename

            If objsfd.ShowDialog() = DialogResult.OK Then
                objfileinfo.CopyTo(objsfd.FileName, True)
                gobjMessageAdapter.ShowMessage(constFileRetrievedSuccessfully)
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

    Private Sub subNextDates()
        '=====================================================================
        ' Procedure Name        : subNextDates
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To show the logs of next dates.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            funcGetActivityDateRange(ENUM_RecordsReqd.NextValues)
            lstViewDetails.Clear()
            trvLogData.Nodes.Clear()
            funcGetLogRecords()
            trvLogData.Nodes.Add(mobjTreeNode)

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

    Private Sub subPreviousDates()
        '=====================================================================
        ' Procedure Name        : subPreviousDates
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Load the data of previous date.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            funcGetActivityDateRange(ENUM_RecordsReqd.PreviousValues)
            lstViewDetails.Clear()
            trvLogData.Nodes.Clear()
            funcGetLogRecords()
            trvLogData.Nodes.Add(mobjTreeNode)

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

End Class
