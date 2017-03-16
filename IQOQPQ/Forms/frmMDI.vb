
Option Explicit On 
Imports System
Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Imports vbAccelerator
Imports vbAccelerator.Components.ListBarControl

'''Imports CrystalDecisions.CrystalReports.Engine
'''Imports CrystalDecisions.Shared


Public Class frmMDI
    Inherits System.Windows.Forms.Form

#Region " Module level Declarations "

    Private Const CONST_Use_TreeView = 1
    Private Const CONST_ModeLock = 0
    Private Const CONST_ModeUnLock = 7
    Dim AppObject As Application
    Private Const CONST_RecordID = 1
    Private strPath As IO.Directory

    Public objPrintDialog As New PrintDialog

    Private WithEvents mfrmPQTest2 As New frmPQTest2    'Saurabh 04.07.07
    Public Event Test_IQOQPQ_Attachment1(ByRef dtParameters As DataTable, ByVal intCounter As Integer)    'Saurabh 04.07.07

    Private WithEvents mfrmPQTest3 As New frmPQTest3    'Saurabh 07.07.07
    Public Event Test_IQOQPQ_AttachmentII(ByRef dtParameters As DataTable, ByVal intCounter As Integer)    'Saurabh 07.07.07

    Private WithEvents mfrmPQTest4 As New frmPQTest4    'Saurabh 09.07.07
    Public Event Test_IQOQPQ_AttachmentIII(ByRef dtParameters As DataTable, ByVal intCounter As Integer)    'Saurabh 09.07.07

    Public Event InstrumentType(ByRef strInstrumentType As String)  'Saurabh 30.07.07

    Private Enum enumToolBarButtons
        tlbtnLock = 0
        tlbtnUnlock = 1
        tlbtnNext = 4
        tlbtnPrevious = 2
        tlbrPrint = 6
        tlbrPrintAll = 7
        tlbrExport = 8
        tlbtnExit = 10
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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents stsdQualification As System.Windows.Forms.StatusBar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tlbrIQOQPQ As System.Windows.Forms.ToolBar
    Friend WithEvents tlbtnLock As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlbtnUnlock As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlbtnPrevious As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlbtnNext As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlbtnReturn As System.Windows.Forms.ToolBarButton
    Friend WithEvents tvwIQOQPQ As System.Windows.Forms.TreeView
    Friend WithEvents lstbarIQOQPQ As vbAccelerator.Components.ListBarControl.ListBar
    Friend WithEvents tvwSplitter As System.Windows.Forms.Splitter
    Friend WithEvents tlbrPrint As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlbrPrintAll As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents tlbrExport As System.Windows.Forms.ToolBarButton
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuIQMode As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOQMode As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPQMode As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLock As System.Windows.Forms.MenuItem
    Friend WithEvents mnuUnlock As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNext As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPrevious As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPrintAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExport As System.Windows.Forms.MenuItem
    Friend WithEvents VsNetMenuProvider As vbWindowsUI.VSNetMenuProvider
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDI))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuIQMode = New System.Windows.Forms.MenuItem()
        Me.mnuOQMode = New System.Windows.Forms.MenuItem()
        Me.mnuPQMode = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.mnuLock = New System.Windows.Forms.MenuItem()
        Me.mnuUnlock = New System.Windows.Forms.MenuItem()
        Me.mnuNext = New System.Windows.Forms.MenuItem()
        Me.mnuPrevious = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuEdit = New System.Windows.Forms.MenuItem()
        Me.mnuPrint = New System.Windows.Forms.MenuItem()
        Me.mnuPrintAll = New System.Windows.Forms.MenuItem()
        Me.MenuItem14 = New System.Windows.Forms.MenuItem()
        Me.mnuExport = New System.Windows.Forms.MenuItem()
        Me.stsdQualification = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tlbrIQOQPQ = New System.Windows.Forms.ToolBar()
        Me.tlbtnLock = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
        Me.tlbtnPrevious = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton5 = New System.Windows.Forms.ToolBarButton()
        Me.tlbtnNext = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton6 = New System.Windows.Forms.ToolBarButton()
        Me.tlbrPrint = New System.Windows.Forms.ToolBarButton()
        Me.tlbrPrintAll = New System.Windows.Forms.ToolBarButton()
        Me.tlbrExport = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.tlbtnReturn = New System.Windows.Forms.ToolBarButton()
        Me.tlbtnUnlock = New System.Windows.Forms.ToolBarButton()
        Me.tvwIQOQPQ = New System.Windows.Forms.TreeView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.lstbarIQOQPQ = New vbAccelerator.Components.ListBarControl.ListBar()
        Me.tvwSplitter = New System.Windows.Forms.Splitter()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.VsNetMenuProvider = New vbWindowsUI.VSNetMenuProvider(Me.components)
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuEdit, Me.mnuUnlock})
        '
        'mnuFile
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuFile, -1)
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuIQMode, Me.mnuOQMode, Me.mnuPQMode, Me.MenuItem5, Me.mnuLock, Me.mnuUnlock, Me.mnuNext, Me.mnuPrevious, Me.MenuItem10, Me.mnuExit})
        Me.mnuFile.OwnerDraw = True
        Me.mnuFile.Text = "&File"
        '
        'mnuIQMode
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuIQMode, 20)
        Me.mnuIQMode.Index = 0
        Me.mnuIQMode.OwnerDraw = True
        Me.mnuIQMode.RadioCheck = True
        Me.mnuIQMode.Text = "&Installation Qualification"
        '
        'mnuOQMode
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuOQMode, 21)
        Me.mnuOQMode.Index = 1
        Me.mnuOQMode.OwnerDraw = True
        Me.mnuOQMode.RadioCheck = True
        Me.mnuOQMode.Text = "&Operational Qualification"
        '
        'mnuPQMode
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuPQMode, 22)
        Me.mnuPQMode.Index = 2
        Me.mnuPQMode.OwnerDraw = True
        Me.mnuPQMode.RadioCheck = True
        Me.mnuPQMode.Text = "Performance &Qualification"
        '
        'MenuItem5
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.MenuItem5, -1)
        Me.MenuItem5.Index = 3
        Me.MenuItem5.OwnerDraw = True
        Me.MenuItem5.Text = "-"
        '
        'mnuLock
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuLock, -1)
        Me.mnuLock.Index = 4
        Me.mnuLock.OwnerDraw = True
        Me.mnuLock.Text = ""
        '
        'mnuUnlock
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuUnlock, 19)
        Me.mnuUnlock.Index = 5
        Me.mnuUnlock.OwnerDraw = True
        Me.mnuUnlock.Shortcut = System.Windows.Forms.Shortcut.CtrlQ
        Me.mnuUnlock.Text = "&UnLock"
        '
        'mnuNext
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuNext, 16)
        Me.mnuNext.Index = 6
        Me.mnuNext.OwnerDraw = True
        Me.mnuNext.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.mnuNext.Text = "&Next"
        '
        'mnuPrevious
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuPrevious, 15)
        Me.mnuPrevious.Index = 7
        Me.mnuPrevious.OwnerDraw = True
        Me.mnuPrevious.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.mnuPrevious.Text = "&Previous"
        '
        'MenuItem10
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.MenuItem10, -1)
        Me.MenuItem10.Index = 8
        Me.MenuItem10.OwnerDraw = True
        Me.MenuItem10.Text = "-"
        '
        'mnuExit
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuExit, 19)
        Me.mnuExit.Index = 9
        Me.mnuExit.OwnerDraw = True
        Me.mnuExit.Text = "E&xit"
        '
        'mnuEdit
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuEdit, 1)
        Me.mnuEdit.Index = 1
        Me.mnuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuPrint, Me.mnuPrintAll, Me.MenuItem14, Me.mnuExport})
        Me.mnuEdit.OwnerDraw = True
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuPrint
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuPrint, -1)
        Me.mnuPrint.Index = 0
        Me.mnuPrint.OwnerDraw = True
        Me.mnuPrint.Text = "&Print"
        Me.mnuPrint.Visible = False
        '
        'mnuPrintAll
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuPrintAll, 13)
        Me.mnuPrintAll.Index = 1
        Me.mnuPrintAll.OwnerDraw = True
        Me.mnuPrintAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mnuPrintAll.Text = "Print&All"
        '
        'MenuItem14
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.MenuItem14, -1)
        Me.MenuItem14.Index = 2
        Me.MenuItem14.OwnerDraw = True
        Me.MenuItem14.Text = "-"
        '
        'mnuExport
        '
        Me.VsNetMenuProvider.SetImageIndex(Me.mnuExport, 18)
        Me.mnuExport.Index = 3
        Me.mnuExport.OwnerDraw = True
        Me.mnuExport.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.mnuExport.Text = "&Export"
        '
        'stsdQualification
        '
        Me.stsdQualification.Location = New System.Drawing.Point(0, 501)
        Me.stsdQualification.Name = "stsdQualification"
        Me.stsdQualification.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.stsdQualification.ShowPanels = True
        Me.stsdQualification.Size = New System.Drawing.Size(804, 24)
        Me.stsdQualification.TabIndex = 8
        Me.stsdQualification.Text = "StatusBar1"
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Icon = CType(resources.GetObject("StatusBarPanel1.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Text = "Displays Extra Information"
        Me.StatusBarPanel1.Width = 800
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        Me.ImageList1.Images.SetKeyName(12, "")
        Me.ImageList1.Images.SetKeyName(13, "")
        Me.ImageList1.Images.SetKeyName(14, "")
        Me.ImageList1.Images.SetKeyName(15, "")
        Me.ImageList1.Images.SetKeyName(16, "")
        Me.ImageList1.Images.SetKeyName(17, "")
        Me.ImageList1.Images.SetKeyName(18, "")
        Me.ImageList1.Images.SetKeyName(19, "")
        Me.ImageList1.Images.SetKeyName(20, "")
        Me.ImageList1.Images.SetKeyName(21, "")
        Me.ImageList1.Images.SetKeyName(22, "")
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tlbrIQOQPQ)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(804, 34)
        Me.Panel2.TabIndex = 19
        '
        'tlbrIQOQPQ
        '
        Me.tlbrIQOQPQ.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tlbrIQOQPQ.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tlbtnLock, Me.ToolBarButton4, Me.tlbtnPrevious, Me.ToolBarButton5, Me.tlbtnNext, Me.ToolBarButton6, Me.tlbrPrint, Me.tlbrPrintAll, Me.tlbrExport, Me.ToolBarButton1, Me.tlbtnReturn})
        Me.tlbrIQOQPQ.ButtonSize = New System.Drawing.Size(25, 25)
        Me.tlbrIQOQPQ.DropDownArrows = True
        Me.tlbrIQOQPQ.ImageList = Me.ImageList1
        Me.tlbrIQOQPQ.Location = New System.Drawing.Point(0, 0)
        Me.tlbrIQOQPQ.Name = "tlbrIQOQPQ"
        Me.tlbrIQOQPQ.ShowToolTips = True
        Me.tlbrIQOQPQ.Size = New System.Drawing.Size(804, 37)
        Me.tlbrIQOQPQ.TabIndex = 19
        '
        'tlbtnLock
        '
        Me.tlbtnLock.ImageIndex = 14
        Me.tlbtnLock.Name = "tlbtnLock"
        Me.tlbtnLock.Tag = "0"
        Me.tlbtnLock.ToolTipText = "Lock[CTRL+L]"
        '
        'ToolBarButton4
        '
        Me.ToolBarButton4.Name = "ToolBarButton4"
        Me.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tlbtnPrevious
        '
        Me.tlbtnPrevious.ImageIndex = 12
        Me.tlbtnPrevious.Name = "tlbtnPrevious"
        Me.tlbtnPrevious.Tag = "2"
        Me.tlbtnPrevious.ToolTipText = "Previous[CTRL+P]"
        '
        'ToolBarButton5
        '
        Me.ToolBarButton5.Name = "ToolBarButton5"
        Me.ToolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tlbtnNext
        '
        Me.tlbtnNext.ImageIndex = 11
        Me.tlbtnNext.Name = "tlbtnNext"
        Me.tlbtnNext.Tag = "4"
        Me.tlbtnNext.ToolTipText = "Next[CTRL+N]"
        '
        'ToolBarButton6
        '
        Me.ToolBarButton6.Name = "ToolBarButton6"
        Me.ToolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tlbrPrint
        '
        Me.tlbrPrint.ImageIndex = 13
        Me.tlbrPrint.Name = "tlbrPrint"
        Me.tlbrPrint.Tag = "6"
        Me.tlbrPrint.ToolTipText = "Print the current form"
        Me.tlbrPrint.Visible = False
        '
        'tlbrPrintAll
        '
        Me.tlbrPrintAll.ImageIndex = 13
        Me.tlbrPrintAll.Name = "tlbrPrintAll"
        Me.tlbrPrintAll.Tag = "7"
        Me.tlbrPrintAll.ToolTipText = "Print all the forms[CTRL+A]"
        '
        'tlbrExport
        '
        Me.tlbrExport.ImageIndex = 9
        Me.tlbrExport.Name = "tlbrExport"
        Me.tlbrExport.Tag = "8"
        Me.tlbrExport.ToolTipText = "Export[CTRL+E]"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Name = "ToolBarButton1"
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tlbtnReturn
        '
        Me.tlbtnReturn.ImageIndex = 10
        Me.tlbtnReturn.Name = "tlbtnReturn"
        Me.tlbtnReturn.Tag = "10"
        Me.tlbtnReturn.ToolTipText = "Return To Main Screen[CTRL+X]"
        '
        'tlbtnUnlock
        '
        Me.tlbtnUnlock.Name = "tlbtnUnlock"
        '
        'tvwIQOQPQ
        '
        Me.tvwIQOQPQ.BackColor = System.Drawing.Color.AliceBlue
        Me.tvwIQOQPQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvwIQOQPQ.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvwIQOQPQ.FullRowSelect = True
        Me.tvwIQOQPQ.HideSelection = False
        Me.tvwIQOQPQ.HotTracking = True
        Me.tvwIQOQPQ.ImageIndex = 3
        Me.tvwIQOQPQ.ImageList = Me.ImageList2
        Me.tvwIQOQPQ.Location = New System.Drawing.Point(56, 64)
        Me.tvwIQOQPQ.Name = "tvwIQOQPQ"
        Me.tvwIQOQPQ.SelectedImageIndex = 3
        Me.tvwIQOQPQ.Size = New System.Drawing.Size(192, 360)
        Me.tvwIQOQPQ.TabIndex = 21
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "")
        Me.ImageList2.Images.SetKeyName(3, "")
        Me.ImageList2.Images.SetKeyName(4, "")
        Me.ImageList2.Images.SetKeyName(5, "")
        Me.ImageList2.Images.SetKeyName(6, "")
        '
        'lstbarIQOQPQ
        '
        Me.lstbarIQOQPQ.AllowDragGroups = True
        Me.lstbarIQOQPQ.AllowDragItems = True
        Me.lstbarIQOQPQ.BackColor = System.Drawing.Color.AliceBlue
        Me.lstbarIQOQPQ.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstbarIQOQPQ.DrawStyle = vbAccelerator.Components.ListBarControl.ListBarDrawStyle.ListBarDrawStyleOfficeXP
        Me.lstbarIQOQPQ.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstbarIQOQPQ.LargeImageList = Nothing
        Me.lstbarIQOQPQ.Location = New System.Drawing.Point(272, 112)
        Me.lstbarIQOQPQ.Name = "lstbarIQOQPQ"
        Me.lstbarIQOQPQ.SelectOnMouseDown = False
        Me.lstbarIQOQPQ.Size = New System.Drawing.Size(150, 208)
        Me.lstbarIQOQPQ.SmallImageList = Nothing
        Me.lstbarIQOQPQ.TabIndex = 22
        Me.lstbarIQOQPQ.ToolTip = Nothing
        '
        'tvwSplitter
        '
        Me.tvwSplitter.BackColor = System.Drawing.Color.AliceBlue
        Me.tvwSplitter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvwSplitter.Location = New System.Drawing.Point(0, 34)
        Me.tvwSplitter.Name = "tvwSplitter"
        Me.tvwSplitter.Size = New System.Drawing.Size(5, 467)
        Me.tvwSplitter.TabIndex = 23
        Me.tvwSplitter.TabStop = False
        '
        'VsNetMenuProvider
        '
        Me.VsNetMenuProvider.ImageList = Me.ImageList1
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'frmMDI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(804, 525)
        Me.Controls.Add(Me.tvwSplitter)
        Me.Controls.Add(Me.lstbarIQOQPQ)
        Me.Controls.Add(Me.tvwIQOQPQ)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.stsdQualification)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "frmMDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AAS203 - IQOQPQ"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Form Events "

