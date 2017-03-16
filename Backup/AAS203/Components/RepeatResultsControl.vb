Imports AAS203Library
Imports AAS203Library.Method

Public Class RepeatResultsControl
    Inherits System.Windows.Forms.UserControl
    '**********************************************************************
    ' File Header       
    ' File Name 		:   RepeatResultsControl.vb
    ' Author			:   Mangesh Shardul
    ' Date/Time			:   10-Mar-2007 11:00 am
    ' Description		:   Class to show the repeat results of Standard and Sample
    ' Assumptions       :	
    ' Dependencies      :   
    ' Revisions         :   Deepak Bhati on 22.07.07
    '**********************************************************************

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents lblStandardName As System.Windows.Forms.Label
    Friend WithEvents lblStandardNo As System.Windows.Forms.Label
    Friend WithEvents lstConcStats As System.Windows.Forms.ListBox
    Friend WithEvents lstAbsStats As System.Windows.Forms.ListBox
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblConc As System.Windows.Forms.Label
    Friend WithEvents lblAbs As System.Windows.Forms.Label
    Friend WithEvents lblAbsStats As System.Windows.Forms.Label
    Friend WithEvents lblConcStats As System.Windows.Forms.Label
    Friend WithEvents RemoveOption As NETXP.Controls.XPCheckBox
    Friend WithEvents TextBoxConc15 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc14 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc12 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConc1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CustomPanel1 = New GradientPanel.CustomPanel
        Me.RemoveOption = New NETXP.Controls.XPCheckBox
        Me.TextBoxConc15 = New System.Windows.Forms.TextBox
        Me.TextBoxConc14 = New System.Windows.Forms.TextBox
        Me.TextBoxConc13 = New System.Windows.Forms.TextBox
        Me.TextBoxConc12 = New System.Windows.Forms.TextBox
        Me.TextBoxConc11 = New System.Windows.Forms.TextBox
        Me.TextBoxConc10 = New System.Windows.Forms.TextBox
        Me.TextBoxConc9 = New System.Windows.Forms.TextBox
        Me.TextBoxConc8 = New System.Windows.Forms.TextBox
        Me.TextBoxConc7 = New System.Windows.Forms.TextBox
        Me.TextBoxConc6 = New System.Windows.Forms.TextBox
        Me.TextBoxConc5 = New System.Windows.Forms.TextBox
        Me.TextBoxConc4 = New System.Windows.Forms.TextBox
        Me.TextBoxConc3 = New System.Windows.Forms.TextBox
        Me.TextBoxConc2 = New System.Windows.Forms.TextBox
        Me.TextBoxConc1 = New System.Windows.Forms.TextBox
        Me.TextBox15 = New System.Windows.Forms.TextBox
        Me.TextBox14 = New System.Windows.Forms.TextBox
        Me.TextBox13 = New System.Windows.Forms.TextBox
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lblConc = New System.Windows.Forms.Label
        Me.lblAbs = New System.Windows.Forms.Label
        Me.lblStandardName = New System.Windows.Forms.Label
        Me.lblStandardNo = New System.Windows.Forms.Label
        Me.lblAbsStats = New System.Windows.Forms.Label
        Me.lblConcStats = New System.Windows.Forms.Label
        Me.lstConcStats = New System.Windows.Forms.ListBox
        Me.lstAbsStats = New System.Windows.Forms.ListBox
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.CustomPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomPanel1
        '
        Me.CustomPanel1.BorderColor = System.Drawing.SystemColors.InfoText
        Me.CustomPanel1.Controls.Add(Me.TextBox12)
        Me.CustomPanel1.Controls.Add(Me.TextBox11)
        Me.CustomPanel1.Controls.Add(Me.RemoveOption)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc15)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc14)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc13)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc12)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc11)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc10)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc9)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc8)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc7)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc6)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc5)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc4)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc3)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc2)
        Me.CustomPanel1.Controls.Add(Me.TextBoxConc1)
        Me.CustomPanel1.Controls.Add(Me.TextBox15)
        Me.CustomPanel1.Controls.Add(Me.TextBox14)
        Me.CustomPanel1.Controls.Add(Me.TextBox13)
        Me.CustomPanel1.Controls.Add(Me.TextBox10)
        Me.CustomPanel1.Controls.Add(Me.TextBox9)
        Me.CustomPanel1.Controls.Add(Me.TextBox8)
        Me.CustomPanel1.Controls.Add(Me.TextBox7)
        Me.CustomPanel1.Controls.Add(Me.TextBox6)
        Me.CustomPanel1.Controls.Add(Me.TextBox5)
        Me.CustomPanel1.Controls.Add(Me.TextBox4)
        Me.CustomPanel1.Controls.Add(Me.TextBox3)
        Me.CustomPanel1.Controls.Add(Me.TextBox2)
        Me.CustomPanel1.Controls.Add(Me.TextBox1)
        Me.CustomPanel1.Controls.Add(Me.lblConc)
        Me.CustomPanel1.Controls.Add(Me.lblAbs)
        Me.CustomPanel1.Controls.Add(Me.lblStandardName)
        Me.CustomPanel1.Controls.Add(Me.lblStandardNo)
        Me.CustomPanel1.Controls.Add(Me.lblAbsStats)
        Me.CustomPanel1.Controls.Add(Me.lblConcStats)
        Me.CustomPanel1.Controls.Add(Me.lstConcStats)
        Me.CustomPanel1.Controls.Add(Me.lstAbsStats)
        Me.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanel1.Name = "CustomPanel1"
        Me.CustomPanel1.Size = New System.Drawing.Size(768, 160)
        Me.CustomPanel1.TabIndex = 0
        '
        'RemoveOption
        '
        Me.RemoveOption.BackColor = System.Drawing.Color.Transparent
        Me.RemoveOption.Location = New System.Drawing.Point(656, 120)
        Me.RemoveOption.Name = "RemoveOption"
        Me.RemoveOption.Size = New System.Drawing.Size(104, 32)
        Me.RemoveOption.TabIndex = 172
        Me.RemoveOption.Text = "&Remove"
        Me.RemoveOption.Visible = False
        '
        'TextBoxConc15
        '
        Me.TextBoxConc15.Location = New System.Drawing.Point(700, 54)
        Me.TextBoxConc15.Name = "TextBoxConc15"
        Me.TextBoxConc15.ReadOnly = True
        Me.TextBoxConc15.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc15.TabIndex = 171
        Me.TextBoxConc15.Tag = "15"
        Me.TextBoxConc15.Text = ""
        '
        'TextBoxConc14
        '
        Me.TextBoxConc14.Location = New System.Drawing.Point(655, 54)
        Me.TextBoxConc14.Name = "TextBoxConc14"
        Me.TextBoxConc14.ReadOnly = True
        Me.TextBoxConc14.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc14.TabIndex = 170
        Me.TextBoxConc14.Tag = "14"
        Me.TextBoxConc14.Text = ""
        '
        'TextBoxConc13
        '
        Me.TextBoxConc13.Location = New System.Drawing.Point(610, 54)
        Me.TextBoxConc13.Name = "TextBoxConc13"
        Me.TextBoxConc13.ReadOnly = True
        Me.TextBoxConc13.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc13.TabIndex = 169
        Me.TextBoxConc13.Tag = "13"
        Me.TextBoxConc13.Text = ""
        '
        'TextBoxConc12
        '
        Me.TextBoxConc12.Location = New System.Drawing.Point(565, 54)
        Me.TextBoxConc12.Name = "TextBoxConc12"
        Me.TextBoxConc12.ReadOnly = True
        Me.TextBoxConc12.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc12.TabIndex = 168
        Me.TextBoxConc12.Tag = "12"
        Me.TextBoxConc12.Text = ""
        '
        'TextBoxConc11
        '
        Me.TextBoxConc11.Location = New System.Drawing.Point(520, 54)
        Me.TextBoxConc11.Name = "TextBoxConc11"
        Me.TextBoxConc11.ReadOnly = True
        Me.TextBoxConc11.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc11.TabIndex = 167
        Me.TextBoxConc11.Tag = "11"
        Me.TextBoxConc11.Text = ""
        '
        'TextBoxConc10
        '
        Me.TextBoxConc10.Location = New System.Drawing.Point(475, 54)
        Me.TextBoxConc10.Name = "TextBoxConc10"
        Me.TextBoxConc10.ReadOnly = True
        Me.TextBoxConc10.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc10.TabIndex = 166
        Me.TextBoxConc10.Tag = "10"
        Me.TextBoxConc10.Text = ""
        '
        'TextBoxConc9
        '
        Me.TextBoxConc9.Location = New System.Drawing.Point(430, 54)
        Me.TextBoxConc9.Name = "TextBoxConc9"
        Me.TextBoxConc9.ReadOnly = True
        Me.TextBoxConc9.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc9.TabIndex = 165
        Me.TextBoxConc9.Tag = "9"
        Me.TextBoxConc9.Text = ""
        '
        'TextBoxConc8
        '
        Me.TextBoxConc8.Location = New System.Drawing.Point(385, 54)
        Me.TextBoxConc8.Name = "TextBoxConc8"
        Me.TextBoxConc8.ReadOnly = True
        Me.TextBoxConc8.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc8.TabIndex = 164
        Me.TextBoxConc8.Tag = "8"
        Me.TextBoxConc8.Text = ""
        '
        'TextBoxConc7
        '
        Me.TextBoxConc7.Location = New System.Drawing.Point(340, 54)
        Me.TextBoxConc7.Name = "TextBoxConc7"
        Me.TextBoxConc7.ReadOnly = True
        Me.TextBoxConc7.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc7.TabIndex = 163
        Me.TextBoxConc7.Tag = "7"
        Me.TextBoxConc7.Text = ""
        '
        'TextBoxConc6
        '
        Me.TextBoxConc6.Location = New System.Drawing.Point(295, 54)
        Me.TextBoxConc6.Name = "TextBoxConc6"
        Me.TextBoxConc6.ReadOnly = True
        Me.TextBoxConc6.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc6.TabIndex = 162
        Me.TextBoxConc6.Tag = "6"
        Me.TextBoxConc6.Text = ""
        '
        'TextBoxConc5
        '
        Me.TextBoxConc5.Location = New System.Drawing.Point(250, 54)
        Me.TextBoxConc5.Name = "TextBoxConc5"
        Me.TextBoxConc5.ReadOnly = True
        Me.TextBoxConc5.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc5.TabIndex = 161
        Me.TextBoxConc5.Tag = "5"
        Me.TextBoxConc5.Text = ""
        '
        'TextBoxConc4
        '
        Me.TextBoxConc4.Location = New System.Drawing.Point(205, 54)
        Me.TextBoxConc4.Name = "TextBoxConc4"
        Me.TextBoxConc4.ReadOnly = True
        Me.TextBoxConc4.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc4.TabIndex = 160
        Me.TextBoxConc4.Tag = "4"
        Me.TextBoxConc4.Text = ""
        '
        'TextBoxConc3
        '
        Me.TextBoxConc3.Location = New System.Drawing.Point(160, 54)
        Me.TextBoxConc3.Name = "TextBoxConc3"
        Me.TextBoxConc3.ReadOnly = True
        Me.TextBoxConc3.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc3.TabIndex = 159
        Me.TextBoxConc3.Tag = "3"
        Me.TextBoxConc3.Text = ""
        '
        'TextBoxConc2
        '
        Me.TextBoxConc2.Location = New System.Drawing.Point(115, 54)
        Me.TextBoxConc2.Name = "TextBoxConc2"
        Me.TextBoxConc2.ReadOnly = True
        Me.TextBoxConc2.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc2.TabIndex = 158
        Me.TextBoxConc2.Tag = "2"
        Me.TextBoxConc2.Text = ""
        '
        'TextBoxConc1
        '
        Me.TextBoxConc1.Location = New System.Drawing.Point(70, 54)
        Me.TextBoxConc1.Name = "TextBoxConc1"
        Me.TextBoxConc1.ReadOnly = True
        Me.TextBoxConc1.Size = New System.Drawing.Size(45, 21)
        Me.TextBoxConc1.TabIndex = 157
        Me.TextBoxConc1.Tag = "1"
        Me.TextBoxConc1.Text = ""
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(700, 30)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(45, 21)
        Me.TextBox15.TabIndex = 156
        Me.TextBox15.Tag = "15"
        Me.TextBox15.Text = ""
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(655, 30)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ReadOnly = True
        Me.TextBox14.Size = New System.Drawing.Size(45, 21)
        Me.TextBox14.TabIndex = 155
        Me.TextBox14.Tag = "14"
        Me.TextBox14.Text = ""
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(610, 30)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(45, 21)
        Me.TextBox13.TabIndex = 154
        Me.TextBox13.Tag = "13"
        Me.TextBox13.Text = ""
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(475, 30)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(45, 21)
        Me.TextBox10.TabIndex = 151
        Me.TextBox10.Tag = "10"
        Me.TextBox10.Text = ""
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(430, 30)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(45, 21)
        Me.TextBox9.TabIndex = 150
        Me.TextBox9.Tag = "9"
        Me.TextBox9.Text = ""
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(385, 30)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(45, 21)
        Me.TextBox8.TabIndex = 149
        Me.TextBox8.Tag = "8"
        Me.TextBox8.Text = ""
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(340, 30)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(45, 21)
        Me.TextBox7.TabIndex = 148
        Me.TextBox7.Tag = "7"
        Me.TextBox7.Text = ""
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(295, 30)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(45, 21)
        Me.TextBox6.TabIndex = 147
        Me.TextBox6.Tag = "6"
        Me.TextBox6.Text = ""
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(250, 30)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(45, 21)
        Me.TextBox5.TabIndex = 146
        Me.TextBox5.Tag = "5"
        Me.TextBox5.Text = ""
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(205, 30)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(45, 21)
        Me.TextBox4.TabIndex = 145
        Me.TextBox4.Tag = "4"
        Me.TextBox4.Text = ""
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(160, 30)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(45, 21)
        Me.TextBox3.TabIndex = 144
        Me.TextBox3.Tag = "3"
        Me.TextBox3.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(115, 30)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(45, 21)
        Me.TextBox2.TabIndex = 143
        Me.TextBox2.Tag = "2"
        Me.TextBox2.Text = ""
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(70, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(45, 21)
        Me.TextBox1.TabIndex = 142
        Me.TextBox1.Tag = "1"
        Me.TextBox1.Text = "0.0000"
        '
        'lblConc
        '
        Me.lblConc.Location = New System.Drawing.Point(4, 56)
        Me.lblConc.Name = "lblConc"
        Me.lblConc.Size = New System.Drawing.Size(60, 16)
        Me.lblConc.TabIndex = 140
        Me.lblConc.Text = "Conc"
        '
        'lblAbs
        '
        Me.lblAbs.Location = New System.Drawing.Point(4, 32)
        Me.lblAbs.Name = "lblAbs"
        Me.lblAbs.Size = New System.Drawing.Size(60, 16)
        Me.lblAbs.TabIndex = 139
        Me.lblAbs.Text = "Abs"
        '
        'lblStandardName
        '
        Me.lblStandardName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStandardName.Location = New System.Drawing.Point(72, 8)
        Me.lblStandardName.Name = "lblStandardName"
        Me.lblStandardName.Size = New System.Drawing.Size(140, 16)
        Me.lblStandardName.TabIndex = 138
        Me.lblStandardName.Text = "Standard Name"
        '
        'lblStandardNo
        '
        Me.lblStandardNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStandardNo.Location = New System.Drawing.Point(5, 5)
        Me.lblStandardNo.Name = "lblStandardNo"
        Me.lblStandardNo.Size = New System.Drawing.Size(50, 16)
        Me.lblStandardNo.TabIndex = 137
        Me.lblStandardNo.Text = "Std No."
        '
        'lblAbsStats
        '
        Me.lblAbsStats.Location = New System.Drawing.Point(40, 80)
        Me.lblAbsStats.Name = "lblAbsStats"
        Me.lblAbsStats.Size = New System.Drawing.Size(208, 16)
        Me.lblAbsStats.TabIndex = 136
        Me.lblAbsStats.Text = "Statistics on Abs"
        '
        'lblConcStats
        '
        Me.lblConcStats.Location = New System.Drawing.Point(296, 80)
        Me.lblConcStats.Name = "lblConcStats"
        Me.lblConcStats.Size = New System.Drawing.Size(160, 16)
        Me.lblConcStats.TabIndex = 135
        Me.lblConcStats.Text = "Statistics on Concentration"
        '
        'lstConcStats
        '
        Me.lstConcStats.ItemHeight = 15
        Me.lstConcStats.Location = New System.Drawing.Point(298, 100)
        Me.lstConcStats.Name = "lstConcStats"
        Me.lstConcStats.Size = New System.Drawing.Size(254, 49)
        Me.lstConcStats.TabIndex = 134
        '
        'lstAbsStats
        '
        Me.lstAbsStats.ItemHeight = 15
        Me.lstAbsStats.Location = New System.Drawing.Point(40, 100)
        Me.lstAbsStats.Name = "lstAbsStats"
        Me.lstAbsStats.Size = New System.Drawing.Size(248, 49)
        Me.lstAbsStats.TabIndex = 133
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(520, 30)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(45, 21)
        Me.TextBox11.TabIndex = 173
        Me.TextBox11.Tag = "10"
        Me.TextBox11.Text = ""
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(565, 30)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(45, 21)
        Me.TextBox12.TabIndex = 174
        Me.TextBox12.Tag = "10"
        Me.TextBox12.Text = ""
        '
        'RepeatResultsControl
        '
        Me.AutoScroll = True
        Me.Controls.Add(Me.CustomPanel1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "RepeatResultsControl"
        Me.Size = New System.Drawing.Size(768, 160)
        Me.CustomPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private Variables"
    Private mAnalysisSampleParameters As Method.clsAnalysisSampleParameters
    Private mAnalysisStdParameters As Method.clsAnalysisStdParameters
    Private mRemoveAbs As Double
    Private mintRepeatNumber As Integer
    Private mblnIsStandard As Boolean
#End Region

#Region "Public Events"
    Public Event RepeatItemClick(ByVal StandardNumber As Integer, ByVal RepeatNumber As Integer, ByVal IsStandard As Boolean, ByRef ctrls As Control.ControlCollection)
#End Region

#Region " Public Properties "

    Public Property RepeatNumber() As Integer
        Get
            Return mintRepeatNumber
        End Get
        Set(ByVal Value As Integer)
            mintRepeatNumber = Value
        End Set
    End Property

    Public Property StandardNumber() As Integer
        Get
            Return CInt(lblStandardNo.Text)
        End Get
        Set(ByVal Value As Integer)
            lblStandardNo.Text = Value
        End Set
    End Property

    Public Property IsStandard() As Boolean
        Get
            Return mblnIsStandard
        End Get
        Set(ByVal Value As Boolean)
            mblnIsStandard = Value
        End Set
    End Property

    Public Property StandardName() As String
        Get
            Return lblStandardName.Text
        End Get
        Set(ByVal Value As String)
            lblStandardName.Text = Value
        End Set
    End Property

    Public Property RemoveAbs() As Double
        Get
            Return mRemoveAbs
        End Get
        Set(ByVal Value As Double)
            mRemoveAbs = Value
        End Set
    End Property

    Public Property AnalysisParameter() As Method.clsAnalysisSampleParameters
        Get
            Return mAnalysisSampleParameters
        End Get
        Set(ByVal Value As Method.clsAnalysisSampleParameters)
            mAnalysisSampleParameters = Value
        End Set
    End Property

    Public Property StandardAnalysisParameter() As Method.clsAnalysisStdParameters
        Get
            Return mAnalysisStdParameters
        End Get
        Set(ByVal Value As Method.clsAnalysisStdParameters)
            mAnalysisStdParameters = Value
        End Set
    End Property

#End Region

#Region " Public functions "

    Public Sub FindNSetValueInControl(ByVal strValue As String, ByVal intControlNumber As Integer)
        Dim cntrl As Control
        Try
            For Each cntrl In CustomPanel1.Controls
                If TypeOf cntrl Is TextBox Then
                    If cntrl.Name = "TextBox" & intControlNumber Then
                        cntrl.Text = strValue
                        RemoveAbs = strValue
                        cntrl.Visible = True
                        Exit For
                    End If
                End If
            Next

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

    Public Sub FindNSet2ndValueInControl(ByVal strValue As String, ByVal intControlNumber As Integer, ByVal intDecimal As Integer)
        Dim cntrl As Control
        Try
            For Each cntrl In CustomPanel1.Controls
                If TypeOf cntrl Is TextBox Then
                    If cntrl.Name = "TextBoxConc" & intControlNumber Then
                        cntrl.Text = FormatNumber(strValue, intDecimal)  '---08.03.09
                        'RemoveAbs = strValue
                        cntrl.Visible = True
                        Exit For
                    End If
                End If
            Next

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

    Public Sub FindNSetControlVisible(ByVal intControlNumber As Integer, ByVal blnIsVisible As Boolean)
        Dim cntrl As Control
        Try
            For Each cntrl In CustomPanel1.Controls
                If TypeOf cntrl Is TextBox Then
                    If cntrl.Name = "TextBox" & intControlNumber Then
                        cntrl.Visible = blnIsVisible
                        cntrl.Refresh()
                        Exit For
                    End If
                End If
            Next

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

    Public Sub FindNSet2ndControlVisible(ByVal intControlNumber As Integer, ByVal blnIsVisible As Boolean)
        Dim cntrl As Control
        Try
            For Each cntrl In CustomPanel1.Controls
                If TypeOf cntrl Is TextBox Then
                    If cntrl.Name = "TextBoxConc" & intControlNumber Then
                        cntrl.Visible = blnIsVisible
                        cntrl.Refresh()
                        Exit For
                    End If
                End If
            Next

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

    Public Sub ShowStatistic(ByVal basic As clsBasicStat, ByVal blnIsStandard As Boolean, ByVal blnIsConcStats As Boolean)
        '=====================================================================
        ' Procedure Name        : ShowStatistic
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul
        ' Created               : 10-Mar-2007 02:50 pm
        ' Revisions             : 1
        '=====================================================================

        '****************************************************************
        '---- ORIGINAL CODE
        '****************************************************************
        'void	 ShowStatistic(HWND hpar, BASIC_STAT *basic, int i, BOOL flag)
        '{
        '   HWND    hwnd;
        '   int		j;
        '   If (flag) Then
        '   {
        '	    hwnd = GetDlgItem(hpar, IDC_SAMPNAME+i*NOOFITEMS+35);
        '	    j=0;
        '   }
        '   Else
        '   {
        '	    hwnd = GetDlgItem(hpar, IDC_SAMPNAME+i*NOOFITEMS+37);
        '	    j=1;
        '   }
        '   ShowWindow1(hwnd, TRUE);
        '   SendMessage(hwnd, LB_RESETCONTENT, 0, 0L);
        '   show_basic_val( hwnd, "Valid Observations ",(double) basic->TotData[j], FALSE);
        '   show_basic_val( hwnd, "Process Mean ", basic->Zavg[j], TRUE);
        '   show_basic_val( hwnd, "Standard Deviation ", basic->Zsigma[j], TRUE);
        '   show_basic_val( hwnd, "Variance ", basic->Var[j], TRUE);
        '   show_basic_val( hwnd, "Coeff. of Variance", basic->CV[j], TRUE);
        '   show_basic_val( hwnd, "Minimum value", basic->Min[j], TRUE);
        '   show_basic_val( hwnd, "Maximum value ", basic->Max[j], TRUE);
        '   show_basic_val( hwnd, "Range ", basic->Max[j]-basic->Min[j], TRUE);
        '}
        '****************************************************************
        Dim j As Integer

        Try
            'commented and added the following code by deepak on 22.07.07

            ''If (blnIsStandard) Then
            ''    '---For Standards
            ''    j = 0
            ''Else
            ''    '---For Samples
            ''    j = 1
            ''End If


            If blnIsConcStats Then
                j = 1
            Else
                j = 0
            End If

            If blnIsConcStats Then
                Call show_basic_val(lstConcStats, basic, j)
            Else
                Call show_basic_val(lstAbsStats, basic, j)
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

    Public Sub SetVisibleRemoveOption(Optional ByVal VisibleValueIn As Boolean = True)
        RemoveOption.Visible = VisibleValueIn
    End Sub

    Private Sub show_basic_val(ByRef lstStats As ListBox, ByVal basic As Method.clsBasicStat, ByVal j As Integer)
        '---changed by deepak on 22.07.07
        lstStats.Items.Clear()
        lstStats.Items.Add("Valid Observations : " & FormatNumber(basic.TotData(j), 0))
        lstStats.Items.Add("Process Mean       : " & FormatNumber(basic.ZAvg(j), 5))
        lstStats.Items.Add("Standard Deviation : " & FormatNumber(basic.ZSigma(j), 5))
        lstStats.Items.Add("Variance           : " & FormatNumber(basic.Var(j), 5))
        lstStats.Items.Add("Coeff. of Variance : " & FormatNumber(basic.CV(j), 5))
        lstStats.Items.Add("Minimum value      : " & FormatNumber(basic.Min(j), 5))
        lstStats.Items.Add("Maximum value      : " & FormatNumber(basic.Max(j), 5))
        lstStats.Items.Add("Range              : " & FormatNumber(basic.Max(j) - basic.Min(j), 5))
    End Sub

#End Region

#Region "Commented Code"
    'Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
    '    mRemoveAbs = TextBox1.Text
    '    'RaiseEvent RepeatResultClick(Me.StandardNumber)
    'End Sub

    'Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
    '    mRemoveAbs = TextBox2.Text
    '    'RaiseEvent RepeatResultClick(Me.StandardNumber)
    'End Sub

    'Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
    '    mRemoveAbs = TextBox3.Text
    '    'RaiseEvent RepeatResultClick(Me.StandardNumber)
    'End Sub

    'Private Sub RepeatResultsControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click

    'RaiseEvent RepeatResultClick(Me.StandardNumber)
    'End Sub

    'Private Sub CustomPanel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomPanel1.Click
    '    'RaiseEvent RepeatResultClick(Me.StandardNumber)
    'End Sub
#End Region

#Region "Form Events"
    Private Sub RepeatResultsControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : RepeatResultsControl_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To load the control
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 22.07.07
        ' Revisions             : 
        '=====================================================================
        Dim intCtrlCount As Integer
        Try
            For intCtrlCount = 0 To Me.CustomPanel1.Controls.Count - 1
                If TypeOf Me.CustomPanel1.Controls(intCtrlCount) Is System.Windows.Forms.TextBox Then
                    If Me.CustomPanel1.Controls(intCtrlCount).Tag <> Nothing Then
                        AddHandler Me.CustomPanel1.Controls(intCtrlCount).Click, AddressOf SubGetRepeatNumber
                    End If
                End If
            Next
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
#End Region

#Region "Private Functions"
    Private Sub SubGetRepeatNumber(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : SubGetRepeatNumber
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To get the repeat number
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 22.07.07
        ' Revisions             : 
        '=====================================================================
        Try
            'following routine of code is called two times purposely to solve a bug
            RepeatNumber = CInt(CType(sender, System.Windows.Forms.TextBox).Tag)
            RaiseEvent RepeatItemClick(StandardNumber, RepeatNumber, IsStandard, Me.CustomPanel1.Controls)
            RepeatNumber = CInt(CType(sender, System.Windows.Forms.TextBox).Tag)
            RaiseEvent RepeatItemClick(StandardNumber, RepeatNumber, IsStandard, Me.CustomPanel1.Controls)
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
#End Region

End Class
