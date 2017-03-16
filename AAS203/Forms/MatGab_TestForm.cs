using System;
using BgThread;
//=========For Analysis======
using AAS203.Common;
using System.Threading;
using AAS203Library;
using AAS203Library.Analysis;
//===========================


public class TestForm : System.Windows.Forms.Form, BgThread.Iclient
{

	#Region " Windows Form Designer generated code "

	public TestForm()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing) {
			if (!(components == null)) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer

	private System.ComponentModel.IContainer components;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	internal System.Windows.Forms.TextBox TextBox1;
	internal System.Windows.Forms.Button btnStart;
	internal System.Windows.Forms.Button btnStop;
	internal AAS203.AASGraph AasGraph1;
	internal NETXP.Controls.Bars.StatusBar StatusBar1;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelInfo;
	internal NETXP.Controls.Bars.ProgressPanel ProgressPanel;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelDate;
	internal GradientPanel.CustomPanel CustomPanelRun;
	internal System.Windows.Forms.ListBox lstMethodInformation;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.TextBox txtMethod;
	internal System.Windows.Forms.ListView lstMethodComments;
	internal System.Windows.Forms.ListBox lbRunNos;
	internal System.Windows.Forms.Button Button1;
	internal System.Windows.Forms.Button Button2;
	internal System.Windows.Forms.Label Label5;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.btnStart = new System.Windows.Forms.Button();
		this.btnStop = new System.Windows.Forms.Button();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.AasGraph1 = new AAS203.AASGraph();
		this.StatusBar1 = new NETXP.Controls.Bars.StatusBar();
		this.StatusBarPanelInfo = new System.Windows.Forms.StatusBarPanel();
		this.ProgressPanel = new NETXP.Controls.Bars.ProgressPanel();
		this.StatusBarPanelDate = new System.Windows.Forms.StatusBarPanel();
		this.CustomPanelRun = new GradientPanel.CustomPanel();
		this.lstMethodInformation = new System.Windows.Forms.ListBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.txtMethod = new System.Windows.Forms.TextBox();
		this.lstMethodComments = new System.Windows.Forms.ListView();
		this.lbRunNos = new System.Windows.Forms.ListBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.Label5 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).BeginInit();
		this.CustomPanelRun.SuspendLayout();
		this.SuspendLayout();
		//
		//btnStart
		//
		this.btnStart.Location = new System.Drawing.Point(440, 112);
		this.btnStart.Name = "btnStart";
		this.btnStart.TabIndex = 0;
		this.btnStart.Text = "Start";
		//
		//btnStop
		//
		this.btnStop.Location = new System.Drawing.Point(440, 144);
		this.btnStop.Name = "btnStop";
		this.btnStop.TabIndex = 1;
		this.btnStop.Text = "Stop";
		//
		//TextBox1
		//
		this.TextBox1.Location = new System.Drawing.Point(136, 8);
		this.TextBox1.Multiline = true;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.TextBox1.Size = new System.Drawing.Size(328, 88);
		this.TextBox1.TabIndex = 2;
		this.TextBox1.Text = "";
		//
		//AasGraph1
		//
		this.AasGraph1.AldysGraphCursor = null;
		this.AasGraph1.AldysGraphPrintColor = System.Drawing.Color.Black;
		this.AasGraph1.BackColor = System.Drawing.Color.LightGray;
		this.AasGraph1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.AasGraph1.GraphDataSource = null;
		this.AasGraph1.GraphImage = null;
		this.AasGraph1.IsShowGrid = true;
		this.AasGraph1.Location = new System.Drawing.Point(8, 112);
		this.AasGraph1.Name = "AasGraph1";
		this.AasGraph1.Size = new System.Drawing.Size(464, 64);
		this.AasGraph1.TabIndex = 3;
		this.AasGraph1.UseDefaultSettings = false;
		this.AasGraph1.XAxisDateMax = new System.DateTime((long)0);
		this.AasGraph1.XAxisDateMin = new System.DateTime((long)0);
		this.AasGraph1.XAxisDateScaleFormat = AAS203.AASGraph.enumDateScaleFormat.YYYY;
		this.AasGraph1.XAxisLabel = null;
		this.AasGraph1.XAxisMax = 0;
		this.AasGraph1.XAxisMin = 0;
		this.AasGraph1.XAxisMinorStep = 0;
		this.AasGraph1.XAxisScaleFormat = null;
		this.AasGraph1.XAxisStep = 0;
		this.AasGraph1.XAxisType = AldysGraph.AxisType.Linear;
		this.AasGraph1.YAxisLabel = null;
		this.AasGraph1.YAxisMax = 0;
		this.AasGraph1.YAxisMin = 0;
		this.AasGraph1.YAxisMinorStep = 0;
		this.AasGraph1.YAxisScaleFormat = null;
		this.AasGraph1.YAxisStep = 0;
		this.AasGraph1.YAxisType = AldysGraph.AxisType.Linear;
		//
		//StatusBar1
		//
		this.StatusBar1.Location = new System.Drawing.Point(0, 541);
		this.StatusBar1.Name = "StatusBar1";
		this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
			this.StatusBarPanelInfo,
			this.ProgressPanel,
			this.StatusBarPanelDate
		});
		this.StatusBar1.ShowPanels = true;
		this.StatusBar1.Size = new System.Drawing.Size(616, 24);
		this.StatusBar1.TabIndex = 7;
		this.StatusBar1.Text = "StatusBar1";
		//
		//StatusBarPanelInfo
		//
		this.StatusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
		this.StatusBarPanelInfo.MinWidth = 40;
		this.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.StatusBarPanelInfo.Width = 371;
		//
		//ProgressPanel
		//
		this.ProgressPanel.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
		this.ProgressPanel.Maximum = 100;
		this.ProgressPanel.Minimum = 0;
		this.ProgressPanel.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.ProgressPanel.Value = 0;
		this.ProgressPanel.Width = 150;
		//
		//StatusBarPanelDate
		//
		this.StatusBarPanelDate.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
		this.StatusBarPanelDate.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
		this.StatusBarPanelDate.MinWidth = 40;
		this.StatusBarPanelDate.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.StatusBarPanelDate.Text = "Current Date";
		this.StatusBarPanelDate.Width = 79;
		//
		//CustomPanelRun
		//
		this.CustomPanelRun.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelRun.Controls.Add(this.lstMethodInformation);
		this.CustomPanelRun.Controls.Add(this.Label4);
		this.CustomPanelRun.Controls.Add(this.Label3);
		this.CustomPanelRun.Controls.Add(this.Label2);
		this.CustomPanelRun.Controls.Add(this.Label1);
		this.CustomPanelRun.Controls.Add(this.txtMethod);
		this.CustomPanelRun.Controls.Add(this.lstMethodComments);
		this.CustomPanelRun.Controls.Add(this.lbRunNos);
		this.CustomPanelRun.Location = new System.Drawing.Point(8, 272);
		this.CustomPanelRun.Name = "CustomPanelRun";
		this.CustomPanelRun.Size = new System.Drawing.Size(584, 253);
		this.CustomPanelRun.TabIndex = 33;
		//
		//lstMethodInformation
		//
		this.lstMethodInformation.Location = new System.Drawing.Point(240, 48);
		this.lstMethodInformation.Name = "lstMethodInformation";
		this.lstMethodInformation.Size = new System.Drawing.Size(328, 108);
		this.lstMethodInformation.TabIndex = 8;
		//
		//Label4
		//
		this.Label4.Location = new System.Drawing.Point(240, 165);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(160, 18);
		this.Label4.TabIndex = 7;
		this.Label4.Text = "Method Comments";
		this.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
		//
		//Label3
		//
		this.Label3.Location = new System.Drawing.Point(392, 19);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(48, 16);
		this.Label3.TabIndex = 6;
		this.Label3.Text = "Method";
		//
		//Label2
		//
		this.Label2.Location = new System.Drawing.Point(240, 30);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(104, 16);
		this.Label2.TabIndex = 5;
		this.Label2.Text = "Method Information";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
		//
		//Label1
		//
		this.Label1.Location = new System.Drawing.Point(17, 8);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(112, 16);
		this.Label1.TabIndex = 4;
		this.Label1.Text = "Run Nos.";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
		//
		//txtMethod
		//
		this.txtMethod.Location = new System.Drawing.Point(445, 14);
		this.txtMethod.Name = "txtMethod";
		this.txtMethod.Size = new System.Drawing.Size(120, 20);
		this.txtMethod.TabIndex = 3;
		this.txtMethod.Text = "";
		//
		//lstMethodComments
		//
		this.lstMethodComments.Location = new System.Drawing.Point(240, 184);
		this.lstMethodComments.Name = "lstMethodComments";
		this.lstMethodComments.Size = new System.Drawing.Size(328, 56);
		this.lstMethodComments.TabIndex = 2;
		//
		//lbRunNos
		//
		this.lbRunNos.Location = new System.Drawing.Point(16, 29);
		this.lbRunNos.Name = "lbRunNos";
		this.lbRunNos.Size = new System.Drawing.Size(208, 212);
		this.lbRunNos.TabIndex = 0;
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(248, 200);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(168, 48);
		this.Button1.TabIndex = 34;
		this.Button1.Text = " To Front";
		//
		//Button2
		//
		this.Button2.Location = new System.Drawing.Point(72, 200);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(168, 48);
		this.Button2.TabIndex = 35;
		this.Button2.Text = "To Back";
		//
		//Label5
		//
		this.Label5.Location = new System.Drawing.Point(496, 40);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(88, 32);
		this.Label5.TabIndex = 36;
		this.Label5.Text = "Label5";
		//
		//TestForm
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(616, 565);
		this.Controls.Add(this.Label5);
		this.Controls.Add(this.Button2);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.CustomPanelRun);
		this.Controls.Add(this.StatusBar1);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.AasGraph1);
		this.Controls.Add(this.btnStop);
		this.Controls.Add(this.btnStart);
		this.Name = "TestForm";
		this.Text = "TestForm";
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ProgressPanel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelDate).EndInit();
		this.CustomPanelRun.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#End Region


	private clsBgThread mController;
	private void  // ERROR: Handles clauses are not supported in C#