#Region " Menus "

    Private Sub mnuIQMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIQMode.Click
        Try
            Call funcDisplayChildForm(ENUM_IQ_Modes.IQ_CustomerDetails)
            Call subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            ' gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Sub mnuOQMode_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOQMode.Click
        Try
            Call funcDisplayChildForm(ENUM_OQ_Modes.OQ_Approval)
            Call subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            ' gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Sub mnuPQMode_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPQMode.Click
        Try
            Call funcDisplayChildForm(ENUM_PQ_Modes.PQ_Approval)
            Call subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            ' gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Sub mnuExit_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub mnuExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        Try
            ''''--- Writing to Activity Log
            'If (gstructApplicationSettings.Enable21CFR = 1) Then
            '    '--- Check for activity authentication
            '    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
            '        Return
            '    End If

            '    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ Files Exported")
            'End If

            Call funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag)
            'Flag used for Exporting all(True) and single(false)
            Call subExportFiles(False)
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            ' gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Sub mnuLock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuLock.Click
        Try
            Call funcLockCurrentMode()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub mnuNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuNext.Click
        Try
            Call funcGetShowNextForm()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub mnuPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPrevious.Click
        Try
            Call funcGetShowPreviousForm()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        Try
            Call funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag)
            'Flag used for Printing all(True) and single(false)

            '--- Writing to Activity Log
            'If (gstructApplicationSettings.Enable21CFR = 1) Then
            '    '--- Check for activity authentication
            '    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
            '        Return
            '    End If

            '    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ File Printed")
            'End If

            'Call gfuncPrintIQOQPQ(tvwIQOQPQ.SelectedNode.Tag, False)

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            ' gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Sub mnuPrintAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPrintAll.Click
        Try
            ''''--- Writing to Activity Log
            '''If (gstructApplicationSettings.Enable21CFR = 1) Then
            '''    '--- Check for activity authentication
            '''    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
            '''        Return
            '''    End If

            '''    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ Files Printed")
            '''End If

            'code added by ; dinesh wagh on 8.4.2010
            'purpose : to save all data if we directly close the mdi form
            '------------------------------------------
            subCloseAllChildForm()
            funcDisplayChildForm(tvwIQOQPQ.SelectedNode.Tag)
            '------------------------------


            Call funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag)

            Call gfuncPrintAll()

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            ' gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

#Region " Other Events "

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '--- Initialize the Error logs
            Call gsubErrorHandlerInitialization(gobjErrorHandler)

            Call funcInitialize()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            funcGetShowNextForm()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            funcGetShowPreviousForm()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub cmdLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            funcLockCurrentMode()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

#End Region

#Region " TreeView Events "

    Private Sub tvwIQOQPQ_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwIQOQPQ.AfterSelect
        Try
            If funcDisplayChildForm(tvwIQOQPQ.SelectedNode.Tag) = False Then
                Application.DoEvents()
            End If

        Catch ex1 As System.Configuration.ConfigurationException

        Catch ex As Exception

        End Try


    End Sub

    Private Sub tvwSplitter_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvwSplitter.DoubleClick
        Try
            tvwIQOQPQ.Width = 192
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

#End Region

#Region " ListBar Events "
    Private Sub lstbarIQOQPQ_ItemClicked(ByVal sender As System.Object, ByVal e As vbAccelerator.Components.ListBarControl.ItemClickedEventArgs)
        Try
            funcDisplayChildForm(e.Item.Tag)
            Application.DoEvents()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub
#End Region

#Region "ToolBar Events"

    Private Sub tlbrIQOQPQ_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tlbrIQOQPQ.MouseMove
        Try
            Dim ptButton As Point
            ptButton.X = e.X
            ptButton.Y = e.Y
            Call funcDisplayOnStatusbar(ptButton)
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub tlbrIQOQPQ_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tlbrIQOQPQ.MouseLeave
        Try
            StatusBarPanel1.Text = ""
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub tlbrIQOQPQ_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbrIQOQPQ.ButtonClick
        Try
            Select Case e.Button.Tag
                Case enumToolBarButtons.tlbtnLock
                    Call funcLockCurrentMode()
                Case enumToolBarButtons.tlbtnNext
                    Call funcGetShowNextForm()
                Case enumToolBarButtons.tlbtnPrevious
                    Call funcGetShowPreviousForm()
                Case enumToolBarButtons.tlbrPrint

                    ''''--- Writing to Activity Log
                    '''If (gstructApplicationSettings.Enable21CFR = 1) Then
                    '''    '--- Check for activity authentication
                    '''    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    '''        Return
                    '''    End If

                    '''    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ File Printed")
                    '''End If
                    'Call funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag)
                    'Flag used for Printing all(True) and single(false)

                    '''Call gfuncPrintIQOQPQ(tvwIQOQPQ.SelectedNode.Tag, False)

                Case enumToolBarButtons.tlbrExport

                    ''''--- Writing to Activity Log
                    '''If (gstructApplicationSettings.Enable21CFR = 1) Then
                    '''    '--- Check for activity authentication
                    '''    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Export, gstructUserDetails.Access) Then
                    '''        Return
                    '''    End If

                    '''    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ Files Exported")
                    '''End If
                    Call mnuExport_Click(mnuExport, New EventArgs)
                    'Call funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag)
                    'Flag used for Exporting all(True) and single(false)
                    '''Call subExportFiles(False)
                Case enumToolBarButtons.tlbrPrintAll

                    ''''--- Writing to Activity Log
                    '''If (gstructApplicationSettings.Enable21CFR = 1) Then
                    '''    '--- Check for activity authentication
                    '''    If Not funcCheckActivityAuthentication(enumActivityAuthentication.Print, gstructUserDetails.Access) Then
                    '''        Return
                    '''    End If

                    '''    gfuncInsertActivityLog(EnumModules.IQOQPQ, "IQOQPQ Files Printed")
                    '''End If
                    Call mnuPrintAll_Click(mnuPrintAll, New EventArgs)

                    'Call funcShowSameForm(tvwIQOQPQ.SelectedNode.Tag)

                    '''Call gfuncPrintAll()

                Case enumToolBarButtons.tlbtnExit
                    Me.Close()
            End Select

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

