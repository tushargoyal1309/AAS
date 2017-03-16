Imports System
Imports BgThread
'=========For Analysis======
Imports AAS203.Common
Imports System.Threading
Imports AAS203Library
Imports AAS203Library.Analysis
'===========================


Public Class TestForm
    Inherits System.Windows.Forms.Form
    Implements BgThread.Iclient

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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents AasGraph1 As AAS203.AASGraph
    Friend WithEvents StatusBar1 As NETXP.Controls.Bars.StatusBar
    Friend WithEvents StatusBarPanelInfo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ProgressPanel As NETXP.Controls.Bars.ProgressPanel
    Friend WithEvents StatusBarPanelDate As System.Windows.Forms.StatusBarPanel
    Friend WithEvents CustomPanelRun As GradientPanel.CustomPanel
    Friend WithEvents lstMethodInformation As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMethod As System.Windows.Forms.TextBox
    Friend WithEvents lstMethodComments As System.Windows.Forms.ListView
    Friend WithEvents lbRunNos As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnStart = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.AasGraph1 = New AAS203.AASGraph
        Me.StatusBar1 = New NETXP.Controls.Bars.StatusBar
        Me.StatusBarPanelInfo = New System.Windows.Forms.StatusBarPanel
        Me.ProgressPanel = New NETXP.Controls.Bars.ProgressPanel
        Me.StatusBarPanelDate = New System.Windows.Forms.StatusBarPanel
        Me.CustomPanelRun = New GradientPanel.CustomPanel
        Me.lstMethodInformation = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMethod = New System.Windows.Forms.TextBox
        Me.lstMethodComments = New System.Windows.Forms.ListView
        Me.lbRunNos = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomPanelRun.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(440, 112)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(440, 144)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(136, 8)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(328, 88)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = ""
        '
        'AasGraph1
        '
        Me.AasGraph1.AldysGraphCursor = Nothing
        Me.AasGraph1.AldysGraphPrintColor = System.Drawing.Color.Black
        Me.AasGraph1.BackColor = System.Drawing.Color.LightGray
        Me.AasGraph1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AasGraph1.GraphDataSource = Nothing
        Me.AasGraph1.GraphImage = Nothing
        Me.AasGraph1.IsShowGrid = True
        Me.AasGraph1.Location = New System.Drawing.Point(8, 112)
        Me.AasGraph1.Name = "AasGraph1"
        Me.AasGraph1.Size = New System.Drawing.Size(464, 64)
        Me.AasGraph1.TabIndex = 3
        Me.AasGraph1.UseDefaultSettings = False
        Me.AasGraph1.XAxisDateMax = New Date(CType(0, Long))
        Me.AasGraph1.XAxisDateMin = New Date(CType(0, Long))
        Me.AasGraph1.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY
        Me.AasGraph1.XAxisLabel = Nothing
        Me.AasGraph1.XAxisMax = 0
        Me.AasGraph1.XAxisMin = 0
        Me.AasGraph1.XAxisMinorStep = 0
        Me.AasGraph1.XAxisScaleFormat = Nothing
        Me.AasGraph1.XAxisStep = 0
        Me.AasGraph1.XAxisType = AldysGraph.AxisType.Linear
        Me.AasGraph1.YAxisLabel = Nothing
        Me.AasGraph1.YAxisMax = 0
        Me.AasGraph1.YAxisMin = 0
        Me.AasGraph1.YAxisMinorStep = 0
        Me.AasGraph1.YAxisScaleFormat = Nothing
        Me.AasGraph1.YAxisStep = 0
        Me.AasGraph1.YAxisType = AldysGraph.AxisType.Linear
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 541)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanelInfo, Me.ProgressPanel, Me.StatusBarPanelDate})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(616, 24)
        Me.StatusBar1.TabIndex = 7
        Me.StatusBar1.Text = "StatusBar1"
        '
        'StatusBarPanelInfo
        '
        Me.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanelInfo.MinWidth = 40
        Me.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelInfo.Width = 371
        '
        'ProgressPanel
        '
        Me.ProgressPanel.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ProgressPanel.Maximum = 100
        Me.ProgressPanel.Minimum = 0
        Me.ProgressPanel.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.ProgressPanel.Value = 0
        Me.ProgressPanel.Width = 150
        '
        'StatusBarPanelDate
        '
        Me.StatusBarPanelDate.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanelDate.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.StatusBarPanelDate.MinWidth = 40
        Me.StatusBarPanelDate.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelDate.Text = "Current Date"
        Me.StatusBarPanelDate.Width = 79
        '
        'CustomPanelRun
        '
        Me.CustomPanelRun.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelRun.Controls.Add(Me.lstMethodInformation)
        Me.CustomPanelRun.Controls.Add(Me.Label4)
        Me.CustomPanelRun.Controls.Add(Me.Label3)
        Me.CustomPanelRun.Controls.Add(Me.Label2)
        Me.CustomPanelRun.Controls.Add(Me.Label1)
        Me.CustomPanelRun.Controls.Add(Me.txtMethod)
        Me.CustomPanelRun.Controls.Add(Me.lstMethodComments)
        Me.CustomPanelRun.Controls.Add(Me.lbRunNos)
        Me.CustomPanelRun.Location = New System.Drawing.Point(8, 272)
        Me.CustomPanelRun.Name = "CustomPanelRun"
        Me.CustomPanelRun.Size = New System.Drawing.Size(584, 253)
        Me.CustomPanelRun.TabIndex = 33
        '
        'lstMethodInformation
        '
        Me.lstMethodInformation.Location = New System.Drawing.Point(240, 48)
        Me.lstMethodInformation.Name = "lstMethodInformation"
        Me.lstMethodInformation.Size = New System.Drawing.Size(328, 108)
        Me.lstMethodInformation.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(240, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Method Comments"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(392, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Method"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(240, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Method Information"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Run Nos."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtMethod
        '
        Me.txtMethod.Location = New System.Drawing.Point(445, 14)
        Me.txtMethod.Name = "txtMethod"
        Me.txtMethod.Size = New System.Drawing.Size(120, 20)
        Me.txtMethod.TabIndex = 3
        Me.txtMethod.Text = ""
        '
        'lstMethodComments
        '
        Me.lstMethodComments.Location = New System.Drawing.Point(240, 184)
        Me.lstMethodComments.Name = "lstMethodComments"
        Me.lstMethodComments.Size = New System.Drawing.Size(328, 56)
        Me.lstMethodComments.TabIndex = 2
        '
        'lbRunNos
        '
        Me.lbRunNos.Location = New System.Drawing.Point(16, 29)
        Me.lbRunNos.Name = "lbRunNos"
        Me.lbRunNos.Size = New System.Drawing.Size(208, 212)
        Me.lbRunNos.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(248, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(168, 48)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = " To Front"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(72, 200)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(168, 48)
        Me.Button2.TabIndex = 35
        Me.Button2.Text = "To Back"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(496, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 32)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Label5"
        '
        'TestForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(616, 565)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CustomPanelRun)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.AasGraph1)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Name = "TestForm"
        Me.Text = "TestForm"
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanelDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomPanelRun.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private mController As clsBgThread

    Private Sub TestForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'mController = New clsBgThread(Me)
        'gobjfrmStatus.Show()

        Dim lg As Graphics = Label1.CreateGraphics
        Dim name As String = "XY"
        Dim number As String = "3"
        Dim b As System.Drawing.Brush

        Dim textsize As New SizeF(lg.MeasureString(name, New Font("Arial", FontStyle.Bold)))
        Dim wordwidth As Integer = CInt(textsize.Width)
        lg.Clear(Color.White)
        lg.DrawString(name, New Font("Arial", FontStyle.Bold), b, 10, 10)
        lg.DrawString(number, New Font("Arial", FontStyle.Bold), b, wordwidth + 5, 6)
        'b.Dispose()
        lg.Dispose()
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        mController.Start(New clsBgTurretOptimization)
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        mController.Cancel()
    End Sub

    Public Sub Completed(ByVal Cancelled As Boolean) Implements BgThread.Iclient.Completed
        'MessageBox.Show("Work Completed")
    End Sub

    Public Sub Display(ByVal strDataValue As String) Implements BgThread.Iclient.Display

        TextBox1.Text &= strDataValue
        TextBox1.Text &= vbCrLf

        TextBox1.Refresh()
        Application.DoEvents()

    End Sub

    Public Sub Failed(ByVal e As System.Exception) Implements BgThread.Iclient.Failed
        MessageBox.Show(e.Message)
    End Sub

    Public Sub Start(ByVal clsBgThread As BgThread.clsBgThread) Implements BgThread.Iclient.Start
        'MessageBox.Show("Work Started")
    End Sub

    'Code for communication Protocol
    'Public Function Check_Ignite() As Boolean
    '    '=====================================================================
    '    ' Procedure Name        : Check_Ignite
    '    ' Parameters Passed     : None
    '    ' Returns               : 
    '    ' Purpose               : 
    '    '                         
    '    ' Description           : 
    '    ' Assumptions           : 
    '    ' Dependencies          : 
    '    ' Author                : 
    '    ' Created               : 
    '    ' Revisions             : 
    '    '=====================================================================

    '    Dim str As String
    '    'char 		str[80]="";
    '    Dim aa, ps1, ps2, ps3 As Integer
    '    Dim flag As Boolean = True
    '    'int   	aa, ps1, ps2, ps3, flag = TRUE;
    '    Dim data As Byte
    '    'BYTE  	data;
    '    Dim count As Integer = 1
    '    'int   	count=1;
    '    Try
    '        If Not Flame_Present(False) Then
    '                    ps1 = ps2 = ps3 = ON
    '            data = CHECK_BUR_PAR()
    '            If (data And AA_CONNECTED) = True Then
    '                        aa = ON
    '            Else
    '                aa = OFF
    '            End If
    '            data = CHECK_PS()
    '            If (data & AIR_NOK) = True Then
    '                ps1 = OFF
    '            End If
    '            If (data & N2O_NOK) = True Then
    '                ps2 = OFF
    '            End If
    '            If (data & FUEL_NOK) = True Then
    '                ps3 = OFF
    '            End If
    '            If ps1 = OFF Then

    '                Gerror_message_new("Low Air Pressure Switch on Tank and RETRY ", " ***PNEUMATICS ERROR *** ")
    '                flag = False
    '            End If
    '                	if aa != ON and ps2 = OFF then
    '                		Gerror_message_new("Low Nitrous Oxide Pressure Switch on N2O Tank and RETRY "," ***PNEUMATICS ERROR *** ");
    '                flag = False
    '            End If
    '            If ps3 = OFF Then
    '                	    Gerror_message_new("Low Fuel Pressure Switch on Fuel Tank and RETRY "," ***PNEUMATICS ERROR *** ");
    '                flag = False
    '            End If
    '            str = String.Copy("")
    '            If Not Ignite_Test() = GREEN Then
    '                flag = False

    '                If aa Then
    '                    str = String.Copy("Ready for Air-Acetelyne Flame ..  IGNITE ?")
    '                Else
    '                    str = String.Copy("Ready for N2O-Acetelyne Flame ..  IGNITE ?")
    '                End If
    '                If flag Then
    '                    If MessageBox.Show(str, "AUTO IGNITION", MessageBoxButtons.YesNo) = DialogResult.Yes Then
    '                        Ignite(True)
    '                    End If
    '                End If
    '            End If

    '            'if (flag){
    '            '	  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
    '            '//	  if (MessageBox(hpar, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
    '            '		 Ignite(TRUE);
    '            '	}
    '            While Not Flame_Present(False) And count < 3
    '                        count++
    '                If flag Then
    '                    If MessageBox.Show("Flame not Ignited. Retry?", "AUTO IGNITION", MessageBoxButtons.YesNo) = DialogResult.Yes Then
    '                        Ignite(True)
    '                    End If
    '                End If
    '            End While
    '        End If

    '        If Flame_Present(False) Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        '---------------------------------------------------------
    '        'Error Handling and logging
    '        gobjErrorHandler.ErrorDescription = ex.Message
    '        gobjErrorHandler.ErrorMessage = ex.Message
    '        gobjErrorHandler.WriteErrorLog(ex)
    '        '---------------------------------------------------------
    '        Return False
    '    Finally
    '        '---------------------------------------------------------
    '        'Writing Execution log
    '        If CONST_CREATE_EXECUTION_LOG = 1 Then
    '            gobjErrorHandler.WriteExecutionLog()
    '        End If
    '        '---------------------------------------------------------
    '    End Try


    'End Function


    '    Public Function Flame_Present(ByVal flag1 As Boolean) As Boolean
    '        '=====================================================================
    '        ' Procedure Name        : Flame_Present
    '        ' Parameters Passed     : None
    '        ' Returns               : 
    '        ' Purpose               : 
    '        '                         
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : 
    '        ' Created               : 
    '        ' Revisions             : 
    '        '=====================================================================
    '        'BOOL  S4FUNC Flame_Present(BOOL flag1)

    '        Dim st As Byte
    '        'BYTE st;
    '        Try
    '            If (Inst.Aaf Or Inst.N2of) = True Then
    '                'if (Inst.Aaf || Inst.N2of) {
    '                st = CHECK_PS()
    '                'st = CHECK_PS();
    '                If (st And FLAME_OK) = FLAME_OK Then
    '                    'if ((st&FLAME_OK) ==FLAME_OK)
    '                    Return True
    '                    'return TRUE;
    '                Else
    '                    'Else
    '                    Return False
    '                    'Return False
    '                End If


    '            Else
    '                'else
    '                If flag1 Then
    '                    'If (flag1) Then
    '                    Return True
    '                    'return TRUE;
    '                Else
    '                    'Else
    '                    Return False
    '                    'return FALSE;
    '                End If
    '            End If
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '            Return False
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try

    '    End Function


    '    ' Code from C++
    '    '//******************* TURRET.LIB **********************
    '    '//----------------------------
    '    'void    S4FUNC D2_OFF()
    '    '{
    '    'if(GetSRLamp())
    '    '		Transmit(SMHCLDIS, 0, 0, 0);
    '    'else
    '    ' Transmit(D2OFF, 0, 0, 0);
    '    '#If NEWHANDSHAKE Then
    '    ' Recev(TRUE);
    '    '#End If
    '    '//  c= D2OFF;  trans(c);
    '    '}
    '    '//---------------
    '    'void    S4FUNC D2_ON()
    '    '{
    '    'if(GetSRLamp()){
    '    '	if( Inst.Lamp_pos == 0x02 )
    '    '		Transmit(SMHCLENB, 1, 0, 0);
    '    '	else
    '    '		Transmit(SMHCLENB, 2, 0, 0);
    '    '}
    '    'else
    '    ' Transmit(D2ON, 0, 0, 0);
    '    '//  c= D2ON;  trans(c);
    '    '#If NEWHANDSHAKE Then
    '    ' Recev(TRUE);
    '    '#End If
    '    '}
    '    '//---------------------------
    '    '//--------------Line No.2800-
    '    '    BOOL 		S4FUNC Check_Ignite()
    '    '{
    '    '#If DEMO Then
    '    ' return TRUE;
    '    '#Else
    '    'char 		str[80]="";
    '    'int   	aa, ps1, ps2, ps3, flag = TRUE;
    '    'BYTE  	data;
    '    'int   	count=1;
    '    'HWND hpar=NULL;
    '    '	hpar = GetTopWindow(NULL);
    '    ' if(!Flame_Present(FALSE))  {
    '    '	ps1 = ps2 = ps3 = ON;
    '    '	data = CHECK_BUR_PAR();
    '    '	if (data & AA_CONNECTED) aa = ON;
    '    '	else aa = OFF;
    '    '	data  = CHECK_PS();
    '    '	if (data & AIR_NOK)  ps1 = OFF;
    '    '	if (data & N2O_NOK)  ps2 = OFF;
    '    '	if (data & FUEL_NOK) ps3 = OFF;
    '    '	if (ps1==OFF) {
    '    '	  Gerror_message_new("Low Air Pressure Switch on Tank and RETRY "," ***PNEUMATICS ERROR *** ");
    '    '	  flag=FALSE;
    '    '	 }
    '    '	if (aa!=ON && ps2==OFF) {
    '    '		Gerror_message_new("Low Nitrous Oxide Pressure Switch on N2O Tank and RETRY "," ***PNEUMATICS ERROR *** ");
    '    '		flag = FALSE;
    '    '	  }
    '    '	if (ps3==OFF) {
    '    '	  Gerror_message_new("Low Fuel Pressure Switch on Fuel Tank and RETRY "," ***PNEUMATICS ERROR *** ");
    '    '	  flag = FALSE;
    '    '	 }
    '    '	strcpy (str,"");
    '    '	if (Ignite_Test()!=GREEN)
    '    '	 flag=FALSE;
    '    '	if (aa) strcpy(str," Ready for Air-Acetelyne Flame ..  IGNITE ?");
    '    '	else strcpy(str," Ready for N2o-Acetelyne Flame ..  IGNITE ?");
    '    '	if (flag){
    '    '		  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
    '    '//	  if (MessageBox(hpar, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
    '    '		 Ignite(TRUE);
    '    '	}
    '    '	while(!Flame_Present(FALSE)&&count<3)	{
    '    '	  count++;
    '    '		if (flag)
    '    '//		  if (MessageBox(NULL, " Flame not Ignited . Retry ? ", " AUTO IGNITION ", MB_YESNO)==IDYES)
    '    '		  if (MessageBox(hpar, " Flame not Ignited . Retry ? ", " AUTO IGNITION ", MB_YESNO)==IDYES)
    '    '			 Ignite(TRUE);
    '    '	  }
    '    '  }
    '    ' if (Flame_Present(FALSE))
    '    '	return TRUE;
    '    ' else
    '    '	return FALSE;
    '    '#End If
    '    '}



    '    '    BOOL  S4FUNC Flame_Present(BOOL flag1)
    '    '{

    '    '#If DEMO Then
    '    ' return TRUE;
    '    '#Else
    '    'BYTE st;
    '    ' if (Inst.Aaf || Inst.N2of) {
    '    '	st = CHECK_PS();
    '    '	if ((st&FLAME_OK) ==FLAME_OK)
    '    '		return TRUE;
    '    '	else
    '    '		return FALSE;
    '    '  }
    '    ' else {
    '    '	if  (flag1)
    '    '	  return TRUE;
    '    '	else
    '    '	  return FALSE;
    '    '	}

    '    '#End If
    '    '}


    '    Public Function CHECK_BUR_PAR() As Byte
    '        '=====================================================================
    '        ' Procedure Name        : CHECK_BUR_PAR
    '        ' Parameters Passed     : None
    '        ' Returns               : 
    '        ' Purpose               : 
    '        '                         
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : 
    '        ' Created               : 
    '        ' Revisions             : 
    '        '=====================================================================
    '        Try
    '            Transmit(CHKBURNER, 0, 0, 0)
    '            Recev(True)
    '            Return Param1
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '            Return False
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try

    '    End Function
    '    'BYTE CHECK_BUR_PAR()
    '    '{
    '    ' Transmit(CHKBURNER, 0, 0 , 0);
    '    ' Recev(TRUE);
    '    '// c = CHKBURNER; trans(c); c = recev();
    '    'return Param1;
    '    '}



    '    Public Function CHECK_PS() As Byte
    '        '=====================================================================
    '        ' Procedure Name        : CHECK_PS
    '        ' Parameters Passed     : None
    '        ' Returns               : 
    '        ' Purpose               : 
    '        '                         
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : 
    '        ' Created               : 
    '        ' Revisions             : 
    '        '=====================================================================
    '        Try
    '            Transmit(PSSTATUS, 0, 0, 0)
    '            Recev(True)
    '            Return Param1
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '            Return False
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try

    '    End Function
    '    ' BYTE CHECK_PS()
    '    '{
    '    ' Transmit(PSSTATUS, 0,0, 0);
    '    '// c = PSSTATUS; trans(c); c = recev();
    '    ' Recev(TRUE);
    '    ' return Param1;
    '    '}



    '    Public Function Ignite_Test()
    '        '=====================================================================
    '        ' Procedure Name        : Ignite_Test
    '        ' Parameters Passed     : None
    '        ' Returns               : 
    '        ' Purpose               : 
    '        '                         
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : 
    '        ' Created               : 
    '        ' Revisions             : 
    '        '=====================================================================
    '        Dim st, st1 As Byte
    '        Dim ps1, ps2, ps3, aa, tr, dr As Boolean
    '        Dim flag As Integer = 0
    '        Try
    '            If (Not Inst.Aaf And notInst.N2Of) = True Then
    '                ps1 = ps2 = ps3 = True
    '                st = CHECK_PS()
    '                If (st And AIR_NOK) = True Then
    '                    ps1 = False
    '                End If
    '                If (st And N2O_NOK) = True Then
    '                    ps2 = False
    '                End If
    '                If (st And FUEL_NOK) = True Then
    '                    ps3 = False
    '                End If
    '                st1 = CHECK_BUR_PAR()
    '                If (st1 And AA_CONNECTED) = True Then
    '                    aa = True
    '                Else
    '                    aa = False
    '                End If
    '                If (st1 And TRAP_NOK) = True Then
    '                    tr = False
    '                Else
    '                    tr = True
    '                End If
    '                If (st1 And DOOR_NOK) = True Then
    '                    dr = False
    '                Else
    '                    dr = True
    '                End If
    '                If Not ps3 = True Then
    '                    flag = 2
    '                End If
    '                If Not ps1 = True Then
    '                    flag = 3
    '                End If
    '                If Not aa = True Then
    '                    If Not ps2 = True Then
    '                        flag = 4
    '                    End If
    '                End If
    '                If Not dr = True Then
    '                    flag = 5
    '                End If
    '                If Not tr = True Then
    '                    flag = 6
    '                End If
    '            Else
    '                Check_Flame()
    '                st = CHECK_PS()
    '                If (st And YELLOW_OK) = YELLOW_OK Then
    '                    flag = -2
    '                ElseIf (st And BLUE_OK) = BLUE_OK Then
    '                    flag = -1
    '                ElseIf (st And Flame_OK) = Flame_ok Then
    '                    flag = -1
    '                End If
    '            End If
    '            If flag = -1 Then
    '                Return blue
    '            End If
    '            If flag = -2 Then
    '                Return yellow
    '            End If
    '            If (flag) Then   'Same as Original
    '                Return red
    '            Else
    '                Return green
    '            End If
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '            Return False
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try

    '    End Function



    '    Public Function Ignite(ByVal flag1 As Boolean)  'Line No.2917
    '        '=====================================================================
    '        ' Procedure Name        : Ignite
    '        ' Parameters Passed     : None
    '        ' Returns               : 
    '        ' Purpose               : 
    '        '                         
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : 
    '        ' Created               : 
    '        ' Revisions             : 
    '        '=====================================================================
    '        Dim flag As Boolean = True
    '        Dim count As Integer = 0
    '        Dim data, aa As Byte
    '        Dim ch As Integer
    '        Dim Commflag As Boolean 'declared externally
    '        Try
    '            If Not Commflag = True Then
    '                Return
    '            End If
    '            '-------------Copied as it is-----------------------
    '                if( InstType == AA202)
    '        	     hwnd = Create_Window_Pneum("AA-202  AA FLAME");
    '            Else
    '        	    hwnd = Create_Window_Pneum("AA-203  AA FLAME");
    '                StHwnd=hwnd;
    '            End If
    '            '---------------------------------------------------
    '            Call ReinitInstParameters()
    '            Do
    '                    count++
    '                Status_Disp()
    '                If (flag And count = 5) = True Then
    '                    flag = False
    '                End If
    '                If Not flag1 = True Then
    '                    If Not Flame_Off() Then
    '                        Beep()
    '                            messagebox.Show(" Already Flame is Extinguished"," AUTOEXTINGUISH");
    '                    End If
    '                Else
    '                    data = CHECK_BUR_PAR()
    '                    If (data And AA_CONNECTED) = True Then
    '                            aa = on
    '                    Else
    '                        aa = off
    '                    End If
    '                    If aa = True Then
    '                        If Not Inst.Aaf = True Then
    '                            Inst.Aaf = AA_FLAME_ON()
    '                        Else
    '                            Beep()
    '                            MessageBox.Show("Already in AA-Flame")
    '                        End If
    '                    Else
    '                            ch = MessageBox.Show(hpar,"    Ready for flame    Click \n Yes for AA flame \n No for NA flame ", "AA AUTO-IGNITION ", MB_YESNOCANCEL);
    '                        If ch = IDYES Then
    '                            If Not Inst.Aaf = True Then
    '                                Inst.Aaf = AA_FLAME_ON()
    '                            Else
    '                                Beep()
    '                                MessageBox.Show("Already in AA-Flame", "AUTOIGNITION")
    '                            End If
    '                        ElseIf ch = IDNO Then
    '                            If Not Inst.N2of = True Then
    '                                Inst.N2of = N2_FLAME_ON()
    '                            Else
    '                                Beep()
    '                                MessageBox.Show(" Already in nA-Flame", " AUTOIGNITION")
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            Loop
    '            While count < 15
    '                Close_Window(hwnd, NULL)
    '                ReinitInstParameters()
    '                StHwnd = NULL
    '        End While
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '            Return False
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try

    '    End Function



    '    Public Function Status_Disp()      'Line no. 2870
    '        '=====================================================================
    '        ' Procedure Name        : Status_Disp
    '        ' Parameters Passed     : None
    '        ' Returns               : 
    '        ' Purpose               : 
    '        '                         
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : 
    '        ' Created               : 
    '        ' Revisions             : 
    '        '=====================================================================
    '        Dim line As String
    '        Dim status, st, st1 As Byte
    '        Dim flag As Boolean = True
    '        Dim Commflag As Boolean  'Declared Externally -> extern	BOOL Commflag;  
    '        Try
    '            If Not Commflag = True Then
    '                Return
    '            End If
    '                if StHwnd != NULL then
    '                status = GET_PNEUM_STATUS()
    '                'st=random(255); st1=random(255);
    '                st = CHECK_PS()
    '                st1 = CHECK_BUR_PAR()
    '                If (st And AIR_NOK) = True Then
    '                    flag = False
    '                    SetVal(IDC_PAIR, "ERROR")
    '                Else
    '                    SetVal(IDC_PAIR, "OK")
    '                End If
    '                If (st And N2O_NOK) = True Then
    '                    flag = False
    '                    SetVal(IDC_PN2O, "ERROR")
    '                Else
    '                    SetVal(IDC_PN2O, "OK")
    '                End If
    '                If (st And FUEL_NOK) = True Then
    '                    flag = False
    '                    SetVal(IDC_PFUEL, "ERROR")
    '                Else
    '                    SetVal(IDC_PFUEL, "OK")
    '                End If
    '                If (status And SAIR_NON) = True Then
    '                    flag = False
    '                    SetVal(IDC_PVAIR, "CLOSE")
    '                Else
    '                    SetVal(IDC_PVAIR, "OPEN")
    '                End If
    '                If (status And SN2O_ON) = True Then
    '                    SetVal(IDC_PVN2O, "OPEN")
    '                Else
    '                    flag = False
    '                    SetVal(IDC_PVN2O, "CLOSE")
    '                End If
    '                If (status And SFUEL_ON) = True Then
    '                    SetVal(IDC_PVFUEL, "OPEN")
    '                Else
    '                    flag = False
    '                    SetVal(IDC_PVFUEL, "CLOSE")
    '                End If
    '                If (st1 And AA_CONNECTED) = True Then
    '                    SetVal(IDC_BTYPE, "BTAA")
    '                Else
    '                    SetVal(IDC_BTYPE, "BTNA")
    '                End If
    '                If (st1 And TRAP_NOK) = True Then
    '                    flag = False
    '                    SetVal(IDC_TRAP, "TOPEN")
    '                Else
    '                    SetVal(IDC_TRAP, "OK")
    '                End If
    '                If (st1 And DOOR_NOK) = True Then
    '                    flag = False
    '                    SetVal(IDC_DTYPE, "DOPEN")
    '                Else
    '                    SetVal(IDC_DTYPE, "DCLOSE")
    '                End If
    '                If (st And YELLOW_OK) = YELLOW_OK Then
    '                    SetVal(IDC_FLAME, "YELLOW")
    '                ElseIf (st And BLUE_OK) = BLUE_OK Then
    '                    SetVal(IDC_FLAME, "BLUE")
    '                ElseIf (st And FLAME_OK) = FLAME_OK Then
    '                    SetVal(IDC_FLAME, "BYELLOW")
    '                ElseIf (flag) = True Then
    '                    SetVal(IDC_FLAME, "GREEN")
    '                Else
    '                    SetVal(IDC_FLAME, "RED")
    '                End If
    '            End If

    '            Get_NV_Pos()
    '            sprintf(line1, "%3.2f", Read_Fuel()) 'Nv pos
    '            SetWindowText(GetDlgItem(StHwnd, IDC_FR), line1)
    '            Get_BH_Pos()
    '            sprintf(line1, "%2.1f", ReadBurnerHeight())
    '            SetWindowText(GetDlgItem(StHwnd, IDC_BH), line1)
    '        UpdateWindow(StHwnd)
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '            Return False
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try

    '    End Function
    '    ' void	Status_Disp()
    '    '{
    '    'char  line1[80];
    '    'BYTE  status,st, st1;
    '    'BOOL	flag=TRUE;

    '    'if (!Commflag)
    '    '	 return;
    '    'if (StHwnd!=NULL){
    '    '  status = GET_PNEUM_STATUS();
    '    '//  st=random(255); st1=random(255);
    '    '  st = CHECK_PS();
    '    '  st1 = CHECK_BUR_PAR();
    '    '  if (st & AIR_NOK)	 		{  flag=FALSE; SetVal(IDC_PAIR, "ERROR");}
    '    '  else 	SetVal(IDC_PAIR, "OK");
    '    '  if (st & N2O_NOK)	 		{  flag=FALSE; SetVal(IDC_PN2O, "ERROR");}
    '    '  else 	SetVal(IDC_PN2O, "OK");
    '    '  if (st & FUEL_NOK)	 		{  flag=FALSE; SetVal(IDC_PFUEL, "ERROR");}
    '    '  else 	SetVal(IDC_PFUEL, "OK");
    '    '  if (status & SAIR_NON) 	{
    '    '		flag=FALSE; SetVal(IDC_PVAIR,"CLOSE");}
    '    '  else	SetVal(IDC_PVAIR,"OPEN");
    '    '  if (status & SN2O_ON)	 	SetVal(IDC_PVN2O, "OPEN");
    '    '  else	{  flag=FALSE; SetVal(IDC_PVN2O, "CLOSE");}
    '    '  if (status & SFUEL_ON)	SetVal(IDC_PVFUEL, "OPEN");
    '    '  else	{  flag=FALSE; SetVal(IDC_PVFUEL, "CLOSE");}
    '    '  if (st1 & AA_CONNECTED) 	SetVal(IDC_BTYPE, "BTAA");
    '    '  else 	SetVal(IDC_BTYPE, "BTNA");
    '    '  if (st1 & TRAP_NOK) {  flag=FALSE; SetVal(IDC_TRAP, "TOPEN");}
    '    '  else SetVal(IDC_TRAP, "OK");
    '    '  if (st1 &DOOR_NOK) {  flag=FALSE; SetVal(IDC_DTYPE, "DOPEN");}
    '    '  else SetVal(IDC_DTYPE, "DCLOSE");
    '    '  if ((st&YELLOW_OK) ==YELLOW_OK) 		SetVal(IDC_FLAME, "YELLOW");
    '    '  else if ((st&BLUE_OK)==BLUE_OK)  	SetVal(IDC_FLAME, "BLUE");
    '    '  else if ((st & FLAME_OK)==FLAME_OK) 	SetVal(IDC_FLAME, "BYELLOW");
    '    '  else if (flag)	SetVal(IDC_FLAME, "GREEN");
    '    '  else SetVal(IDC_FLAME, "RED");
    '    '  Get_NV_Pos();
    '    '  sprintf(line1,"%3.2f", Read_Fuel());	// Nv pos
    '    '  SetWindowText(GetDlgItem(StHwnd, IDC_FR),line1);
    '    '  Get_BH_Pos();
    '    '  sprintf(line1,"%2.1f", ReadBurnerHeight());
    '    '  SetWindowText(GetDlgItem(StHwnd, IDC_BH),line1);
    '    '  UpdateWindow (StHwnd) ;
    '    ' }
    '    '}


    '    Public Function ReinitInstParameters()  'Line No.3509
    '        '=====================================================================
    '        ' Procedure Name        : ReinitInstParameters
    '        ' Parameters Passed     : None
    '        ' Returns               : 
    '        ' Purpose               : 
    '        '                         
    '        ' Description           : 
    '        ' Assumptions           : 
    '        ' Dependencies          : 
    '        ' Author                : 
    '        ' Created               : 
    '        ' Revisions             : 
    '        '=====================================================================
    '        Dim i, dcur As Integer
    '        Dim lampcur, warmupcur As Double
    '        Try
    '            If Not Commflag = True Then
    '                Return
    '            End If
    '            If Inst.Lamp_pos >= 1 And Inst.Lamp_pos <= 6 Then
    '                'All_Lamp_Off();
    '                If Inst.Mode = AA Or Inst.Mode = HCLE Or Inst.Mode = AABGC Or Inst.Mode = AABGCSR Then
    '                    lampcur = Inst.Cur
    '        		warmupcur=Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur
    '                    For i = 1 To 6
    '                        If i = Inst.Lamp_pos Or ((Inst.Lamp_warm > 0 And Inst.Lamp_warm < 7) And (i = Inst.Lamp_warm)) Then
    '                            If i = Inst.Lamp_warm Then
    '                                Set_HCL_Cur(warmupcur, Inst.Lamp_warm)
    '                            Else
    '                                Set_HCL_Cur(lampcur, Inst.Lamp_pos)
    '                            End If
    '                        Else
    '                            Set_HCL_Cur(0, i)
    '                        End If
    '                    Next i
    '                    Inst.Cur = lampcur
    '        	        Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur=warmupcur
    '                End If
    '                Set_PMT(Inst.Pmtv)
    '                If Inst.D2cur > 100 Then
    '                    Set_D2_Cur(Inst.D2cur)
    '                Else
    '                    dcur = 100
    '                      	Transmit(D2CUR, (BYTE)(dcur), (BYTE) (dcur>>8), 0)
    '#If NEWHANDSHAKE Then
    '        	 Recev(TRUE)
    '#End If
    '                    D2_OFF()
    '                End If
    '        End If
    '        Catch ex As Exception
    '            '---------------------------------------------------------
    '            'Error Handling and logging
    '            gobjErrorHandler.ErrorDescription = ex.Message
    '            gobjErrorHandler.ErrorMessage = ex.Message
    '            gobjErrorHandler.WriteErrorLog(ex)
    '            '---------------------------------------------------------
    '            Return False
    '        Finally
    '            '---------------------------------------------------------
    '            'Writing Execution log
    '            If CONST_CREATE_EXECUTION_LOG = 1 Then
    '                gobjErrorHandler.WriteExecutionLog()
    '            End If
    '            '---------------------------------------------------------
    '        End Try

    '    End Function
    '    'void  S4FUNC ReinitInstParameters(void)
    '    '        int i,dcur;
    '    '    double lampcur,warmupcur;

    '    '     if (!Commflag)
    '    '    	return;
    '    '    if(Inst.Lamp_pos>=1 && Inst.Lamp_pos<=6) {
    '    '    //  All_Lamp_Off();
    '    '      if (Inst.Mode==AA || Inst.Mode ==HCLE || Inst.Mode==AABGC ||Inst.Mode==AABGCSR){
    '    '    		lampcur=Inst.Cur;
    '    '    		warmupcur=Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur;
    '    '    	  for(i=1;i<=6;i++){
    '    '    		  if( (i == Inst.Lamp_pos) || ((Inst.Lamp_warm>0 && Inst.Lamp_warm<7) && (i == Inst.Lamp_warm))){
    '    '    			  if(i == Inst.Lamp_warm)
    '    '    				  Set_HCL_Cur(warmupcur,Inst.Lamp_warm);
    '    '    			  else
    '    '    				  Set_HCL_Cur(lampcur,Inst.Lamp_pos);
    '    '    		  }
    '    '    		  else
    '    '    			  Set_HCL_Cur(0,i);
    '    '    	  }
    '    '    	  Inst.Cur=lampcur;
    '    '    	  Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur=warmupcur;
    '    '      }
    '    '      Set_PMT(Inst.Pmtv);
    '    '      if ( Inst.D2cur>100 )
    '    '    	 Set_D2_Cur(Inst.D2cur);
    '    '      else{
    '    '    	 dcur=100;
    '    '    	 Transmit(D2CUR, (BYTE)(dcur), (BYTE) (dcur>>8), 0);
    '    '#If NEWHANDSHAKE Then
    '    '    	 Recev(TRUE);
    '    '#End If
    '    '    	 D2_OFF();
    '    '      }
    '    '    }
    '    '    }


    Public Function AnalysisFunctions() As Boolean
        '======================Analysis Functions==========================================
    End Function



    'Private Function Calculate_Analysis_Graph_Param(ByVal curve As Double) As Double
    '        Dim FrqIntv As Double = 0.0
    '        Dim xmax1 As Double = 0
    '        Dim xmin1 As Double = 0
    '        Dim Fmin As Double = 0
    '        Dim Fmax As Double = 0
    '        Dim Fx As Double = 0
    '        Dim fn, tot1 As Integer

    '        If IsNothing(curve) Then
    '            Return 0.0
    '        End If

    '        'xmax1 = curve.ymax
    '        'xmin1 = curve.Ymin
    '        tot1 = (xmax1 - xmin1) * 60
    '        'FrqIntv = GetInterval(xmax1, xmin1, tot1, True)
    '        'fn = CInt(xax1 / FrqIntv)
    '        Fmax = CDbl(fn * FrqIntv)
    '        If xmax1 > Fmax Then
    '            Fmax = Fmax + FrqIntv
    '        End If
    '        fn = CInt(xmin1 / FrqIntv)
    '        Fmin = CDbl(fn * FrqIntv)

    '        'If (xmin < Fmin) Then
    '        '    Fmin = Fmin - FrqIntv
    '        'End If

    '        If (Fmin > xmin1) And (Not FrqIntv = -1.0) Then
    '            While (Fmin > xmin1)
    '                Fmax = Fmax + FrqIntv
    '            End While
    '        End If

    'c       'curve.
    '        'double	Calculate_Analysis_Graph_Param(CURVEDATA *Curve)
    '        '{
    '        'double	FrqIntv=0.0, xmax1=0, xmin1=0,Fmin=0, Fmax=0, Fx=0;
    '        'int		fn;
    '        'int		tot1;

    '        ' if (Curve==NULL)
    '        '	return 0.0;
    '        ' xmax1=Curve->Ymax;
    '        ' xmin1=Curve->Ymin;
    '        ' tot1 = (xmax1-xmin1)*60;
    '        ' FrqIntv =GetInterval(xmax1, xmin1, tot1, TRUE);
    '        ' fn = (int)  (xmax1/ FrqIntv);
    '        ' Fmax = (double) fn*  FrqIntv;
    '        '            If (xmax1 > Fmax) Then
    '        '	Fmax+= FrqIntv;
    '        ' fn = (int)  ( xmin1/ FrqIntv);
    '        ' Fmin = (double) fn*FrqIntv;
    '        '                If (xmin1 < Fmin) Then
    '        '  Fmin-= FrqIntv;

    '        ' if (Fmin> xmin1&& FrqIntv!=(double) -1.0){
    '        '                        While (Fmin > xmin1)
    '        '		 Fmin-=FrqIntv;
    '        '  }
    '        ' if (Fmax< xmax1&& FrqIntv!=(double) -1.0){
    '        '                                While (Fmax < xmax1)
    '        '		Fmax+=FrqIntv;
    '        '  }

    '        ' Curve->Ymin = Fmin;
    '        ' Curve->Ymax= Fmax;
    '        ' Curve->FrqIntv =FrqIntv;

    '        ' xmax1=Curve->Xmax;
    '        ' xmin1=Curve->Xmin;
    '        ' tot1 = 60; //(xmax1-xmin1)*18.2;
    '        ' Fx =GetInterval(xmax1, xmin1, tot1, TRUE);
    '        '                                    If (Fx) Then
    '        '	 fn = (int)  (xmax1/ Fx);
    '        '                                    Else
    '        '	 fn = 0;
    '        ' Fmax = (double) fn*  Fx;
    '        '                                        If (xmax1 > Fmax) Then
    '        '	Fmax+= Fx;
    '        ' Curve->Xmin = xmin1;
    '        ' Curve->Xmax = Fmax;
    '        ' Curve->XIntv =GetInterval(Curve->Xmax, Curve->Xmin,	tot1, TRUE);

    '        '// Calculate_Xparameters(Curve);
    '        ' return FrqIntv;
    '        '}

    '    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'gobjfrmStatus.BringToFront()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'gobjfrmStatus.SendToBack()
    End Sub

End Class
