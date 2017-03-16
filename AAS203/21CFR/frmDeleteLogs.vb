Option Explicit On 
Imports AAS203.Common
Imports System.Data
Imports System.Data.OleDb
Imports System.IO


Public Class frmDeleteLogs
    Inherits System.Windows.Forms.Form

#Region "Module level Declarations "
    Private mstrConnectionString As String
    Private mclsDBFunctions As New clsDatabaseFunctions()
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
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents datetimepickTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblToDate As System.Windows.Forms.Label
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents cmdOK As NETXP.Controls.XPButton
    Friend WithEvents cmdCancel As NETXP.Controls.XPButton
    Friend WithEvents datetimepickFrom1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents datetimepickFrom As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDeleteLogs))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.datetimepickTo = New System.Windows.Forms.DateTimePicker
        Me.lblToDate = New System.Windows.Forms.Label
        Me.datetimepickFrom1 = New System.Windows.Forms.DateTimePicker
        Me.lblFromDate = New System.Windows.Forms.Label
        Me.cmdOK = New NETXP.Controls.XPButton
        Me.cmdCancel = New NETXP.Controls.XPButton
        Me.datetimepickFrom = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Gray
        Me.PictureBox2.Location = New System.Drawing.Point(72, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(270, 2)
        Me.PictureBox2.TabIndex = 31
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'datetimepickTo
        '
        Me.datetimepickTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.datetimepickTo.CustomFormat = "dd - MMM - yyyy"
        Me.datetimepickTo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datetimepickTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datetimepickTo.Location = New System.Drawing.Point(208, 80)
        Me.datetimepickTo.Name = "datetimepickTo"
        Me.datetimepickTo.Size = New System.Drawing.Size(134, 21)
        Me.datetimepickTo.TabIndex = 34
        '
        'lblToDate
        '
        Me.lblToDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToDate.Location = New System.Drawing.Point(137, 82)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(64, 20)
        Me.lblToDate.TabIndex = 35
        Me.lblToDate.Text = "To Date :"
        Me.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'datetimepickFrom1
        '
        Me.datetimepickFrom1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.datetimepickFrom1.CustomFormat = "dd - MMM - yyyy"
        Me.datetimepickFrom1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datetimepickFrom1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datetimepickFrom1.Location = New System.Drawing.Point(8, 136)
        Me.datetimepickFrom1.Name = "datetimepickFrom1"
        Me.datetimepickFrom1.Size = New System.Drawing.Size(32, 21)
        Me.datetimepickFrom1.TabIndex = 32
        Me.datetimepickFrom1.Value = New Date(2009, 1, 2, 16, 38, 0, 0)
        Me.datetimepickFrom1.Visible = False
        '
        'lblFromDate
        '
        Me.lblFromDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFromDate.Location = New System.Drawing.Point(118, 44)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(83, 16)
        Me.lblFromDate.TabIndex = 33
        Me.lblFromDate.Text = "From Date :"
        Me.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdOK
        '
        Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(130, 120)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(100, 34)
        Me.cmdOK.TabIndex = 36
        Me.cmdOK.Text = "&Delete"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(240, 120)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 34)
        Me.cmdCancel.TabIndex = 37
        Me.cmdCancel.Text = "&Cancel"
        '
        'datetimepickFrom
        '
        Me.datetimepickFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.datetimepickFrom.CustomFormat = "dd - MMM - yyyy"
        Me.datetimepickFrom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datetimepickFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datetimepickFrom.Location = New System.Drawing.Point(208, 42)
        Me.datetimepickFrom.Name = "datetimepickFrom"
        Me.datetimepickFrom.Size = New System.Drawing.Size(134, 21)
        Me.datetimepickFrom.TabIndex = 38
        '
        'frmDeleteLogs
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(346, 167)
        Me.Controls.Add(Me.datetimepickFrom)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.datetimepickTo)
        Me.Controls.Add(Me.lblToDate)
        Me.Controls.Add(Me.datetimepickFrom1)
        Me.Controls.Add(Me.lblFromDate)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeleteLogs"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delete Logs"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Form Events"

    Private Sub frmDeleteLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmDeleteLogs_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the Delete Logs form.
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

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmdCancel_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To close the Delete Logs form.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmdOK_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To delete the logs between the selected date.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor

        Try
            If funcDeleteLogRecords() Then
                gobjMessageAdapter.ShowMessage(constLogDeletedSuccessfully)
            End If
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
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

#End Region