#End Region

#End Region

#Region " General Private functions "

    '--------------------------------------------------------
    '    General functions used for IQOQPQ
    '--- funcInitialize - To Initialize form and to fill records in Tree View control and display them.
    '--- funcCreateNode - To Add a node with name passed to it to the TreeNode object passed.
    '--- funcUpdateStatusBar - To Update Status Bar and displa the Name which is passed to it.
    '--- funcMakeActiveForm - To Close Previous Forms and make IQOQPQ form Active.

    Private Sub funcInitialize()
        '=====================================================================
        ' Procedure Name        :   funcInitailize
        ' Description           :   To Initialize form and to fill records in Tree View control and display them.
        ' Purpose               :   To Initialize form and to fill records in Tree View control and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================
        Try
            '--- Create the connection to the IQOQPQ database
            'If Not gfuncCreateIQOQPQConnection() Then
            '    Me.Close()
            'End If
            Dim strInstrumentType As String

            'Saurabh 30.07.07 to get the Instrument Type 
            RaiseEvent InstrumentType(strInstrumentType)
            Me.Text = strInstrumentType & " IQOQPQ"
            'Saurabh 30.07.07 to get the Instrument Type 

            If CONST_Use_TreeView = 1 Then
                funcGetTreeViewNodes()
            Else
                funcGetListBarItems()
            End If
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try

    End Sub

#Region "Functions Related to TreeView"

    Private Function funcGetTreeViewNodes()
        '=====================================================================
        ' Procedure Name        :   funcGetTreeViewNodes
        ' Description           :   To fill records in Tree View control and display them.
        ' Purpose               :   To fill records in Tree View control and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================
        Try
            lstbarIQOQPQ.Visible = False
            'Forcing Tree View To always appear to the left of screen
            tvwIQOQPQ.Anchor = AnchorStyles.Left
            tvwIQOQPQ.Dock = DockStyle.Left
            tvwSplitter.Visible = True
            tvwSplitter.Location = New Point(tvwIQOQPQ.Left + tvwIQOQPQ.Width, tvwIQOQPQ.Top)

            '--- Installation Qualification (IQ)
            Dim nodeInstallation As TreeNode = New TreeNode("Installation Qualification")
            nodeInstallation.ImageIndex = 4         'Saurabh
            nodeInstallation.SelectedImageIndex = 4     'Saurabh
            tvwIQOQPQ.Nodes.Add(nodeInstallation)
            nodeInstallation.Tag = ENUM_IQOQPQ_STATUS.IQ
            tvwIQOQPQ.HotTracking = True

            '--- To Add Sub-Nodes for IQ.
            funcCreateNode("Customer Details", ENUM_IQ_Modes.IQ_CustomerDetails, nodeInstallation)
            funcCreateNode("Equipment Listing", ENUM_IQ_Modes.IQ_EquipmentList, nodeInstallation)
            funcCreateNode("Manual Listing", ENUM_IQ_Modes.IQ_ManualList, nodeInstallation)
            funcCreateNode("Approval", ENUM_IQ_Modes.IQ_Approval, nodeInstallation)
            'funcCreateNode("Specification Of Instruments", ENUM_IQ_Modes.IQ_Specifications, nodeInstallation) 'commented by ; dinesh wagh on 4.4.2010
            funcCreateNode("Instrument Details", ENUM_IQ_Modes.IQ_Specifications, nodeInstallation) 'added by ; dinesh wagh on 4.4.2010
            funcCreateNode("Tests", ENUM_IQ_Modes.IQ_Tests, nodeInstallation)
            funcCreateNode("Deficiencies Found & Corrective Action ", ENUM_IQ_Modes.IQ_Deficiency, nodeInstallation)

            '--- Operational Qualification (OQ)
            Dim nodeOperational As TreeNode = New TreeNode("Operational Qualification")
            nodeOperational.ImageIndex = 5      'Saurabh
            nodeOperational.SelectedImageIndex = 5     'Saurabh
            tvwIQOQPQ.Nodes.Add(nodeOperational)
            nodeOperational.Tag = ENUM_IQOQPQ_STATUS.OQ
            tvwIQOQPQ.HotTracking = True

            '--- To Add Sub-Nodes for OQ.
            funcCreateNode("Approval", ENUM_OQ_Modes.OQ_Approval, nodeOperational)
            funcCreateNode("Equipment Listing", ENUM_OQ_Modes.OQ_EquipmentList, nodeOperational)
            funcCreateNode("Test - 1", ENUM_OQ_Modes.OQ_Test1, nodeOperational)
            funcCreateNode("Test - 2", ENUM_OQ_Modes.OQ_Test2, nodeOperational)
            funcCreateNode("Training", ENUM_OQ_Modes.OQ_UserTraining, nodeOperational)
            funcCreateNode("Deficiencies Found & Corrective Action ", ENUM_OQ_Modes.OQ_Deficiency, nodeOperational)

            '--- Performance Qualification (PQ)
            Dim nodePerformance As TreeNode = New TreeNode("Performance Qualification")
            nodePerformance.ImageIndex = 6          'Saurabh
            nodePerformance.SelectedImageIndex = 6     'Saurabh
            tvwIQOQPQ.Nodes.Add(nodePerformance)
            nodePerformance.Tag = ENUM_IQOQPQ_STATUS.PQ
            tvwIQOQPQ.HotTracking = True

            '--- To Add Sub-Nodes for PQ.
            funcCreateNode("Approval", ENUM_PQ_Modes.PQ_Approval, nodePerformance)
            funcCreateNode("Equipment Listing", ENUM_PQ_Modes.PQ_EquipmentList, nodePerformance)
            funcCreateNode("Test", ENUM_PQ_Modes.PQ_Test, nodePerformance)
            funcCreateNode("Attachment-1", ENUM_PQ_Modes.PQ_Attachment1, nodePerformance)
            funcCreateNode("Attachment-2", ENUM_PQ_Modes.PQ_Attachment2, nodePerformance)
            funcCreateNode("Attachment-3", ENUM_PQ_Modes.PQ_Attachment3, nodePerformance)
            '================Modified by Saurabh======================
            'funcCreateNode("Attachment-4", ENUM_PQ_Modes.PQ_Attachment4, nodePerformance)
            'funcCreateNode("Attachment-5", ENUM_PQ_Modes.PQ_Attachment5, nodePerformance)
            'funcCreateNode("Attachment-6", ENUM_PQ_Modes.PQ_Attachment6, nodePerformance)
            'funcCreateNode("Attachment-7", ENUM_PQ_Modes.PQ_Attachment7, nodePerformance)
            'funcCreateNode("Attachment-8", ENUM_PQ_Modes.PQ_Attachment8, nodePerformance)
            'funcCreateNode("Attachment-9", ENUM_PQ_Modes.PQ_Attachment9, nodePerformance)
            '================Modified by Saurabh======================
            funcCreateNode("Deficiencies Found & Corrective Action ", ENUM_PQ_Modes.PQ_Deficiency, nodePerformance)
            funcCreateNode("Warranty", ENUM_PQ_Modes.PQ_Warranty, nodePerformance)

            funcDisplayChildForm(ENUM_IQ_Modes.IQ_CustomerDetails)

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function

    Private Function funcCreateNode(ByVal strName As String, ByVal intTag As Integer, ByRef ObjParent As TreeNode)
        '=====================================================================
        ' Procedure Name        :   funcCreateNode
        ' Description           :   To Add a node with name passed to it to the TreeNode object passed.
        ' Purpose               :   To Add a node with name passed to it to the TreeNode object passed.
        ' Parameters Passed     :   Name of Node and Reference Node.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================
        Try
            Dim objChildNode As TreeNode = New TreeNode(strName)

            ObjParent.Nodes.Add(objChildNode)
            objChildNode.Tag = intTag

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function

    Private Function funcShowSelectedNode(ByVal TagValue As String) As Boolean
        '=====================================================================
        ' Procedure Name        :   funcShowSelectedNode
        ' Description           :   To HighLight the Selected Node.
        ' Purpose               :   To HighLight the Selected Node.
        ' Parameters Passed     :   Tag of the Node.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================
        Dim blnResult As Boolean = True
        Dim strNodeTag As String
        Dim objNode As New TreeNode
        Dim intCounter As Integer
        Try
            '--- FOR IQ
            If blnResult Then
                For Each objNode In tvwIQOQPQ.Nodes(0).Nodes
                    strNodeTag = CStr(objNode.Tag() & "")
                    If (strNodeTag = TagValue) Then
                        tvwIQOQPQ.SelectedNode() = objNode
                        blnResult = False
                        Exit For
                    End If
                Next
                'for intCounter=0 to tvwIQOQPQ.Nodes(0).Nodes.    
            End If
            '--- FOR OQ
            If blnResult Then
                For Each objNode In tvwIQOQPQ.Nodes(1).Nodes
                    strNodeTag = CStr(objNode.Tag() & "")
                    If (strNodeTag = TagValue) Then
                        tvwIQOQPQ.SelectedNode() = objNode
                        blnResult = False
                        Exit For
                    End If
                Next
            End If
            '--- FOR PQ
            If blnResult Then
                For Each objNode In tvwIQOQPQ.Nodes(2).Nodes
                    strNodeTag = CStr(objNode.Tag() & "")
                    If (strNodeTag = TagValue) Then
                        tvwIQOQPQ.SelectedNode() = objNode
                        blnResult = False
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function