TestForm_Load(System.Object sender, System.EventArgs e)
	{
		//mController = New clsBgThread(Me)
		//gobjfrmStatus.Show()

		Graphics lg = Label1.CreateGraphics;
		string name = "XY";
		string number = "3";
		System.Drawing.Brush b;

		SizeF textsize = new SizeF(lg.MeasureString(name, new Font("Arial", FontStyle.Bold)));
		int wordwidth = (int)textsize.Width;
		lg.Clear(Color.White);
		lg.DrawString(name, new Font("Arial", FontStyle.Bold), b, 10, 10);
		lg.DrawString(number, new Font("Arial", FontStyle.Bold), b, wordwidth + 5, 6);
		//b.Dispose()
		lg.Dispose();
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnStart_Click(System.Object sender, System.EventArgs e)
	{
		mController.Start(new clsBgTurretOptimization());
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnStop_Click(System.Object sender, System.EventArgs e)
	{
		mController.Cancel();
	}

	public void BgThread.Iclient.Completed(bool Cancelled)
	{
		//MessageBox.Show("Work Completed")
	}


	public void BgThread.Iclient.Display(string strDataValue)
	{
		TextBox1.Text += strDataValue;
		TextBox1.Text += vbCrLf;

		TextBox1.Refresh();
		Application.DoEvents();

	}

	public void BgThread.Iclient.Failed(System.Exception e)
	{
		MessageBox.Show(e.Message);
	}

	public void BgThread.Iclient.Start(BgThread.clsBgThread clsBgThread)
	{
		//MessageBox.Show("Work Started")
	}

	//Code for communication Protocol
	//Public Function Check_Ignite() As Boolean
	//    '=====================================================================
	//    ' Procedure Name        : Check_Ignite
	//    ' Parameters Passed     : None
	//    ' Returns               : 
	//    ' Purpose               : 
	//    '                         
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : 
	//    ' Created               : 
	//    ' Revisions             : 
	//    '=====================================================================

	//    Dim str As String
	//    'char 		str[80]="";
	//    Dim aa, ps1, ps2, ps3 As Integer
	//    Dim flag As Boolean = True
	//    'int   	aa, ps1, ps2, ps3, flag = TRUE;
	//    Dim data As Byte
	//    'BYTE  	data;
	//    Dim count As Integer = 1
	//    'int   	count=1;
	//    Try
	//        If Not Flame_Present(False) Then
	//                    ps1 = ps2 = ps3 = ON
	//            data = CHECK_BUR_PAR()
	//            If (data And AA_CONNECTED) = True Then
	//                        aa = ON
	//            Else
	//                aa = OFF
	//            End If
	//            data = CHECK_PS()
	//            If (data & AIR_NOK) = True Then
	//                ps1 = OFF
	//            End If
	//            If (data & N2O_NOK) = True Then
	//                ps2 = OFF
	//            End If
	//            If (data & FUEL_NOK) = True Then
	//                ps3 = OFF
	//            End If
	//            If ps1 = OFF Then

	//                Gerror_message_new("Low Air Pressure Switch on Tank and RETRY ", " ***PNEUMATICS ERROR *** ")
	//                flag = False
	//            End If
	//                	if aa != ON and ps2 = OFF then
	//                		Gerror_message_new("Low Nitrous Oxide Pressure Switch on N2O Tank and RETRY "," ***PNEUMATICS ERROR *** ");
	//                flag = False
	//            End If
	//            If ps3 = OFF Then
	//                	    Gerror_message_new("Low Fuel Pressure Switch on Fuel Tank and RETRY "," ***PNEUMATICS ERROR *** ");
	//                flag = False
	//            End If
	//            str = String.Copy("")
	//            If Not Ignite_Test() = GREEN Then
	//                flag = False

	//                If aa Then
	//                    str = String.Copy("Ready for Air-Acetelyne Flame ..  IGNITE ?")
	//                Else
	//                    str = String.Copy("Ready for N2O-Acetelyne Flame ..  IGNITE ?")
	//                End If
	//                If flag Then
	//                    If MessageBox.Show(str, "AUTO IGNITION", MessageBoxButtons.YesNo) = DialogResult.Yes Then
	//                        Ignite(True)
	//                    End If
	//                End If
	//            End If

	//            'if (flag){
	//            '	  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
	//            '//	  if (MessageBox(hpar, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
	//            '		 Ignite(TRUE);
	//            '	}
	//            While Not Flame_Present(False) And count < 3
	//                        count++
	//                If flag Then
	//                    If MessageBox.Show("Flame not Ignited. Retry?", "AUTO IGNITION", MessageBoxButtons.YesNo) = DialogResult.Yes Then
	//                        Ignite(True)
	//                    End If
	//                End If
	//            End While
	//        End If

	//        If Flame_Present(False) Then
	//            Return True
	//        Else
	//            Return False
	//        End If
	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        '---------------------------------------------------------
	//        Return False
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        '---------------------------------------------------------
	//    End Try


	//End Function


	//    Public Function Flame_Present(ByVal flag1 As Boolean) As Boolean
	//        '=====================================================================
	//        ' Procedure Name        : Flame_Present
	//        ' Parameters Passed     : None
	//        ' Returns               : 
	//        ' Purpose               : 
	//        '                         
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : 
	//        ' Created               : 
	//        ' Revisions             : 
	//        '=====================================================================
	//        'BOOL  S4FUNC Flame_Present(BOOL flag1)

	//        Dim st As Byte
	//        'BYTE st;
	//        Try
	//            If (Inst.Aaf Or Inst.N2of) = True Then
	//                'if (Inst.Aaf || Inst.N2of) {
	//                st = CHECK_PS()
	//                'st = CHECK_PS();
	//                If (st And FLAME_OK) = FLAME_OK Then
	//                    'if ((st&FLAME_OK) ==FLAME_OK)
	//                    Return True
	//                    'return TRUE;
	//                Else
	//                    'Else
	//                    Return False
	//                    'Return False
	//                End If


	//            Else
	//                'else
	//                If flag1 Then
	//                    'If (flag1) Then
	//                    Return True
	//                    'return TRUE;
	//                Else
	//                    'Else
	//                    Return False
	//                    'return FALSE;
	//                End If
	//            End If
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            Return False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function


	//    ' Code from C++
	//    '//******************* TURRET.LIB **********************
	//    '//----------------------------
	//    'void    S4FUNC D2_OFF()
	//    '{
	//    'if(GetSRLamp())
	//    '		Transmit(SMHCLDIS, 0, 0, 0);
	//    'else
	//    ' Transmit(D2OFF, 0, 0, 0);
	//    '#If NEWHANDSHAKE Then
	//    ' Recev(TRUE);
	//    '#End If
	//    '//  c= D2OFF;  trans(c);
	//    '}
	//    '//---------------
	//    'void    S4FUNC D2_ON()
	//    '{
	//    'if(GetSRLamp()){
	//    '	if( Inst.Lamp_pos == 0x02 )
	//    '		Transmit(SMHCLENB, 1, 0, 0);
	//    '	else
	//    '		Transmit(SMHCLENB, 2, 0, 0);
	//    '}
	//    'else
	//    ' Transmit(D2ON, 0, 0, 0);
	//    '//  c= D2ON;  trans(c);
	//    '#If NEWHANDSHAKE Then
	//    ' Recev(TRUE);
	//    '#End If
	//    '}
	//    '//---------------------------
	//    '//--------------Line No.2800-
	//    '    BOOL 		S4FUNC Check_Ignite()
	//    '{
	//    '#If DEMO Then
	//    ' return TRUE;
	//    '#Else
	//    'char 		str[80]="";
	//    'int   	aa, ps1, ps2, ps3, flag = TRUE;
	//    'BYTE  	data;
	//    'int   	count=1;
	//    'HWND hpar=NULL;
	//    '	hpar = GetTopWindow(NULL);
	//    ' if(!Flame_Present(FALSE))  {
	//    '	ps1 = ps2 = ps3 = ON;
	//    '	data = CHECK_BUR_PAR();
	//    '	if (data & AA_CONNECTED) aa = ON;
	//    '	else aa = OFF;
	//    '	data  = CHECK_PS();
	//    '	if (data & AIR_NOK)  ps1 = OFF;
	//    '	if (data & N2O_NOK)  ps2 = OFF;
	//    '	if (data & FUEL_NOK) ps3 = OFF;
	//    '	if (ps1==OFF) {
	//    '	  Gerror_message_new("Low Air Pressure Switch on Tank and RETRY "," ***PNEUMATICS ERROR *** ");
	//    '	  flag=FALSE;
	//    '	 }
	//    '	if (aa!=ON && ps2==OFF) {
	//    '		Gerror_message_new("Low Nitrous Oxide Pressure Switch on N2O Tank and RETRY "," ***PNEUMATICS ERROR *** ");
	//    '		flag = FALSE;
	//    '	  }
	//    '	if (ps3==OFF) {
	//    '	  Gerror_message_new("Low Fuel Pressure Switch on Fuel Tank and RETRY "," ***PNEUMATICS ERROR *** ");
	//    '	  flag = FALSE;
	//    '	 }
	//    '	strcpy (str,"");
	//    '	if (Ignite_Test()!=GREEN)
	//    '	 flag=FALSE;
	//    '	if (aa) strcpy(str," Ready for Air-Acetelyne Flame ..  IGNITE ?");
	//    '	else strcpy(str," Ready for N2o-Acetelyne Flame ..  IGNITE ?");
	//    '	if (flag){
	//    '		  if (MessageBox(NULL, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
	//    '//	  if (MessageBox(hpar, str , " AUTO IGNITION ", MB_YESNO)==IDYES)
	//    '		 Ignite(TRUE);
	//    '	}
	//    '	while(!Flame_Present(FALSE)&&count<3)	{
	//    '	  count++;
	//    '		if (flag)
	//    '//		  if (MessageBox(NULL, " Flame not Ignited . Retry ? ", " AUTO IGNITION ", MB_YESNO)==IDYES)
	//    '		  if (MessageBox(hpar, " Flame not Ignited . Retry ? ", " AUTO IGNITION ", MB_YESNO)==IDYES)
	//    '			 Ignite(TRUE);
	//    '	  }
	//    '  }
	//    ' if (Flame_Present(FALSE))
	//    '	return TRUE;
	//    ' else
	//    '	return FALSE;
	//    '#End If
	//    '}



	//    '    BOOL  S4FUNC Flame_Present(BOOL flag1)
	//    '{

	//    '#If DEMO Then
	//    ' return TRUE;
	//    '#Else
	//    'BYTE st;
	//    ' if (Inst.Aaf || Inst.N2of) {
	//    '	st = CHECK_PS();
	//    '	if ((st&FLAME_OK) ==FLAME_OK)
	//    '		return TRUE;
	//    '	else
	//    '		return FALSE;
	//    '  }
	//    ' else {
	//    '	if  (flag1)
	//    '	  return TRUE;
	//    '	else
	//    '	  return FALSE;
	//    '	}

	//    '#End If
	//    '}


	//    Public Function CHECK_BUR_PAR() As Byte
	//        '=====================================================================
	//        ' Procedure Name        : CHECK_BUR_PAR
	//        ' Parameters Passed     : None
	//        ' Returns               : 
	//        ' Purpose               : 
	//        '                         
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : 
	//        ' Created               : 
	//        ' Revisions             : 
	//        '=====================================================================
	//        Try
	//            Transmit(CHKBURNER, 0, 0, 0)
	//            Recev(True)
	//            Return Param1
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            Return False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function
	//    'BYTE CHECK_BUR_PAR()
	//    '{
	//    ' Transmit(CHKBURNER, 0, 0 , 0);
	//    ' Recev(TRUE);
	//    '// c = CHKBURNER; trans(c); c = recev();
	//    'return Param1;
	//    '}



	//    Public Function CHECK_PS() As Byte
	//        '=====================================================================
	//        ' Procedure Name        : CHECK_PS
	//        ' Parameters Passed     : None
	//        ' Returns               : 
	//        ' Purpose               : 
	//        '                         
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : 
	//        ' Created               : 
	//        ' Revisions             : 
	//        '=====================================================================
	//        Try
	//            Transmit(PSSTATUS, 0, 0, 0)
	//            Recev(True)
	//            Return Param1
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            Return False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function
	//    ' BYTE CHECK_PS()
	//    '{
	//    ' Transmit(PSSTATUS, 0,0, 0);
	//    '// c = PSSTATUS; trans(c); c = recev();
	//    ' Recev(TRUE);
	//    ' return Param1;
	//    '}



	//    Public Function Ignite_Test()
	//        '=====================================================================
	//        ' Procedure Name        : Ignite_Test
	//        ' Parameters Passed     : None
	//        ' Returns               : 
	//        ' Purpose               : 
	//        '                         
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : 
	//        ' Created               : 
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim st, st1 As Byte
	//        Dim ps1, ps2, ps3, aa, tr, dr As Boolean
	//        Dim flag As Integer = 0
	//        Try
	//            If (Not Inst.Aaf And notInst.N2Of) = True Then
	//                ps1 = ps2 = ps3 = True
	//                st = CHECK_PS()
	//                If (st And AIR_NOK) = True Then
	//                    ps1 = False
	//                End If
	//                If (st And N2O_NOK) = True Then
	//                    ps2 = False
	//                End If
	//                If (st And FUEL_NOK) = True Then
	//                    ps3 = False
	//                End If
	//                st1 = CHECK_BUR_PAR()
	//                If (st1 And AA_CONNECTED) = True Then
	//                    aa = True
	//                Else
	//                    aa = False
	//                End If
	//                If (st1 And TRAP_NOK) = True Then
	//                    tr = False
	//                Else
	//                    tr = True
	//                End If
	//                If (st1 And DOOR_NOK) = True Then
	//                    dr = False
	//                Else
	//                    dr = True
	//                End If
	//                If Not ps3 = True Then
	//                    flag = 2
	//                End If
	//                If Not ps1 = True Then
	//                    flag = 3
	//                End If
	//                If Not aa = True Then
	//                    If Not ps2 = True Then
	//                        flag = 4
	//                    End If
	//                End If
	//                If Not dr = True Then
	//                    flag = 5
	//                End If
	//                If Not tr = True Then
	//                    flag = 6
	//                End If
	//            Else
	//                Check_Flame()
	//                st = CHECK_PS()
	//                If (st And YELLOW_OK) = YELLOW_OK Then
	//                    flag = -2
	//                ElseIf (st And BLUE_OK) = BLUE_OK Then
	//                    flag = -1
	//                ElseIf (st And Flame_OK) = Flame_ok Then
	//                    flag = -1
	//                End If
	//            End If
	//            If flag = -1 Then
	//                Return blue
	//            End If
	//            If flag = -2 Then
	//                Return yellow
	//            End If
	//            If (flag) Then   'Same as Original
	//                Return red
	//            Else
	//                Return green
	//            End If
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            Return False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function



	//    Public Function Ignite(ByVal flag1 As Boolean)  'Line No.2917
	//        '=====================================================================
	//        ' Procedure Name        : Ignite
	//        ' Parameters Passed     : None
	//        ' Returns               : 
	//        ' Purpose               : 
	//        '                         
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : 
	//        ' Created               : 
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim flag As Boolean = True
	//        Dim count As Integer = 0
	//        Dim data, aa As Byte
	//        Dim ch As Integer
	//        Dim Commflag As Boolean 'declared externally
	//        Try
	//            If Not Commflag = True Then
	//                Return
	//            End If
	//            '-------------Copied as it is-----------------------
	//                if( InstType == AA202)
	//        	     hwnd = Create_Window_Pneum("AA-202  AA FLAME");
	//            Else
	//        	    hwnd = Create_Window_Pneum("AA-203  AA FLAME");
	//                StHwnd=hwnd;
	//            End If
	//            '---------------------------------------------------
	//            Call ReinitInstParameters()
	//            Do
	//                    count++
	//                Status_Disp()
	//                If (flag And count = 5) = True Then
	//                    flag = False
	//                End If
	//                If Not flag1 = True Then
	//                    If Not Flame_Off() Then
	//                        Beep()
	//                            messagebox.Show(" Already Flame is Extinguished"," AUTOEXTINGUISH");
	//                    End If
	//                Else
	//                    data = CHECK_BUR_PAR()
	//                    If (data And AA_CONNECTED) = True Then
	//                            aa = on
	//                    Else
	//                        aa = off
	//                    End If
	//                    If aa = True Then
	//                        If Not Inst.Aaf = True Then
	//                            Inst.Aaf = AA_FLAME_ON()
	//                        Else
	//                            Beep()
	//                            MessageBox.Show("Already in AA-Flame")
	//                        End If
	//                    Else
	//                            ch = MessageBox.Show(hpar,"    Ready for flame    Click \n Yes for AA flame \n No for NA flame ", "AA AUTO-IGNITION ", MB_YESNOCANCEL);
	//                        If ch = IDYES Then
	//                            If Not Inst.Aaf = True Then
	//                                Inst.Aaf = AA_FLAME_ON()
	//                            Else
	//                                Beep()
	//                                MessageBox.Show("Already in AA-Flame", "AUTOIGNITION")
	//                            End If
	//                        ElseIf ch = IDNO Then
	//                            If Not Inst.N2of = True Then
	//                                Inst.N2of = N2_FLAME_ON()
	//                            Else
	//                                Beep()
	//                                MessageBox.Show(" Already in nA-Flame", " AUTOIGNITION")
	//                            End If
	//                        End If
	//                    End If
	//                End If
	//            Loop
	//            While count < 15
	//                Close_Window(hwnd, NULL)
	//                ReinitInstParameters()
	//                StHwnd = NULL
	//        End While
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            Return False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function



	//    Public Function Status_Disp()      'Line no. 2870
	//        '=====================================================================
	//        ' Procedure Name        : Status_Disp
	//        ' Parameters Passed     : None
	//        ' Returns               : 
	//        ' Purpose               : 
	//        '                         
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : 
	//        ' Created               : 
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim line As String
	//        Dim status, st, st1 As Byte
	//        Dim flag As Boolean = True
	//        Dim Commflag As Boolean  'Declared Externally -> extern	BOOL Commflag;  
	//        Try
	//            If Not Commflag = True Then
	//                Return
	//            End If
	//                if StHwnd != NULL then
	//                status = GET_PNEUM_STATUS()
	//                'st=random(255); st1=random(255);
	//                st = CHECK_PS()
	//                st1 = CHECK_BUR_PAR()
	//                If (st And AIR_NOK) = True Then
	//                    flag = False
	//                    SetVal(IDC_PAIR, "ERROR")
	//                Else
	//                    SetVal(IDC_PAIR, "OK")
	//                End If
	//                If (st And N2O_NOK) = True Then
	//                    flag = False
	//                    SetVal(IDC_PN2O, "ERROR")
	//                Else
	//                    SetVal(IDC_PN2O, "OK")
	//                End If
	//                If (st And FUEL_NOK) = True Then
	//                    flag = False
	//                    SetVal(IDC_PFUEL, "ERROR")
	//                Else
	//                    SetVal(IDC_PFUEL, "OK")
	//                End If
	//                If (status And SAIR_NON) = True Then
	//                    flag = False
	//                    SetVal(IDC_PVAIR, "CLOSE")
	//                Else
	//                    SetVal(IDC_PVAIR, "OPEN")
	//                End If
	//                If (status And SN2O_ON) = True Then
	//                    SetVal(IDC_PVN2O, "OPEN")
	//                Else
	//                    flag = False
	//                    SetVal(IDC_PVN2O, "CLOSE")
	//                End If
	//                If (status And SFUEL_ON) = True Then
	//                    SetVal(IDC_PVFUEL, "OPEN")
	//                Else
	//                    flag = False
	//                    SetVal(IDC_PVFUEL, "CLOSE")
	//                End If
	//                If (st1 And AA_CONNECTED) = True Then
	//                    SetVal(IDC_BTYPE, "BTAA")
	//                Else
	//                    SetVal(IDC_BTYPE, "BTNA")
	//                End If
	//                If (st1 And TRAP_NOK) = True Then
	//                    flag = False
	//                    SetVal(IDC_TRAP, "TOPEN")
	//                Else
	//                    SetVal(IDC_TRAP, "OK")
	//                End If
	//                If (st1 And DOOR_NOK) = True Then
	//                    flag = False
	//                    SetVal(IDC_DTYPE, "DOPEN")
	//                Else
	//                    SetVal(IDC_DTYPE, "DCLOSE")
	//                End If
	//                If (st And YELLOW_OK) = YELLOW_OK Then
	//                    SetVal(IDC_FLAME, "YELLOW")
	//                ElseIf (st And BLUE_OK) = BLUE_OK Then
	//                    SetVal(IDC_FLAME, "BLUE")
	//                ElseIf (st And FLAME_OK) = FLAME_OK Then
	//                    SetVal(IDC_FLAME, "BYELLOW")
	//                ElseIf (flag) = True Then
	//                    SetVal(IDC_FLAME, "GREEN")
	//                Else
	//                    SetVal(IDC_FLAME, "RED")
	//                End If
	//            End If

	//            Get_NV_Pos()
	//            sprintf(line1, "%3.2f", Read_Fuel()) 'Nv pos
	//            SetWindowText(GetDlgItem(StHwnd, IDC_FR), line1)
	//            Get_BH_Pos()
	//            sprintf(line1, "%2.1f", ReadBurnerHeight())
	//            SetWindowText(GetDlgItem(StHwnd, IDC_BH), line1)
	//        UpdateWindow(StHwnd)
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            Return False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function
	//    ' void	Status_Disp()
	//    '{
	//    'char  line1[80];
	//    'BYTE  status,st, st1;
	//    'BOOL	flag=TRUE;

	//    'if (!Commflag)
	//    '	 return;
	//    'if (StHwnd!=NULL){
	//    '  status = GET_PNEUM_STATUS();
	//    '//  st=random(255); st1=random(255);
	//    '  st = CHECK_PS();
	//    '  st1 = CHECK_BUR_PAR();
	//    '  if (st & AIR_NOK)	 		{  flag=FALSE; SetVal(IDC_PAIR, "ERROR");}
	//    '  else 	SetVal(IDC_PAIR, "OK");
	//    '  if (st & N2O_NOK)	 		{  flag=FALSE; SetVal(IDC_PN2O, "ERROR");}
	//    '  else 	SetVal(IDC_PN2O, "OK");
	//    '  if (st & FUEL_NOK)	 		{  flag=FALSE; SetVal(IDC_PFUEL, "ERROR");}
	//    '  else 	SetVal(IDC_PFUEL, "OK");
	//    '  if (status & SAIR_NON) 	{
	//    '		flag=FALSE; SetVal(IDC_PVAIR,"CLOSE");}
	//    '  else	SetVal(IDC_PVAIR,"OPEN");
	//    '  if (status & SN2O_ON)	 	SetVal(IDC_PVN2O, "OPEN");
	//    '  else	{  flag=FALSE; SetVal(IDC_PVN2O, "CLOSE");}
	//    '  if (status & SFUEL_ON)	SetVal(IDC_PVFUEL, "OPEN");
	//    '  else	{  flag=FALSE; SetVal(IDC_PVFUEL, "CLOSE");}
	//    '  if (st1 & AA_CONNECTED) 	SetVal(IDC_BTYPE, "BTAA");
	//    '  else 	SetVal(IDC_BTYPE, "BTNA");
	//    '  if (st1 & TRAP_NOK) {  flag=FALSE; SetVal(IDC_TRAP, "TOPEN");}
	//    '  else SetVal(IDC_TRAP, "OK");
	//    '  if (st1 &DOOR_NOK) {  flag=FALSE; SetVal(IDC_DTYPE, "DOPEN");}
	//    '  else SetVal(IDC_DTYPE, "DCLOSE");
	//    '  if ((st&YELLOW_OK) ==YELLOW_OK) 		SetVal(IDC_FLAME, "YELLOW");
	//    '  else if ((st&BLUE_OK)==BLUE_OK)  	SetVal(IDC_FLAME, "BLUE");
	//    '  else if ((st & FLAME_OK)==FLAME_OK) 	SetVal(IDC_FLAME, "BYELLOW");
	//    '  else if (flag)	SetVal(IDC_FLAME, "GREEN");
	//    '  else SetVal(IDC_FLAME, "RED");
	//    '  Get_NV_Pos();
	//    '  sprintf(line1,"%3.2f", Read_Fuel());	// Nv pos
	//    '  SetWindowText(GetDlgItem(StHwnd, IDC_FR),line1);
	//    '  Get_BH_Pos();
	//    '  sprintf(line1,"%2.1f", ReadBurnerHeight());
	//    '  SetWindowText(GetDlgItem(StHwnd, IDC_BH),line1);
	//    '  UpdateWindow (StHwnd) ;
	//    ' }
	//    '}


	//    Public Function ReinitInstParameters()  'Line No.3509
	//        '=====================================================================
	//        ' Procedure Name        : ReinitInstParameters
	//        ' Parameters Passed     : None
	//        ' Returns               : 
	//        ' Purpose               : 
	//        '                         
	//        ' Description           : 
	//        ' Assumptions           : 
	//        ' Dependencies          : 
	//        ' Author                : 
	//        ' Created               : 
	//        ' Revisions             : 
	//        '=====================================================================
	//        Dim i, dcur As Integer
	//        Dim lampcur, warmupcur As Double
	//        Try
	//            If Not Commflag = True Then
	//                Return
	//            End If
	//            If Inst.Lamp_pos >= 1 And Inst.Lamp_pos <= 6 Then
	//                'All_Lamp_Off();
	//                If Inst.Mode = AA Or Inst.Mode = HCLE Or Inst.Mode = AABGC Or Inst.Mode = AABGCSR Then
	//                    lampcur = Inst.Cur
	//        		warmupcur=Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur
	//                    For i = 1 To 6
	//                        If i = Inst.Lamp_pos Or ((Inst.Lamp_warm > 0 And Inst.Lamp_warm < 7) And (i = Inst.Lamp_warm)) Then
	//                            If i = Inst.Lamp_warm Then
	//                                Set_HCL_Cur(warmupcur, Inst.Lamp_warm)
	//                            Else
	//                                Set_HCL_Cur(lampcur, Inst.Lamp_pos)
	//                            End If
	//                        Else
	//                            Set_HCL_Cur(0, i)
	//                        End If
	//                    Next i
	//                    Inst.Cur = lampcur
	//        	        Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur=warmupcur
	//                End If
	//                Set_PMT(Inst.Pmtv)
	//                If Inst.D2cur > 100 Then
	//                    Set_D2_Cur(Inst.D2cur)
	//                Else
	//                    dcur = 100
	//                      	Transmit(D2CUR, (BYTE)(dcur), (BYTE) (dcur>>8), 0)
	//#If NEWHANDSHAKE Then
	//        	 Recev(TRUE)
	//#End If
	//                    D2_OFF()
	//                End If
	//        End If
	//        Catch ex As Exception
	//            '---------------------------------------------------------
	//            'Error Handling and logging
	//            gobjErrorHandler.ErrorDescription = ex.Message
	//            gobjErrorHandler.ErrorMessage = ex.Message
	//            gobjErrorHandler.WriteErrorLog(ex)
	//            '---------------------------------------------------------
	//            Return False
	//        Finally
	//            '---------------------------------------------------------
	//            'Writing Execution log
	//            If CONST_CREATE_EXECUTION_LOG = 1 Then
	//                gobjErrorHandler.WriteExecutionLog()
	//            End If
	//            '---------------------------------------------------------
	//        End Try

	//    End Function
	//    'void  S4FUNC ReinitInstParameters(void)
	//    '        int i,dcur;
	//    '    double lampcur,warmupcur;

	//    '     if (!Commflag)
	//    '    	return;
	//    '    if(Inst.Lamp_pos>=1 && Inst.Lamp_pos<=6) {
	//    '    //  All_Lamp_Off();
	//    '      if (Inst.Mode==AA || Inst.Mode ==HCLE || Inst.Mode==AABGC ||Inst.Mode==AABGCSR){
	//    '    		lampcur=Inst.Cur;
	//    '    		warmupcur=Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur;
	//    '    	  for(i=1;i<=6;i++){
	//    '    		  if( (i == Inst.Lamp_pos) || ((Inst.Lamp_warm>0 && Inst.Lamp_warm<7) && (i == Inst.Lamp_warm))){
	//    '    			  if(i == Inst.Lamp_warm)
	//    '    				  Set_HCL_Cur(warmupcur,Inst.Lamp_warm);
	//    '    			  else
	//    '    				  Set_HCL_Cur(lampcur,Inst.Lamp_pos);
	//    '    		  }
	//    '    		  else
	//    '    			  Set_HCL_Cur(0,i);
	//    '    	  }
	//    '    	  Inst.Cur=lampcur;
	//    '    	  Inst.Lamp_par.lamp[Inst.Lamp_warm-1].cur=warmupcur;
	//    '      }
	//    '      Set_PMT(Inst.Pmtv);
	//    '      if ( Inst.D2cur>100 )
	//    '    	 Set_D2_Cur(Inst.D2cur);
	//    '      else{
	//    '    	 dcur=100;
	//    '    	 Transmit(D2CUR, (BYTE)(dcur), (BYTE) (dcur>>8), 0);
	//    '#If NEWHANDSHAKE Then
	//    '    	 Recev(TRUE);
	//    '#End If
	//    '    	 D2_OFF();
	//    '      }
	//    '    }
	//    '    }


	public bool AnalysisFunctions()
	{
		//======================Analysis Functions==========================================
	}



	//Private Function Calculate_Analysis_Graph_Param(ByVal curve As Double) As Double
	//        Dim FrqIntv As Double = 0.0
	//        Dim xmax1 As Double = 0
	//        Dim xmin1 As Double = 0
	//        Dim Fmin As Double = 0
	//        Dim Fmax As Double = 0
	//        Dim Fx As Double = 0
	//        Dim fn, tot1 As Integer

	//        If IsNothing(curve) Then
	//            Return 0.0
	//        End If

	//        'xmax1 = curve.ymax
	//        'xmin1 = curve.Ymin
	//        tot1 = (xmax1 - xmin1) * 60
	//        'FrqIntv = GetInterval(xmax1, xmin1, tot1, True)
	//        'fn = CInt(xax1 / FrqIntv)
	//        Fmax = CDbl(fn * FrqIntv)
	//        If xmax1 > Fmax Then
	//            Fmax = Fmax + FrqIntv
	//        End If
	//        fn = CInt(xmin1 / FrqIntv)
	//        Fmin = CDbl(fn * FrqIntv)

	//        'If (xmin < Fmin) Then
	//        '    Fmin = Fmin - FrqIntv
	//        'End If

	//        If (Fmin > xmin1) And (Not FrqIntv = -1.0) Then
	//            While (Fmin > xmin1)
	//                Fmax = Fmax + FrqIntv
	//            End While
	//        End If

	//c       'curve.
	//        'double	Calculate_Analysis_Graph_Param(CURVEDATA *Curve)
	//        '{
	//        'double	FrqIntv=0.0, xmax1=0, xmin1=0,Fmin=0, Fmax=0, Fx=0;
	//        'int		fn;
	//        'int		tot1;

	//        ' if (Curve==NULL)
	//        '	return 0.0;
	//        ' xmax1=Curve->Ymax;
	//        ' xmin1=Curve->Ymin;
	//        ' tot1 = (xmax1-xmin1)*60;
	//        ' FrqIntv =GetInterval(xmax1, xmin1, tot1, TRUE);
	//        ' fn = (int)  (xmax1/ FrqIntv);
	//        ' Fmax = (double) fn*  FrqIntv;
	//        '            If (xmax1 > Fmax) Then
	//        '	Fmax+= FrqIntv;
	//        ' fn = (int)  ( xmin1/ FrqIntv);
	//        ' Fmin = (double) fn*FrqIntv;
	//        '                If (xmin1 < Fmin) Then
	//        '  Fmin-= FrqIntv;

	//        ' if (Fmin> xmin1&& FrqIntv!=(double) -1.0){
	//        '                        While (Fmin > xmin1)
	//        '		 Fmin-=FrqIntv;
	//        '  }
	//        ' if (Fmax< xmax1&& FrqIntv!=(double) -1.0){
	//        '                                While (Fmax < xmax1)
	//        '		Fmax+=FrqIntv;
	//        '  }

	//        ' Curve->Ymin = Fmin;
	//        ' Curve->Ymax= Fmax;
	//        ' Curve->FrqIntv =FrqIntv;

	//        ' xmax1=Curve->Xmax;
	//        ' xmin1=Curve->Xmin;
	//        ' tot1 = 60; //(xmax1-xmin1)*18.2;
	//        ' Fx =GetInterval(xmax1, xmin1, tot1, TRUE);
	//        '                                    If (Fx) Then
	//        '	 fn = (int)  (xmax1/ Fx);
	//        '                                    Else
	//        '	 fn = 0;
	//        ' Fmax = (double) fn*  Fx;
	//        '                                        If (xmax1 > Fmax) Then
	//        '	Fmax+= Fx;
	//        ' Curve->Xmin = xmin1;
	//        ' Curve->Xmax = Fmax;
	//        ' Curve->XIntv =GetInterval(Curve->Xmax, Curve->Xmin,	tot1, TRUE);

	//        '// Calculate_Xparameters(Curve);
	//        ' return FrqIntv;
	//        '}

	//    End Function


	private void  // ERROR: Handles clauses are not supported in C#
Button1_Click(System.Object sender, System.EventArgs e)
	{
		//gobjfrmStatus.BringToFront()
	}

	private void  // ERROR: Handles clauses are not supported in C#
Button2_Click(System.Object sender, System.EventArgs e)
	{
		//gobjfrmStatus.SendToBack()
	}

}