#Region "Private functions"

    '--------------------------------------------------------
    '    General functions used for Log Deletion.
    '--- funcInitialize  - To Initialize the form and show by default date as today.
    '--- funcDeleteLogRecords - To ask user for sure deletion and call a function to delete records from the database.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitialize
        ' Description           :   To Initialize the form and show by default date as today.
        ' Purpose               :   To Initialize the form and show by default date as today.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitcursor
        Try
            '--- Passing database name to clsstrConnString property
            mstrConnectionString = mclsDBFunctions.ConnectionString(CONSTSTR_LOGERRORDATABASENAME)

            '--- Passing connection string to Connection Object
            gOleDBConnection_LogBook = New OleDbConnection(mstrConnectionString)

            '--- To Set the CustomFormat string for Date.
            datetimepickFrom.CustomFormat = "dd-MMM-yyyy"
            datetimepickFrom.Format = DateTimePickerFormat.Custom
            datetimepickTo.CustomFormat = "dd-MMM-yyyy"
            datetimepickTo.Format = DateTimePickerFormat.Custom

            AddHandler cmdOK.Click, AddressOf cmdOK_Click
            AddHandler cmdCancel.Click, AddressOf cmdCancel_Click


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

    Private Function funcDeleteLogRecords() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcDeleteLogRecords
        ' Description           :   To ask user for sure deletion and call a function to delete records from the database.
        ' Purpose               :   To ask user for sure deletion and call a function to delete records from the database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :   Nilesh Shirode June 16 2004
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim fromdate, todate As Date
        Dim str_GetFileNamesql As String
        Dim str_DeleteFileSql As String
        Dim delete_result As Boolean
        Dim objReader As OleDbDataReader


        Dim objDataTable As New DataTable
        Dim objColumn As DataColumn
        Dim objRow As DataRow
        Dim intRowCount As Integer

        Dim str_DeleteFilePath As String
        Dim str_DeleteFileRecord As String
        Dim lng_ActivityLogID As String

        Try
            funcDeleteLogRecords = False
            If (gobjMessageAdapter.ShowMessage(constDeleteLogs) = True) Then

                fromdate = datetimepickFrom.Value
                todate = datetimepickTo.Value

                str_GetFileNamesql = "Select FileLog.FilePath,ActivityLog.ActivityLogID " & _
                      "From ActivityLog,FileLog " & _
                      "Where ActivityLog.ActivityLogID = FileLog.ActivityLogID And ActivityLog.ActivityDateTime between " & _
                      "#" & FormatDateTime(fromdate.AddDays(-1), DateFormat.ShortDate) & "#" & " And " & _
                      "#" & FormatDateTime(todate.AddDays(1), DateFormat.ShortDate) & "# " & _
                      "Order by ActivityDateTime Desc "

                '--- Add columns to the datatabel
                objColumn = New DataColumn("FilePath")
                objDataTable.Columns.Add(objColumn)
                objColumn = New DataColumn("ActivityLogID")
                objDataTable.Columns.Add(objColumn)

                objReader = mclsDBFunctions.GetRecords(str_GetFileNamesql, gOleDBConnection_LogBook)

                While objReader.Read
                    str_DeleteFilePath = objReader.Item("FilePath")
                    lng_ActivityLogID = objReader.Item("ActivityLogID")

                    If File.Exists(str_DeleteFilePath) = True Then
                        File.Delete(str_DeleteFilePath)
                    End If

                    objRow = objDataTable.NewRow

                    '--- Add the datarows to  the tabel
                    objRow.Item("FilePath") = str_DeleteFilePath
                    objRow.Item("ActivityLogID") = lng_ActivityLogID

                    objDataTable.Rows.Add(objRow)

                    'objReader.NextResult()
                    objRow = Nothing
                End While
                objReader.Close()

                For intRowCount = 0 To objDataTable.Rows.Count - 1
                    lng_ActivityLogID = objDataTable.Rows.Item(intRowCount).Item("ActivityLogID")

                    str_DeleteFileSql = "Delete " & _
                                        "From ActivityLog " & _
                                        "Where ActivityLog.ActivityLogID = " & lng_ActivityLogID & ""

                    If Not mclsDBFunctions.AddORDeleteRecord(str_DeleteFileSql, gOleDBConnection_LogBook) Then
                        Throw New Exception("Records Not Deleted")
                    End If

                    str_DeleteFileSql = "Delete " & _
                                        "From FileLog " & _
                                        "Where FileLog.ActivityLogID = " & lng_ActivityLogID & ""

                    If Not mclsDBFunctions.AddORDeleteRecord(str_DeleteFileSql, gOleDBConnection_LogBook) Then
                        Throw New Exception("Records Not Deleted")
                    End If
                Next
                funcDeleteLogs()
                objDataTable.Dispose()
                funcDeleteLogRecords = True
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

    End Function
    Private Function funcDeleteLogs() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcDeleteLogRecords
        ' Description           :   To ask user for sure deletion and call a function to delete records from the database.
        ' Purpose               :   To ask user for sure deletion and call a function to delete records from the database.
        ' Parameters Passed     :   None.
        ' Returns               :   success flag.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :  Pankaj Bamb
        ' Created               :  23 May , 2007 
        ' Revisions             :  
        '=====================================================================

        Dim fromdate, todate As Date
        Dim str_DeleteFileSql As String
        Dim delete_result As Boolean
        
        Try
            funcDeleteLogs = False

            fromdate = datetimepickFrom.Value
            todate = datetimepickTo.Value

            str_DeleteFileSql = "Delete * " & _
                  "From ActivityLog " & _
                  "Where ActivityLog.ActivityDateTime between " & _
                  "#" & FormatDateTime(CDate(fromdate.ToShortDateString()).AddMilliseconds(1), DateFormat.GeneralDate) & "#" & " And " & _
                  "#" & FormatDateTime(CDate(todate.ToShortDateString()).AddDays(1).AddMilliseconds(-1), DateFormat.GeneralDate) & "# " & _
                  " "
            If Not mclsDBFunctions.AddORDeleteRecord(str_DeleteFileSql, gOleDBConnection_LogBook) Then
                Throw New Exception("Records Not Deleted")
            End If

            funcDeleteLogs = True

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

#End Region

End Class