#End Region

#Region "Functions Related to ListBar"

    Private Function funcGetListBarItems()
        '=====================================================================
        ' Procedure Name        :   funcGetListBarItems
        ' Description           :   To fill records in ListBar control and display them.
        ' Purpose               :   To fill records in ListBar control and display them.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   February, 2003 
        ' Revisions             :
        '=====================================================================
        Try
            tvwIQOQPQ.Visible = False
            'Forcing Tree View To always appear to the left of screen
            lstbarIQOQPQ.Anchor = AnchorStyles.Left
            lstbarIQOQPQ.Dock = DockStyle.Left
            lstbarIQOQPQ.Visible = True
            lstbarIQOQPQ.Location = New Point(tvwIQOQPQ.Left + tvwIQOQPQ.Width, tvwIQOQPQ.Top)
            lstbarIQOQPQ.Groups.Clear()

            lstbarIQOQPQ.Anchor = AnchorStyles.Left
            lstbarIQOQPQ.Dock = DockStyle.Left
            'tvwSplitter.Visible = True
            'tvwSplitter.Location = New Point(tvwIQOQPQ.Left + tvwIQOQPQ.Width, tvwIQOQPQ.Top)

            '--- Installation Qualification (IQ)
            Dim grpInstallation As ListBarGroup = New ListBarGroup("Installation Qualification")
            grpInstallation.Tag = ENUM_IQOQPQ_STATUS.IQ
            grpInstallation.BackColor = Color.Linen
            lstbarIQOQPQ.Groups.Add(grpInstallation)

            '--- To Add Items for IQ.
            funcAddItemToGroup("Equipment Listing", ENUM_IQ_Modes.IQ_EquipmentList, grpInstallation)
            funcAddItemToGroup("Mannual Listing", ENUM_IQ_Modes.IQ_ManualList, grpInstallation)
            funcAddItemToGroup("Approval", ENUM_IQ_Modes.IQ_Approval, grpInstallation)
            funcAddItemToGroup("Instrument & Accessories Specification", ENUM_IQ_Modes.IQ_Specifications, grpInstallation)
            funcAddItemToGroup("Tests", ENUM_IQ_Modes.IQ_Tests, grpInstallation)
            funcAddItemToGroup("Deficiencies & Corrective Action Plan", ENUM_IQ_Modes.IQ_Deficiency, grpInstallation)

            '--- Operational Qualification (OQ)
            Dim grpOperational As ListBarGroup = New ListBarGroup("Operational Qualification")
            grpOperational.Tag = ENUM_IQOQPQ_STATUS.OQ
            lstbarIQOQPQ.Groups.Add(grpOperational)

            '--- To Add Items for OQ.
            funcAddItemToGroup("Approval", ENUM_OQ_Modes.OQ_Approval, grpOperational)
            funcAddItemToGroup("Equipment Listing", ENUM_OQ_Modes.OQ_EquipmentList, grpOperational)
            funcAddItemToGroup("Test - 1", ENUM_OQ_Modes.OQ_Test1, grpOperational)
            funcAddItemToGroup("Test - 2", ENUM_OQ_Modes.OQ_Test2, grpOperational)
            funcAddItemToGroup("Training", ENUM_OQ_Modes.OQ_UserTraining, grpOperational)
            funcAddItemToGroup("Deficiencies & Corrective Action Plan", ENUM_OQ_Modes.OQ_Deficiency, grpOperational)

            '--- Performance Qualification (PQ)
            Dim grpPerformance As ListBarGroup = New ListBarGroup("Performance Qualification")
            grpPerformance.Tag = ENUM_IQOQPQ_STATUS.PQ
            lstbarIQOQPQ.Groups.Add(grpPerformance)

            '--- To Add Items for PQ.
            funcAddItemToGroup("Approval", ENUM_PQ_Modes.PQ_Approval, grpPerformance)
            funcAddItemToGroup("Equipment Listing", ENUM_PQ_Modes.PQ_EquipmentList, grpPerformance)
            funcAddItemToGroup("Test", ENUM_PQ_Modes.PQ_Test, grpPerformance)
            funcAddItemToGroup("Attachment-1", ENUM_PQ_Modes.PQ_Attachment1, grpPerformance)
            funcAddItemToGroup("Attachment-2", ENUM_PQ_Modes.PQ_Attachment2, grpPerformance)
            funcAddItemToGroup("Attachment-3", ENUM_PQ_Modes.PQ_Attachment3, grpPerformance)
            'funcAddItemToGroup("Attachment-4", ENUM_PQ_Modes.PQ_Attachment4, grpPerformance)
            'funcAddItemToGroup("Attachment-5", ENUM_PQ_Modes.PQ_Attachment5, grpPerformance)
            funcAddItemToGroup("Deficiencies & Corrective Action Plan", ENUM_PQ_Modes.PQ_Deficiency, grpPerformance)
            funcAddItemToGroup("Warranty", ENUM_PQ_Modes.PQ_Warranty, grpPerformance)

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function

    Private Function funcAddItemToGroup(ByVal strName As String, ByVal intTag As Integer, ByRef ObjParentGroup As ListBarGroup)
        '=====================================================================
        ' Procedure Name        :   funcAddItemToGroup
        ' Description           :   To Add a node with name passed to it to the ListBar Group passed.
        ' Purpose               :   To Add a node with name passed to it to the ListBar Group passed.
        ' Parameters Passed     :   Name of Item and Reference Group.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================
        Try
            Dim objItem As ListBarItem = New ListBarItem(strName)
            objItem.Tag = intTag

            ObjParentGroup.Items.Add(objItem)
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function

#End Region

