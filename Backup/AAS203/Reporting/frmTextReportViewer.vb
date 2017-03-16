Option Explicit On 

Public Class frmTextReportViewer
    Inherits System.Windows.Forms.Form
    '**********************************************************************
    ' File Header        
    ' File Name 		: frmTextReportViewer.vb
    ' Author			: Mangesh Shardul
    ' Date/Time			: 05-Apr-2005 12:00 Noon
    ' Description		: To view the Text report in a Text Editor
    '**********************************************************************

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
    Friend WithEvents txtReportText As System.Windows.Forms.TextBox
    Friend WithEvents PanelTextReport As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTextReportViewer))
        Me.txtReportText = New System.Windows.Forms.TextBox
        Me.PanelTextReport = New System.Windows.Forms.Panel
        Me.PanelTextReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtReportText
        '
        Me.txtReportText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReportText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtReportText.Location = New System.Drawing.Point(0, 0)
        Me.txtReportText.Multiline = True
        Me.txtReportText.Name = "txtReportText"
        Me.txtReportText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReportText.Size = New System.Drawing.Size(710, 353)
        Me.txtReportText.TabIndex = 0
        Me.txtReportText.Text = ""
        '
        'PanelTextReport
        '
        Me.PanelTextReport.Controls.Add(Me.txtReportText)
        Me.PanelTextReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTextReport.Location = New System.Drawing.Point(0, 0)
        Me.PanelTextReport.Name = "PanelTextReport"
        Me.PanelTextReport.Size = New System.Drawing.Size(710, 353)
        Me.PanelTextReport.TabIndex = 1
        '
        'frmTextReportViewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(710, 353)
        Me.Controls.Add(Me.PanelTextReport)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTextReportViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text Report Viewer"
        Me.PanelTextReport.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Class Variables "

    Private mstrReportFilePath As String

#End Region

#Region " Public Property "

    Public Property ReportFilePath() As String
        Get
            Return mstrReportFilePath
        End Get
        Set(ByVal Value As String)
            mstrReportFilePath = Value
        End Set
    End Property

#End Region

#Region " Form Load and closing Events "

    Private Sub frmTextReportViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fs As System.IO.FileStream

        If Not IsNothing(mstrReportFilePath) = True Then
            Dim objStream As New IO.StreamReader(mstrReportFilePath)
            txtReportText.Text = objStream.ReadToEnd

            txtReportText.Font = New Font("Lucida Console", 12, FontStyle.Regular, GraphicsUnit.Point)
            txtReportText.WordWrap = False
            txtReportText.ScrollBars = ScrollBars.Both

            objStream.Close()
            objStream = Nothing
        End If

    End Sub

    Private Sub frmTextReportViewer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim blnIsSaveReport As Boolean
        'Dim cWait As CWaitCursor

        'blnIsSaveReport = gobjMessageAdapter.ShowMessage(msgIDSaveTextReportFile)
        blnIsSaveReport = gobjMessageAdapter.ShowMessage("Do you want to save the text report?", "Save Text Report", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage)
        Application.DoEvents()
        'cWait = New CWaitCursor
        If blnIsSaveReport = True Then
            Dim objSaveFileDlg As New SaveFileDialog

            objSaveFileDlg.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*"
           
            If objSaveFileDlg.ShowDialog = DialogResult.OK Then
                Dim objStreamWriter As IO.StreamWriter
                objStreamWriter = New IO.StreamWriter(objSaveFileDlg.FileName)
                objStreamWriter.Write(txtReportText.Text)
                objStreamWriter.Close()
                objStreamWriter = Nothing
            Else
                objSaveFileDlg.Dispose()
            End If

            'If Not cWait Is Nothing Then
            '    cWait.Dispose()
            'End If

        ElseIf blnIsSaveReport = False Then
        End If

        'If Not cWait Is Nothing Then
        '    cWait.Dispose()
        'End If
    End Sub

#End Region

End Class
