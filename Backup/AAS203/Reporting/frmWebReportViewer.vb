

Public Class frmWebReportViewer
    Inherits System.Windows.Forms.Form
    '**********************************************************************
    ' File Header        
    ' File Name 		: frmWebReportViewer.vb
    ' Author			: Mangesh Shardul
    ' Date/Time			: 18-Mar-2005 8:00 pm
    ' Description		: To view the Web Enabled report in a Web Browser
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
    Friend WithEvents WebPreviewPane As AxSHDocVw.AxWebBrowser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWebReportViewer))
        Me.WebPreviewPane = New AxSHDocVw.AxWebBrowser
        CType(Me.WebPreviewPane, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebPreviewPane
        '
        Me.WebPreviewPane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebPreviewPane.Enabled = True
        Me.WebPreviewPane.Location = New System.Drawing.Point(0, 0)
        Me.WebPreviewPane.OcxState = CType(resources.GetObject("WebPreviewPane.OcxState"), System.Windows.Forms.AxHost.State)
        Me.WebPreviewPane.Size = New System.Drawing.Size(756, 361)
        Me.WebPreviewPane.TabIndex = 0
        '
        'frmWebReportViewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(756, 361)
        Me.Controls.Add(Me.WebPreviewPane)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWebReportViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Web Report Viewer"
        CType(Me.WebPreviewPane, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Constructors "

    Public Sub New(ByVal strReportFilePathIn As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mstrReportFilePath = strReportFilePathIn

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
            WebPreviewPane.Navigate(mstrReportFilePath)
            WebPreviewPane.Show()
        End Set
    End Property

#End Region

#Region " Form Load and closing Events "

    Private Sub frmWebReportViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not mstrReportFilePath = "" Then
            WebPreviewPane.Navigate(mstrReportFilePath)
            WebPreviewPane.Show()
        End If
    End Sub

    Private Sub frmWebReportViewer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ''Dim dlgRstSave As DialogResult
        ''dlgRstSave = MessageBox.Show("Do you want to save the web report?", "Save Web Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim blnIsSaveReport As Boolean

        'blnIsSaveReport = gobjMessageAdapter.ShowMessage(msgIDSaveWebReportFile)
        blnIsSaveReport = gobjMessageAdapter.ShowMessage("Do you want to save the web report?", "Save Web Report", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage)

        Application.DoEvents()

        If blnIsSaveReport = True Then
            WebPreviewPane.ExecWB(SHDocVw.OLECMDID.OLECMDID_SAVEAS, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_PROMPTUSER)
            WebPreviewPane.Hide()
        ElseIf blnIsSaveReport = False Then
            WebPreviewPane.Hide()
        End If

        
    End Sub

#End Region

End Class