#Region "Functions Related to Form Display"

    Private Function funcShowChildForms(ByVal objChildFormIn As Form) As Boolean
        Try
            'mobjChildForm = objChildFormIn
            If Not Me.ActiveMdiChild Is Nothing Then
                Me.ActiveMdiChild.Close()
                'Me.ActiveMdiChild.Dispose()
            End If
            objChildFormIn.MdiParent = Me
            'CustomPanelMain.Controls.Add(objChildFormIn)
            Me.ActivateMdiChild(objChildFormIn)
            'objChildFormIn.Dock = DockStyle.Fill
            objChildFormIn.BringToFront()
            objChildFormIn.Show()
        Catch ex As Exception

        End Try

    End Function

    Private Function funcDisplayChildForm(ByVal intTagValue As Integer) As Boolean
        Dim strTag, strSelectedItemText As String
        '''Dim mfrmPQTest2 As New frmPQTest2
        Try
            funcMakeActiveForm()
            If CONST_Use_TreeView = 1 Then
                funcShowSelectedNode(intTagValue)
                strSelectedItemText = tvwIQOQPQ.SelectedNode.Text
            Else
                strSelectedItemText = lstbarIQOQPQ.SelectedGroup.SelectedItem.Caption
            End If


            Select Case intTagValue
                Case ENUM_IQOQPQ_STATUS.IQ, ENUM_IQ_Modes.IQ_CustomerDetails,
                    ENUM_IQ_Modes.IQ_Approval, ENUM_IQ_Modes.IQ_Deficiency, ENUM_IQ_Modes.IQ_EquipmentList,
                    ENUM_IQ_Modes.IQ_ManualList, ENUM_IQ_Modes.IQ_Specifications, ENUM_IQ_Modes.IQ_Tests
                    'tvwIQOQPQ.SelectedImageIndex = 4        'Saurabh
                    If gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.IQ) Then
                        '------to check mode is lock or unlock and change the icon in toolbar
                        tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeLock
                    Else
                        tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeUnLock
                    End If
                Case ENUM_IQOQPQ_STATUS.OQ, ENUM_OQ_Modes.OQ_Approval,
                    ENUM_OQ_Modes.OQ_Deficiency, ENUM_OQ_Modes.OQ_EquipmentList,
                    ENUM_OQ_Modes.OQ_Test1, ENUM_OQ_Modes.OQ_Test2, ENUM_OQ_Modes.OQ_UserTraining
                    'tvwIQOQPQ.SelectedImageIndex = 5        'Saurabh
                    If gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.OQ) Then
                        '------to check mode is lock or unlock and change the icon in toolbar
                        tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeLock
                    Else
                        tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeUnLock
                    End If
                Case ENUM_IQOQPQ_STATUS.PQ, ENUM_PQ_Modes.PQ_Approval,
                    ENUM_PQ_Modes.PQ_Attachment1, ENUM_PQ_Modes.PQ_Attachment2, ENUM_PQ_Modes.PQ_Attachment3,
                    ENUM_PQ_Modes.PQ_Deficiency, ENUM_PQ_Modes.PQ_EquipmentList, ENUM_PQ_Modes.PQ_Test, ENUM_PQ_Modes.PQ_Warranty
                    'tvwIQOQPQ.SelectedImageIndex = 6        'Saurabh
                    If gobjDataAccess.funcCheckModeLocked(ENUM_IQOQPQ_STATUS.PQ) Then
                        '------to check mode is lock or unlock and change the icon in toolbar
                        tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeLock
                    Else
                        tlbrIQOQPQ.Buttons(0).ImageIndex = CONST_ModeUnLock
                    End If

            End Select

            Select Case intTagValue

                '--- IQ Mode is selected
                Case ENUM_IQOQPQ_STATUS.IQ
                    strTag = CStr(0) + "," + CStr(ENUM_IQ_Modes.IQ_CustomerDetails & "") + "," + CStr(ENUM_IQ_Modes.IQ_EquipmentList & "")
                    Dim mfrmCustDetails As New frmCustomerDetails
                    mfrmCustDetails.MdiParent = Me
                    mfrmCustDetails.Tag = strTag
                    'funcShowChildForms(mfrmCustDetails)
                    mfrmCustDetails.Show()
                    If Me.tvwIQOQPQ.Height > mfrmCustDetails.Panel1.Height Then
                        mfrmCustDetails.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    mfrmCustDetails.Refresh()
                    funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ)

                    '--- "IQ Customer Details" 
                Case ENUM_IQ_Modes.IQ_CustomerDetails
                    strTag = CStr(0) + "," + CStr(ENUM_IQ_Modes.IQ_CustomerDetails & "") + "," + CStr(ENUM_IQ_Modes.IQ_EquipmentList & "")
                    Dim mfrmCustDetails As New frmCustomerDetails
                    mfrmCustDetails.MdiParent = Me
                    mfrmCustDetails.Tag = strTag
                    'funcShowChildForms(mfrmCustDetails)
                    mfrmCustDetails.Show()
                    If Me.tvwIQOQPQ.Height > mfrmCustDetails.Panel1.Height Then
                        mfrmCustDetails.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    mfrmCustDetails.Refresh()
                    funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ)

                    '--- "IQ Equipment Listing" 
                Case ENUM_IQ_Modes.IQ_EquipmentList
                    strTag = CStr(ENUM_IQ_Modes.IQ_CustomerDetails & "") + "," + CStr(ENUM_IQ_Modes.IQ_EquipmentList & "") + "," + CStr(ENUM_IQ_Modes.IQ_ManualList & "")
                    Dim mfrmEqLst As New frmIQEquipmentList
                    mfrmEqLst.MdiParent = Me
                    mfrmEqLst.Tag = strTag
                    'funcShowChildForms(mfrmEqLst)
                    mfrmEqLst.Show()
                    If Me.tvwIQOQPQ.Height > mfrmEqLst.Panel1.Height Then
                        mfrmEqLst.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ)

                    '--- "IQ Manual Listing" 
                Case ENUM_IQ_Modes.IQ_ManualList
                    strTag = CStr(ENUM_IQ_Modes.IQ_EquipmentList & "") + "," + CStr(ENUM_IQ_Modes.IQ_ManualList & "") + "," + CStr(ENUM_IQ_Modes.IQ_Approval & "")
                    Dim mfrmManualLst As New frmIQMannualList
                    mfrmManualLst.MdiParent = Me
                    mfrmManualLst.Tag = strTag
                    mfrmManualLst.Show()
                    If Me.tvwIQOQPQ.Height > mfrmManualLst.Panel1.Height Then
                        mfrmManualLst.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ)

                    '--- "IQ Approval" 
                Case ENUM_IQ_Modes.IQ_Approval
                    strTag = CStr(ENUM_IQ_Modes.IQ_ManualList & "") + "," + CStr(ENUM_IQ_Modes.IQ_Approval & "") + "," + CStr(ENUM_IQ_Modes.IQ_Specifications & "")
                    Dim mfrmIQApproval As New frmIQApproval(ENUM_IQOQPQ_STATUS.IQ)
                    mfrmIQApproval.MdiParent = Me
                    mfrmIQApproval.Tag = strTag
                    mfrmIQApproval.Show()
                    If Me.tvwIQOQPQ.Height > mfrmIQApproval.Panel1.Height Then
                        mfrmIQApproval.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ)

                    '--- "IQ Instrument & Accessories Specification"
                Case ENUM_IQ_Modes.IQ_Specifications
                    strTag = CStr(ENUM_IQ_Modes.IQ_Approval & "") + "," + CStr(ENUM_IQ_Modes.IQ_Specifications & "") + "," + CStr(ENUM_IQ_Modes.IQ_Tests & "")
                    Dim mfrmSpecification As New frmIQSpecification
                    mfrmSpecification.MdiParent = Me
                    mfrmSpecification.Tag = strTag
                    mfrmSpecification.Show()
                    If Me.tvwIQOQPQ.Height > mfrmSpecification.Panel1.Height Then
                        mfrmSpecification.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ)

                    '--- "IQ Tests"
                Case ENUM_IQ_Modes.IQ_Tests
                    strTag = CStr(ENUM_IQ_Modes.IQ_Specifications & "") + "," + CStr(ENUM_IQ_Modes.IQ_Tests & "") + "," + CStr(ENUM_IQ_Modes.IQ_Deficiency & "")
                    Dim mfrmTest As New frmIQTest ' frmextra  
                    mfrmTest.MdiParent = Me
                    mfrmTest.Tag = strTag
                    mfrmTest.Show()
                    If Me.tvwIQOQPQ.Height > mfrmTest.Panel1.Height Then
                        mfrmTest.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ)

                    '--- "IQ Deficiencies & Corrective Action Plan"
                Case ENUM_IQ_Modes.IQ_Deficiency
                    strTag = CStr(ENUM_IQ_Modes.IQ_Tests & "") + "," + CStr(ENUM_IQ_Modes.IQ_Deficiency & "") + "," + CStr(ENUM_OQ_Modes.OQ_Approval & "")
                    Dim mfrmIQDeficiency As New frmIQDeficiency(ENUM_IQOQPQ_STATUS.IQ)
                    mfrmIQDeficiency.MdiParent = Me
                    mfrmIQDeficiency.Tag = strTag
                    mfrmIQDeficiency.Show()
                    If Me.tvwIQOQPQ.Height > mfrmIQDeficiency.Panel1.Height Then
                        mfrmIQDeficiency.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Installation Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.IQ)

                    '--- OQ Mode is selected
                Case ENUM_IQOQPQ_STATUS.OQ

                    strTag = CStr(ENUM_IQ_Modes.IQ_Deficiency & "") + "," + CStr(ENUM_OQ_Modes.OQ_Approval & "") + "," + CStr(ENUM_OQ_Modes.OQ_EquipmentList & "")
                    Dim mfrmOQApproval As New frmIQApproval(ENUM_IQOQPQ_STATUS.OQ)
                    mfrmOQApproval.MdiParent = Me
                    mfrmOQApproval.Tag = strTag
                    mfrmOQApproval.Show()
                    If Me.tvwIQOQPQ.Height > mfrmOQApproval.Panel1.Height Then
                        mfrmOQApproval.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ)

                    '--- "OQ Approval"
                Case ENUM_OQ_Modes.OQ_Approval
                    strTag = CStr(ENUM_IQ_Modes.IQ_Deficiency & "") + "," + CStr(ENUM_OQ_Modes.OQ_Approval & "") + "," + CStr(ENUM_OQ_Modes.OQ_EquipmentList & "")
                    Dim mfrmOQApproval As New frmIQApproval(ENUM_IQOQPQ_STATUS.OQ)
                    mfrmOQApproval.MdiParent = Me
                    mfrmOQApproval.Tag = strTag
                    mfrmOQApproval.Show()
                    If Me.tvwIQOQPQ.Height > mfrmOQApproval.Panel1.Height Then
                        mfrmOQApproval.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ)

                    '--- "OQ Equipment List"
                Case ENUM_OQ_Modes.OQ_EquipmentList
                    strTag = CStr(ENUM_OQ_Modes.OQ_Approval & "") + "," + CStr(ENUM_OQ_Modes.OQ_EquipmentList & "") + "," + CStr(ENUM_OQ_Modes.OQ_Test1 & "")
                    Dim mfrmOQEquipmentList As New frmOQEquipmentList(ENUM_IQOQPQ_STATUS.OQ)
                    mfrmOQEquipmentList.MdiParent = Me
                    mfrmOQEquipmentList.Tag = strTag
                    mfrmOQEquipmentList.Show()
                    If Me.tvwIQOQPQ.Height > mfrmOQEquipmentList.Panel1.Height Then
                        mfrmOQEquipmentList.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ)

                    '--- "OQ Test1"
                Case ENUM_OQ_Modes.OQ_Test1
                    strTag = CStr(ENUM_OQ_Modes.OQ_EquipmentList & "") + "," + CStr(ENUM_OQ_Modes.OQ_Test1 & "") + "," + CStr(ENUM_OQ_Modes.OQ_Test2 & "")
                    Dim mfrmOQTest As New frmOQTest
                    mfrmOQTest.MdiParent = Me
                    mfrmOQTest.Tag = strTag
                    mfrmOQTest.Show()
                    If Me.tvwIQOQPQ.Height > mfrmOQTest.Panel1.Height Then
                        mfrmOQTest.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ)

                    '--- "OQ Test2"
                Case ENUM_OQ_Modes.OQ_Test2
                    strTag = CStr(ENUM_OQ_Modes.OQ_Test1 & "") + "," + CStr(ENUM_OQ_Modes.OQ_Test2 & "") + "," + CStr(ENUM_OQ_Modes.OQ_UserTraining & "")
                    Dim mfrmOQTest2 As New frmOQTest2
                    mfrmOQTest2.MdiParent = Me
                    mfrmOQTest2.Tag = strTag
                    mfrmOQTest2.Show()
                    If Me.tvwIQOQPQ.Height > mfrmOQTest2.Panel1.Height Then
                        mfrmOQTest2.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ)

                    '--- "OQ User Training"
                Case ENUM_OQ_Modes.OQ_UserTraining
                    strTag = CStr(ENUM_OQ_Modes.OQ_Test2 & "") + "," + CStr(ENUM_OQ_Modes.OQ_UserTraining & "") + "," + CStr(ENUM_OQ_Modes.OQ_Deficiency & "")
                    Dim mfrmUserTraining As New frmOQUserTraining
                    mfrmUserTraining.MdiParent = Me
                    mfrmUserTraining.Tag = strTag
                    mfrmUserTraining.Show()
                    If Me.tvwIQOQPQ.Height > mfrmUserTraining.Panel1.Height Then
                        mfrmUserTraining.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ)

                    '--- "OQ Deficiency & Corrective Action"
                Case ENUM_OQ_Modes.OQ_Deficiency
                    strTag = CStr(ENUM_OQ_Modes.OQ_UserTraining & "") + "," + CStr(ENUM_OQ_Modes.OQ_Deficiency & "") + "," + CStr(ENUM_PQ_Modes.PQ_Approval & "")
                    Dim mfrmOQDeficiency As New frmIQDeficiency(ENUM_IQOQPQ_STATUS.OQ)
                    mfrmOQDeficiency.MdiParent = Me
                    mfrmOQDeficiency.Tag = strTag
                    mfrmOQDeficiency.Show()
                    If Me.tvwIQOQPQ.Height > mfrmOQDeficiency.Panel1.Height Then
                        mfrmOQDeficiency.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Operational Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.OQ)

                    '--- PQ Mode is selected 
                Case ENUM_IQOQPQ_STATUS.PQ
                    strTag = CStr(ENUM_OQ_Modes.OQ_Deficiency & "") + "," + CStr(ENUM_PQ_Modes.PQ_Approval & "") + "," + CStr(ENUM_PQ_Modes.PQ_EquipmentList & "")
                    Dim mfrmPQApproval As New frmIQApproval(ENUM_IQOQPQ_STATUS.PQ)
                    mfrmPQApproval.MdiParent = Me
                    mfrmPQApproval.Tag = strTag
                    mfrmPQApproval.Show()
                    If Me.tvwIQOQPQ.Height > mfrmPQApproval.Panel1.Height Then
                        mfrmPQApproval.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Performance Qualification :  " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '--- "PQ Approval"
                Case ENUM_PQ_Modes.PQ_Approval
                    strTag = CStr(ENUM_OQ_Modes.OQ_Deficiency & "") + "," + CStr(ENUM_PQ_Modes.PQ_Approval & "") + "," + CStr(ENUM_PQ_Modes.PQ_EquipmentList & "")
                    Dim mfrmPQApproval As New frmIQApproval(ENUM_IQOQPQ_STATUS.PQ)
                    mfrmPQApproval.MdiParent = Me
                    mfrmPQApproval.Tag = strTag
                    mfrmPQApproval.Show()
                    If Me.tvwIQOQPQ.Height > mfrmPQApproval.Panel1.Height Then
                        mfrmPQApproval.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Performance Qualification :  " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '--- "PQ Equipment Listing"
                Case ENUM_PQ_Modes.PQ_EquipmentList
                    strTag = CStr(ENUM_PQ_Modes.PQ_Approval & "") + "," + CStr(ENUM_PQ_Modes.PQ_EquipmentList & "") + "," + CStr(ENUM_PQ_Modes.PQ_Test & "")
                    Dim mfrmPQEquipmentList As New frmOQEquipmentList(ENUM_IQOQPQ_STATUS.PQ)
                    mfrmPQEquipmentList.MdiParent = Me
                    mfrmPQEquipmentList.Tag = strTag
                    mfrmPQEquipmentList.Show()
                    If Me.tvwIQOQPQ.Height > mfrmPQEquipmentList.Panel1.Height Then
                        mfrmPQEquipmentList.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '--- "PQ Tests"
                Case ENUM_PQ_Modes.PQ_Test
                    strTag = CStr(ENUM_PQ_Modes.PQ_EquipmentList & "") + "," + CStr(ENUM_PQ_Modes.PQ_Test & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment1 & "")
                    Dim mfrmPQTest1 As New frmPQTest1
                    mfrmPQTest1.MdiParent = Me
                    mfrmPQTest1.Tag = strTag
                    mfrmPQTest1.Show()
                    If Me.tvwIQOQPQ.Height > mfrmPQTest1.Panel1.Height Then
                        mfrmPQTest1.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If

                    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '--- "PQ Attachment1"
                Case ENUM_PQ_Modes.PQ_Attachment1
                    strTag = CStr(ENUM_PQ_Modes.PQ_Test & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment1 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment2 & "")
                    'Dim mfrmPQTest2 As New frmPQTest2      'Saurabh change the object to module level
                    mfrmPQTest2 = New frmPQTest2
                    Application.DoEvents()
                    mfrmPQTest2.MdiParent = Me
                    mfrmPQTest2.Tag = strTag
                    mfrmPQTest2.Show()
                    Application.DoEvents()

                    If Me.tvwIQOQPQ.Height > mfrmPQTest2.Panel1.Height Then
                        mfrmPQTest2.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If

                    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '--- "PQ Attachment2"
                Case ENUM_PQ_Modes.PQ_Attachment2
                    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment1 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment2 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment3 & "")
                    'Dim mfrmPQTest3 As New frmPQTest3
                    mfrmPQTest3 = New frmPQTest3
                    mfrmPQTest3.MdiParent = Me
                    mfrmPQTest3.Tag = strTag
                    mfrmPQTest3.Show()
                    If Me.tvwIQOQPQ.Height > mfrmPQTest3.Panel1.Height Then
                        mfrmPQTest3.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '--- "PQ Attachment3"
                Case ENUM_PQ_Modes.PQ_Attachment3
                    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment2 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment3 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Deficiency & "")
                    'Dim mfrmPQTest4 As New frmPQTest4
                    mfrmPQTest4 = New frmPQTest4
                    mfrmPQTest4.MdiParent = Me
                    mfrmPQTest4.Tag = strTag
                    mfrmPQTest4.Show()
                    If Me.tvwIQOQPQ.Height > mfrmPQTest4.Panel1.Height Then
                        mfrmPQTest4.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '--- "PQ Attachment4"
                    'Case ENUM_PQ_Modes.PQ_Attachment4
                    '    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment3 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment4 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment5 & "")
                    '    Dim mfrmPQTest5 As New frmPQTest5
                    '    mfrmPQTest5.MdiParent = Me
                    '    mfrmPQTest5.Tag = strTag
                    '    mfrmPQTest5.Show()
                    '    If Me.tvwIQOQPQ.Height > mfrmPQTest5.Panel1.Height Then
                    '        mfrmPQTest5.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    '    End If

                    '    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    '    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '    '--- "PQ Attachment5"
                    'Case ENUM_PQ_Modes.PQ_Attachment5
                    '    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment4 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment5 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Deficiency & "")
                    '    Dim mfrmPQTest6 As New frmPQTest6
                    '    mfrmPQTest6.MdiParent = Me
                    '    mfrmPQTest6.Tag = strTag
                    '    mfrmPQTest6.Show()
                    '    If Me.tvwIQOQPQ.Height > mfrmPQTest6.Panel1.Height Then
                    '        mfrmPQTest6.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    '    End If
                    '    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    '    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '    '--- "PQ Attachment6"
                    'Case ENUM_PQ_Modes.PQ_Attachment6
                    '    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment5 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment6 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment7 & "")
                    '    Dim mfrmPQTest7 As New frmPQTest7
                    '    mfrmPQTest7.MdiParent = Me
                    '    mfrmPQTest7.Tag = strTag
                    '    mfrmPQTest7.Show()
                    '    If Me.tvwIQOQPQ.Height > mfrmPQTest7.Panel1.Height Then
                    '        mfrmPQTest7.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    '    End If
                    '    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    '    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '    '--- "PQ Attachment7"
                    'Case ENUM_PQ_Modes.PQ_Attachment7
                    '    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment6 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment7 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment8 & "")
                    '    Dim mfrmPQTest8 As New frmPQTest8
                    '    mfrmPQTest8.MdiParent = Me
                    '    mfrmPQTest8.Tag = strTag
                    '    mfrmPQTest8.Show()
                    '    If Me.tvwIQOQPQ.Height > mfrmPQTest8.Panel1.Height Then
                    '        mfrmPQTest8.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    '    End If
                    '    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    '    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '    '--- "PQ Attachment8"
                    'Case ENUM_PQ_Modes.PQ_Attachment8
                    '    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment7 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment8 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment9 & "")
                    '    Dim mfrmPQTest9 As New frmPQTest9
                    '    mfrmPQTest9.MdiParent = Me
                    '    mfrmPQTest9.Tag = strTag
                    '    mfrmPQTest9.Show()
                    '    If Me.tvwIQOQPQ.Height > mfrmPQTest9.Panel1.Height Then
                    '        mfrmPQTest9.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    '    End If
                    '    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    '    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '    '--- "PQ Attachment9"
                    'Case ENUM_PQ_Modes.PQ_Attachment9
                    '    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment8 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Attachment9 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Deficiency & "")
                    '    Dim mfrmPQTest10 As New frmPQTest10
                    '    mfrmPQTest10.MdiParent = Me
                    '    mfrmPQTest10.Tag = strTag
                    '    mfrmPQTest10.Show()
                    '    If Me.tvwIQOQPQ.Height > mfrmPQTest10.Panel1.Height Then
                    '        mfrmPQTest10.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    '    End If
                    '    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    '    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '    '--- "PQ Deficiency and Corrective Action"
                Case ENUM_PQ_Modes.PQ_Deficiency
                    strTag = CStr(ENUM_PQ_Modes.PQ_Attachment3 & "") + "," + CStr(ENUM_PQ_Modes.PQ_Deficiency & "") + "," + CStr(ENUM_PQ_Modes.PQ_Warranty & "")
                    Dim mfrmPQDeficiency As New frmIQDeficiency(ENUM_IQOQPQ_STATUS.PQ)
                    mfrmPQDeficiency.MdiParent = Me
                    mfrmPQDeficiency.Tag = strTag
                    mfrmPQDeficiency.Show()
                    If Me.tvwIQOQPQ.Height > mfrmPQDeficiency.Panel1.Height Then
                        mfrmPQDeficiency.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)

                    '--- "PQ Warranty"
                Case ENUM_PQ_Modes.PQ_Warranty
                    strTag = CStr(ENUM_PQ_Modes.PQ_Deficiency & "") + "," + CStr(ENUM_PQ_Modes.PQ_Warranty & "") + "," + CStr(0 & "")
                    Dim mfrmWarranty As New frmPQWarranty
                    mfrmWarranty.MdiParent = Me
                    mfrmWarranty.Tag = strTag
                    mfrmWarranty.Show()
                    If Me.tvwIQOQPQ.Height > mfrmWarranty.Panel1.Height Then
                        mfrmWarranty.Panel1.Height = Me.tvwIQOQPQ.Height - 5
                    End If
                    funcUpdateStatusBar("Performance Qualification : " + strSelectedItemText)
                    subCheckMenuClicked(ENUM_IQOQPQ_STATUS.PQ)
            End Select
            Return True
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Function funcShowSameForm(ByVal intTagValue As Integer) As Boolean
        Dim frm As New Form
        Try
            Select Case intTagValue
                '--- IQ Mode is selected
                '--- "IQ Customer Details" 

                Case ENUM_IQ_Modes.IQ_CustomerDetails

                    'mfrmCustDetails.funcSaveCustomerData()
                    '--- "IQ Equipment Listing" 
                Case ENUM_IQ_Modes.IQ_EquipmentList
                    'mfrmEqLst.dgEquipmentList.CurrentCell() = (New DataGridCell(mfrmEqLst.dgEquipmentList.CurrentRowIndex + 1, 0))
                    'mfrmEqLst.funcSaveIQEquipmentListData()

                    '--- "IQ Manual Listing" 
                Case ENUM_IQ_Modes.IQ_ManualList
                    'mfrmManualLst.dgManualList.CurrentCell() = New DataGridCell(mfrmManualLst.dgManualList.CurrentRowIndex + 1, 0)
                    'mfrmManualLst.funcSaveIQManualListData()
                    '--- "IQ Approval" 
                Case ENUM_IQ_Modes.IQ_Approval
                    'mfrmIQApproval.dgCustomer.CurrentCell() = (New DataGridCell(mfrmIQApproval.dgCustomer.CurrentRowIndex + 1, 0))
                    'mfrmIQApproval.funcSaveCustomerData()
                    'mfrmIQApproval.funcSaveSupplierData()

                    '--- "IQ Instrument & Accessories Specification"
                Case ENUM_IQ_Modes.IQ_Specifications
                    'mfrmSpecification.dgSpecification.CurrentCell() = (New DataGridCell(mfrmSpecification.dgSpecification.CurrentRowIndex + 1, 0))
                    'mfrmSpecification.funcSaveIQSpecificationData()
                    'mfrmSpecification.dgAccessory.CurrentCell() = (New DataGridCell(mfrmSpecification.dgAccessory.CurrentRowIndex + 1, 0))
                    'mfrmSpecification.funcSaveIQAccessoryData()

                    '--- "IQ Tests"
                Case ENUM_IQ_Modes.IQ_Tests
                    'mfrmTest.dgTest.CurrentCell() = (New DataGridCell(mfrmTest.dgTest.CurrentRowIndex + 1, 0))
                    'mfrmTest.funcSaveIQTestData()
                    '--- "IQ Deficiencies & Corrective Action Plan"
                Case ENUM_IQ_Modes.IQ_Deficiency
                    'mfrmIQDeficiency.dgCompletedAccepted.CurrentCell() = (New DataGridCell(mfrmIQDeficiency.dgCompletedAccepted.CurrentRowIndex + 1, 0))
                    'mfrmIQDeficiency.funcSaveCompleteAcceptData()
                    'mfrmIQDeficiency.dgDeficiency.CurrentCell() = (New DataGridCell(mfrmIQDeficiency.dgDeficiency.CurrentRowIndex + 1, 0))
                    'mfrmIQDeficiency.funcSaveDeficiencyData()
                    '--- OQ Mode is selected
                    '--- "OQ Approval"
                Case ENUM_OQ_Modes.OQ_Approval

                    'mfrmOQApproval.funcSaveSupplierData()
                    'mfrmOQApproval.dgCustomer.CurrentCell() = (New DataGridCell(mfrmOQApproval.dgCustomer.CurrentRowIndex + 1, 0))
                    'mfrmOQApproval.funcSaveCustomerData()

                    '--- "OQ Equipment List"
                Case ENUM_OQ_Modes.OQ_EquipmentList
                    'mfrmOQEquipmentList.dgEquipmentList.CurrentCell() = (New DataGridCell(mfrmOQEquipmentList.dgEquipmentList.CurrentRowIndex + 1, 0))
                    'mfrmOQEquipmentList.funcSaveEquipmentListData()

                    '--- "OQ Test1"
                Case ENUM_OQ_Modes.OQ_Test1
                    'mfrmOQTest.dgTest1.CurrentCell() = (New DataGridCell(mfrmOQTest.dgTest1.CurrentRowIndex + 1, 0))
                    'mfrmOQTest.funcSaveOQTest1Data(1)
                    'mfrmOQTest.dgTest2.CurrentCell() = (New DataGridCell(mfrmOQTest.dgTest2.CurrentRowIndex + 1, 0))
                    'mfrmOQTest.funcSaveOQTest1Data(2)
                    'mfrmOQTest.dgTest3.CurrentCell() = (New DataGridCell(mfrmOQTest.dgTest3.CurrentRowIndex + 1, 0))
                    'mfrmOQTest.funcSaveOQTest1Data(3)

                    '--- "OQ Test2"
                Case ENUM_OQ_Modes.OQ_Test2
                    'mfrmOQTest2.dgTest1.CurrentCell() = (New DataGridCell(mfrmOQTest2.dgTest1.CurrentRowIndex + 1, 0))
                    'mfrmOQTest2.funcSaveOQTest2Data(1)
                    'mfrmOQTest2.dgTest2.CurrentCell() = (New DataGridCell(mfrmOQTest2.dgTest2.CurrentRowIndex + 1, 0))
                    'mfrmOQTest2.funcSaveOQTest2Data(2)
                    'mfrmOQTest2.dgTest3.CurrentCell() = (New DataGridCell(mfrmOQTest2.dgTest3.CurrentRowIndex + 1, 0))
                    'mfrmOQTest2.funcSaveOQTest2Data(3)
                    '--- "OQ User Training"
                Case ENUM_OQ_Modes.OQ_UserTraining
                    'mfrmUserTraining.dgTraining.CurrentCell() = (New DataGridCell(mfrmUserTraining.dgTraining.CurrentRowIndex + 1, 0))
                    'mfrmUserTraining.funcSaveOQUserTrainingData()
                    'mfrmUserTraining.dgUser.CurrentCell() = (New DataGridCell(mfrmUserTraining.dgUser.CurrentRowIndex + 1, 0))
                    'mfrmUserTraining.funcSaveOQUserData()

                    '--- "OQ Deficiency & Corrective Action"
                Case ENUM_OQ_Modes.OQ_Deficiency

                    'mfrmOQDeficiency.dgDeficiency.CurrentCell() = (New DataGridCell(mfrmOQDeficiency.dgDeficiency.CurrentRowIndex + 1, 0))
                    'mfrmOQDeficiency.funcSaveDeficiencyData()
                    'mfrmOQDeficiency.dgCompletedAccepted.CurrentCell() = (New DataGridCell(mfrmOQDeficiency.dgCompletedAccepted.CurrentRowIndex + 1, 0))
                    'mfrmOQDeficiency.funcSaveCompleteAcceptData()
                    '--- PQ Mode is selected 
                    '--- "PQ Approval"
                Case ENUM_PQ_Modes.PQ_Approval

                    'mfrmPQApproval.dgCustomer.CurrentCell() = (New DataGridCell(mfrmPQApproval.dgCustomer.CurrentRowIndex + 1, 0))
                    'mfrmPQApproval.funcSaveCustomerData()
                    'mfrmPQApproval.funcSaveSupplierData()

                    '--- "PQ Equipment Listing"
                Case ENUM_PQ_Modes.PQ_EquipmentList

                    'mfrmPQEquipmentList.dgEquipmentList.CurrentCell() = (New DataGridCell(mfrmPQEquipmentList.dgEquipmentList.CurrentRowIndex + 1, 0))
                    'mfrmPQEquipmentList.funcSaveEquipmentListData()

                    '--- "PQ Tests"
                Case ENUM_PQ_Modes.PQ_Test

                    '''mfrmPQTest1.dgTest.CurrentCell() = (New DataGridCell(mfrmPQTest1.dgTest.CurrentRowIndex + 1, 0))
                    '''mfrmPQTest1.funcSavePQTest1Data()

                    '--- "PQ Attachment1"
                Case ENUM_PQ_Modes.PQ_Attachment1

                    '''mfrmPQTest2.dgTest.CurrentCell() = (New DataGridCell(mfrmPQTest2.dgTest.CurrentRowIndex + 1, 0))
                    'mfrmPQTest2.funcSavePQTest2Data()
                    '--- "PQ Attachment2"
                Case ENUM_PQ_Modes.PQ_Attachment2
                    '''mfrmPQTest3.dgTest.CurrentCell() = (New DataGridCell(mfrmPQTest3.dgTest.CurrentRowIndex + 1, 0))
                    'mfrmPQTest3.funcSavePQTest3Data()

                    '--- "PQ Attachment3"
                Case ENUM_PQ_Modes.PQ_Attachment3
                    '''mfrmPQTest4.dgTest.CurrentCell() = (New DataGridCell(mfrmPQTest4.dgTest.CurrentRowIndex + 1, 0))
                    'mfrmPQTest4.funcSavePQTest4Data()

                    '--- "PQ Attachment4"
                    'Case ENUM_PQ_Modes.PQ_Attachment4
                    '--- "PQ Attachment5"
                    'Case ENUM_PQ_Modes.PQ_Attachment5

                    '''mfrmPQTest6.dgTest.CurrentCell() = (New DataGridCell(mfrmPQTest6.dgTest.CurrentRowIndex + 1, 0))
                    'mfrmPQTest6.funcSavePQTest6Data()

                    '--- "PQ Deficiency and Corrective Action"
                Case ENUM_PQ_Modes.PQ_Deficiency

                    '''mfrmPQDeficiency.dgDeficiency.CurrentCell() = (New DataGridCell(mfrmPQDeficiency.dgDeficiency.CurrentRowIndex + 1, 0))
                    '''mfrmPQDeficiency.funcSaveDeficiencyData()

                    '--- "PQ Warranty"
                Case ENUM_PQ_Modes.PQ_Warranty
                    '''mfrmWarranty.dgCompletedAccepted.CurrentCell() = (New DataGridCell(mfrmWarranty.dgCompletedAccepted.CurrentRowIndex + 1, 0))

                    '''mfrmWarranty.funcSavePQCompleteAcceptData()

            End Select

        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Function

    Private Function funcGetShowNextForm()
        '=====================================================================
        ' Procedure Name        :   funcGetShowNextForm
        ' Description           :   To Show Next Form.
        ' Purpose               :   To Show Next Form.
        ' Parameters Passed     :   Name of text to be displayed in Status Bar.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================
        Dim strFormTag As String
        Dim arrTag As String()
        Try
            tlbtnNext.Enabled = False
            strFormTag = Me.ActiveMdiChild.Tag
            arrTag = strFormTag.Split(",")
            If IsDBNull(arrTag(2)) = False Then
                If (arrTag(2) <> CStr(0)) Then
                    funcDisplayChildForm(arrTag(2))
                End If
            End If
            tlbtnNext.Enabled = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            ' gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Function funcGetShowPreviousForm()
        '=====================================================================
        ' Procedure Name        :   funcGetShowPreviousForm
        ' Description           :   To Show Previous Form.
        ' Purpose               :   To Show Previous Form.
        ' Parameters Passed     :   Name of text to be displayed in Status Bar.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================
        Dim strFormTag As String
        Dim arrTag As String()
        Try
            tlbtnPrevious.Enabled = False
            strFormTag = Me.ActiveMdiChild.Tag
            arrTag = strFormTag.Split(",")
            If IsDBNull(arrTag(0)) = False Then
                If (arrTag(0) <> CStr(0)) Then
                    funcDisplayChildForm(arrTag(0))
                End If
            End If
            tlbtnPrevious.Enabled = True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            ' gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

#Region "Functions Related for Menu/StatusBar "
    Private Sub funcUpdateStatusBar(ByVal str As String)
        '=====================================================================
        ' Procedure Name        :   funcUpdateStatusBar
        ' Description           :   To Update Status Bar and displa the Name which is passed to it.
        ' Purpose               :   To Update Status Bar and displa the Name which is passed to it.
        ' Parameters Passed     :   Name of text to be displayed in Status Bar.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================
        Try
            stsdQualification.Text = str
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try

    End Sub
    Private Sub subCheckMenuClicked(ByVal intMode As Integer)
        '=====================================================================
        ' Procedure Name        :   subCheckMenuClicked
        ' Description           :   To Check / Enable Appropriate Menu when Clicked. 
        ' Purpose               :   To Check / Enable Appropriate Menu when Clicked.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   February, 2004 
        ' Revisions             :
        '=====================================================================
        Try
            Select Case (intMode)
                Case ENUM_IQOQPQ_STATUS.IQ
                    mnuIQMode.Checked = True
                    mnuOQMode.Checked = False
                    mnuPQMode.Checked = False

                    mnuIQMode.RadioCheck = True
                    mnuOQMode.RadioCheck = False
                    mnuPQMode.RadioCheck = False
                    Exit Select
                Case ENUM_IQOQPQ_STATUS.OQ
                    mnuIQMode.Checked = False
                    mnuOQMode.Checked = True
                    mnuPQMode.Checked = False

                    mnuIQMode.RadioCheck = False
                    mnuOQMode.RadioCheck = True
                    mnuPQMode.RadioCheck = False
                    Exit Select
                Case ENUM_IQOQPQ_STATUS.PQ
                    mnuIQMode.Checked = False
                    mnuOQMode.Checked = False
                    mnuPQMode.Checked = True

                    mnuIQMode.RadioCheck = False
                    mnuOQMode.RadioCheck = False
                    mnuPQMode.RadioCheck = True
                    Exit Select
            End Select
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub
#End Region

    Private Sub funcMakeActiveForm()
        '=====================================================================
        ' Procedure Name        :   funcMakeActiveForm
        ' Description           :   To Close Previous Forms and make IQOQPQ form Active.
        ' Purpose               :   To Close Previous Forms and make IQOQPQ form Active.
        ' Parameters Passed     :   Name of text to be displayed in Status Bar.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   
        ' Created               :   January , 2003 
        ' Revisions             :
        '=====================================================================

        '---To Close all previous opened child form.
        Dim intCountForm As Integer
        Try
            Dim frmAct As New Form

            frmAct = Me '.ActiveForm()
            Application.DoEvents()
            Dim frmobj As New Form
            For Each frmobj In frmAct.MdiChildren
                'If Not Me.ActiveMdiChild Is Nothing Then
                '    Me.ActiveMdiChild.Close()
                '    'Me.ActiveMdiChild.Dispose()
                'End If
                frmobj.Close()
                Application.DoEvents()
            Next
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Function funcLockCurrentMode()
        '=====================================================================
        ' Procedure Name        :   funcLockCurrentMode
        ' Description           :   To Lock the current Mode.
        ' Purpose               :   To Lock the current Mode.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   February , 2003 
        ' Revisions             :
        '=====================================================================
        Dim strFormTag, strMode, strModeName As String
        Dim intMode As Integer
        Dim arrTag As String()

        Try
            strFormTag = Me.ActiveMdiChild.Tag
            arrTag = strFormTag.Split(",")
            If IsDBNull(arrTag(1)) = False Then
                strMode = arrTag(1).Chars(0)
                Select Case Val(Trim$(strMode) & "")
                    Case ENUM_IQOQPQ_STATUS.IQ
                        intMode = ENUM_IQOQPQ_STATUS.IQ
                        strModeName = "Installation Qualification"
                    Case ENUM_IQOQPQ_STATUS.OQ
                        intMode = ENUM_IQOQPQ_STATUS.OQ
                        strModeName = "Operational Qualification"
                    Case ENUM_IQOQPQ_STATUS.PQ
                        intMode = ENUM_IQOQPQ_STATUS.PQ
                        strModeName = "Performance Qualification"
                    Case Else
                        intMode = 0
                        strModeName = ""
                        Throw New Exception("Selected Mode is of Unrecognised Format")
                End Select
            End If

            If gobjMessageAdapter.ShowMessage("Do you really want to lock " & strModeName & "? " & vbCrLf & vbCrLf & "Note: Once the mode is locked, it will not be editable.", "Lock Mode", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = True Then
                If Not (gobjDataAccess.funcUpdateModeLockStatus(intMode)) Then
                    'gfuncShowMessage("Error", "Error in locking current mode status.", EnumMessageType.Information)
                    gobjMessageAdapter.ShowMessage(constErrorLockingModeStatus)
                Else
                    gobjMessageAdapter.ShowMessage(strModeName & " mode has been locked permanently.", "Locking Result", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                End If
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Function funcUnLockCurrentMode()
        '=====================================================================
        ' Procedure Name        :   funcLockCurrentMode
        ' Description           :   To Lock the current Mode.
        ' Purpose               :   To Lock the current Mode.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   February , 2003 
        ' Revisions             :
        '=====================================================================
        Dim strFormTag, strMode, strModeName As String
        Dim intMode As Integer
        Dim arrTag As String()

        Try
            strFormTag = Me.ActiveMdiChild.Tag
            arrTag = strFormTag.Split(",")
            If IsDBNull(arrTag(1)) = False Then
                strMode = arrTag(1).Chars(0)
                Select Case Val(Trim$(strMode) & "")
                    Case ENUM_IQOQPQ_STATUS.IQ
                        intMode = ENUM_IQOQPQ_STATUS.IQ
                        strModeName = "Installation Qualification"
                    Case ENUM_IQOQPQ_STATUS.OQ
                        intMode = ENUM_IQOQPQ_STATUS.OQ
                        strModeName = "Operational Qualification"
                    Case ENUM_IQOQPQ_STATUS.PQ
                        intMode = ENUM_IQOQPQ_STATUS.PQ
                        strModeName = "Performance Qualification"
                    Case Else
                        intMode = 0
                        strModeName = ""
                        Throw New Exception("Selected Mode is of Unrecognised Format")
                End Select
            End If

            If gobjMessageAdapter.ShowMessage("Do you really want to unlock " & strModeName & "? " & vbCrLf & vbCrLf & "Note: Once the mode is locked, it will not be editable.", "Lock Mode", MessageHandler.clsMessageHandler.enumMessageType.QuestionMessage) = True Then
                If Not (gobjDataAccess.funcUpdateModeUnLockStatus(intMode)) Then
                    'gfuncShowMessage("Error", "Error in locking current mode status.", EnumMessageType.Information)
                    gobjMessageAdapter.ShowMessage(constErrorLockingModeStatus)
                Else
                    gobjMessageAdapter.ShowMessage(strModeName & " mode has been unlocked permanently.", "Locking Result", MessageHandler.clsMessageHandler.enumMessageType.InformativeMessage)
                End If
            End If
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Sub subExportFiles(ByVal blnFlag As Boolean)
        Dim objStream As Stream
        Dim objIQOQPQ As New SaveFileDialog
        Try
            objIQOQPQ.InitialDirectory = strPath.GetCurrentDirectory.ToString & "\IQOQPQ"
            objIQOQPQ.Filter = "Text Files(*.rtf)|*.rtf"
            objIQOQPQ.RestoreDirectory = True

            If objIQOQPQ.ShowDialog() = DialogResult.OK Then
                'Call gfuncPrintExportIQOQPQ(tvwIQOQPQ.SelectedNode.Tag, blnFlag, True, objIQOQPQ.FileName)
                gfuncExportAll(objIQOQPQ.FileName)
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            ' gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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

    Private Function funcDisplayOnStatusbar(ByVal ptButtonIn As Point)
        Try
            'Comparing with mouse Coordinate for
            'Displaying Message
            If ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnLock).Rectangle.Left And ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnLock).Rectangle.Right Then
                StatusBarPanel1.Text = "Lock : To lock the current qualification"
            ElseIf ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnNext).Rectangle.Left And ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnNext).Rectangle.Right Then
                StatusBarPanel1.Text = "Next : To display next form "
            ElseIf ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnExit).Rectangle.Left And ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnExit).Rectangle.Right Then
                StatusBarPanel1.Text = "Exit: Return to Main Screen"
            ElseIf ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnPrevious).Rectangle.Left And ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbtnPrevious).Rectangle.Right Then
                StatusBarPanel1.Text = "Previous : To display previous form"
            ElseIf ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrPrint).Rectangle.Left And ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrPrint).Rectangle.Right Then
                StatusBarPanel1.Text = "Print : To print the selected form"
            ElseIf ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrExport).Rectangle.Left And ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrExport).Rectangle.Right Then
                StatusBarPanel1.Text = "Export : To export the all the forms"
            ElseIf ptButtonIn.X > tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrPrintAll).Rectangle.Left And ptButtonIn.X < tlbrIQOQPQ.Buttons(enumToolBarButtons.tlbrPrintAll).Rectangle.Right Then
                StatusBarPanel1.Text = "PrintAll : To print all the forms simultaneously"
            Else
                StatusBarPanel1.Text = ""
            End If

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            ' gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex)
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


    Private Sub mnuFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFile.Click

    End Sub

    'Private Sub mfrmPQTest(ByRef lblTestStatus As System.Windows.Forms.Label) Handles mfrmPQTest2.Return2IQOQPQ
    '    Try
    '        MsgBox("Saurabh")
    '        RaiseEvent Test_IQOQPQ_Attachment1(lblTestStatus)   ', dtParameters)  

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
    '        'objWait.Dispose()
    '        '---------------------------------------------------------
    '    End Try
    'End Sub

    Private Sub mfrmPQTest2_Test_IQOQPQ_Attachment1(ByRef dtParameters As DataTable, ByVal intCounter As Integer) Handles mfrmPQTest2.Test_IQOQPQ_Attachment1
        Try

            RaiseEvent Test_IQOQPQ_Attachment1(dtParameters, intCounter)  ', dtParameters)  

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mfrmPQTest3_Test_IQOQPQ_AttachmentII(ByRef dtParameters As DataTable, ByVal intCounter As Integer) Handles mfrmPQTest3.Test_IQOQPQ_AttachmentII
        Try

            RaiseEvent Test_IQOQPQ_AttachmentII(dtParameters, intCounter)  ', dtParameters)  

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub mfrmPQTest4_Test_IQOQPQ_AttachmentIII(ByRef dtParameters As DataTable, ByVal intCounter As Integer) Handles mfrmPQTest4.Test_IQOQPQ_AttachmentIII
        Try

            RaiseEvent Test_IQOQPQ_AttachmentIII(dtParameters, intCounter)  ', dtParameters)  

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
            'objWait.Dispose()
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub frmMDI_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        'code added by ; dinesh wagh on 5.4.2010
        'purpose : to save all data if we directly close the mdi form
        '------------------------------------------
        Try
            subCloseAllChildForm()
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub subCloseAllChildForm()
        'SubProcedure added by ; dinesh wagh on 8.4.2010
        'Purpose : To close all the form.
        Try
            Dim frmAct As New Form
            frmAct = Me
            Application.DoEvents()
            Dim frmobj As New Form
            For Each frmobj In frmAct.MdiChildren
                frmobj.Close()
                Application.DoEvents()
            Next
        Catch ex As Exception
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
        Finally
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
        End Try
    End Sub

    Private Sub MenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuUnlock_Click(sender As Object, e As EventArgs) Handles mnuUnlock.Click

    End Sub

    Private Sub MenuItem1_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class
