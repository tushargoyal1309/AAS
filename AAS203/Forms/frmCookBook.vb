Imports AAS203.Common
Public Class frmCookBook ''class behind the form
    Inherits System.Windows.Forms.Form

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









    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusBar1 As NETXP.Controls.Bars.StatusBar
    Friend WithEvents btnHa As NETXP.Controls.XPButton
    Friend WithEvents btnRf As NETXP.Controls.XPButton
    Friend WithEvents btnHe As NETXP.Controls.XPButton
    Friend WithEvents btnFm As NETXP.Controls.XPButton
    Friend WithEvents btnEs As NETXP.Controls.XPButton
    Friend WithEvents btnCf As NETXP.Controls.XPButton
    Friend WithEvents btnBk As NETXP.Controls.XPButton
    Friend WithEvents btnCm As NETXP.Controls.XPButton
    Friend WithEvents btnAm As NETXP.Controls.XPButton
    Friend WithEvents btnPu As NETXP.Controls.XPButton
    Friend WithEvents btnNp As NETXP.Controls.XPButton
    Friend WithEvents btnU As NETXP.Controls.XPButton
    Friend WithEvents btnPa As NETXP.Controls.XPButton
    Friend WithEvents btnTh As NETXP.Controls.XPButton
    Friend WithEvents btnAc As NETXP.Controls.XPButton
    Friend WithEvents btnRa As NETXP.Controls.XPButton
    Friend WithEvents btnFr As NETXP.Controls.XPButton
    Friend WithEvents btnBi As NETXP.Controls.XPButton
    Friend WithEvents btnPb As NETXP.Controls.XPButton
    Friend WithEvents btnTl As NETXP.Controls.XPButton
    Friend WithEvents btnHg As NETXP.Controls.XPButton
    Friend WithEvents btnAu As NETXP.Controls.XPButton
    Friend WithEvents btnPt As NETXP.Controls.XPButton
    Friend WithEvents btnIr As NETXP.Controls.XPButton
    Friend WithEvents btnOs As NETXP.Controls.XPButton
    Friend WithEvents btnRe As NETXP.Controls.XPButton
    Friend WithEvents btnW As NETXP.Controls.XPButton
    Friend WithEvents btnHf As NETXP.Controls.XPButton
    Friend WithEvents btnEr As NETXP.Controls.XPButton
    Friend WithEvents btnHo As NETXP.Controls.XPButton
    Friend WithEvents btnDy As NETXP.Controls.XPButton
    Friend WithEvents btnTb As NETXP.Controls.XPButton
    Friend WithEvents btnGd As NETXP.Controls.XPButton
    Friend WithEvents btnEu As NETXP.Controls.XPButton
    Friend WithEvents btnSm As NETXP.Controls.XPButton
    Friend WithEvents btnPm As NETXP.Controls.XPButton
    Friend WithEvents btnNd As NETXP.Controls.XPButton
    Friend WithEvents btnPr As NETXP.Controls.XPButton
    Friend WithEvents btnCe As NETXP.Controls.XPButton
    Friend WithEvents btnLa As NETXP.Controls.XPButton
    Friend WithEvents btnBa As NETXP.Controls.XPButton
    Friend WithEvents btnCs As NETXP.Controls.XPButton
    Friend WithEvents btnSb As NETXP.Controls.XPButton
    Friend WithEvents btnSn As NETXP.Controls.XPButton
    Friend WithEvents btnIn As NETXP.Controls.XPButton
    Friend WithEvents btnCd As NETXP.Controls.XPButton
    Friend WithEvents btnAg As NETXP.Controls.XPButton
    Friend WithEvents btnPd As NETXP.Controls.XPButton
    Friend WithEvents btnRh As NETXP.Controls.XPButton
    Friend WithEvents btnRu As NETXP.Controls.XPButton
    Friend WithEvents btnTc As NETXP.Controls.XPButton
    Friend WithEvents btnMo As NETXP.Controls.XPButton
    Friend WithEvents btnZr As NETXP.Controls.XPButton
    Friend WithEvents btnY As NETXP.Controls.XPButton
    Friend WithEvents btnSr As NETXP.Controls.XPButton
    Friend WithEvents btnRb As NETXP.Controls.XPButton
    Friend WithEvents btnAs As NETXP.Controls.XPButton
    Friend WithEvents btnGe As NETXP.Controls.XPButton
    Friend WithEvents btnGa As NETXP.Controls.XPButton
    Friend WithEvents btnZn As NETXP.Controls.XPButton
    Friend WithEvents btnCu As NETXP.Controls.XPButton
    Friend WithEvents btnNi As NETXP.Controls.XPButton
    Friend WithEvents btnCo As NETXP.Controls.XPButton
    Friend WithEvents btnFe As NETXP.Controls.XPButton
    Friend WithEvents btnMn As NETXP.Controls.XPButton
    Friend WithEvents btnCr As NETXP.Controls.XPButton
    Friend WithEvents btnTi As NETXP.Controls.XPButton
    Friend WithEvents btnSc As NETXP.Controls.XPButton
    Friend WithEvents btnCa As NETXP.Controls.XPButton
    Friend WithEvents btnK As NETXP.Controls.XPButton
    Friend WithEvents btnP As NETXP.Controls.XPButton
    Friend WithEvents btnSi As NETXP.Controls.XPButton
    Friend WithEvents btnAl As NETXP.Controls.XPButton
    Friend WithEvents btnMg As NETXP.Controls.XPButton
    Friend WithEvents btnNa As NETXP.Controls.XPButton
    Friend WithEvents btnN As NETXP.Controls.XPButton
    Friend WithEvents btnC As NETXP.Controls.XPButton
    Friend WithEvents btnB As NETXP.Controls.XPButton
    Friend WithEvents btnBe As NETXP.Controls.XPButton
    Friend WithEvents btnLi As NETXP.Controls.XPButton
    Friend WithEvents btnH As NETXP.Controls.XPButton
    Friend WithEvents btnLr As NETXP.Controls.XPButton
    Friend WithEvents btnNo As NETXP.Controls.XPButton
    Friend WithEvents btnMd As NETXP.Controls.XPButton
    Friend WithEvents btnRn As NETXP.Controls.XPButton
    Friend WithEvents btnAt As NETXP.Controls.XPButton
    Friend WithEvents btnPo As NETXP.Controls.XPButton
    Friend WithEvents btnLu As NETXP.Controls.XPButton
    Friend WithEvents btnYb As NETXP.Controls.XPButton
    Friend WithEvents btnTm As NETXP.Controls.XPButton
    Friend WithEvents btnXe As NETXP.Controls.XPButton
    Friend WithEvents btnI As NETXP.Controls.XPButton
    Friend WithEvents btnTe As NETXP.Controls.XPButton
    Friend WithEvents btnKr As NETXP.Controls.XPButton
    Friend WithEvents btnBr As NETXP.Controls.XPButton
    Friend WithEvents btnSe As NETXP.Controls.XPButton
    Friend WithEvents btnAr As NETXP.Controls.XPButton
    Friend WithEvents btnCl As NETXP.Controls.XPButton
    Friend WithEvents btnS As NETXP.Controls.XPButton
    Friend WithEvents btnNe As NETXP.Controls.XPButton
    Friend WithEvents btnF As NETXP.Controls.XPButton
    Friend WithEvents btnO As NETXP.Controls.XPButton
    Friend WithEvents GroupBoxMultielementLamps As System.Windows.Forms.GroupBox
    Friend WithEvents btnCuZn As NETXP.Controls.XPButton
    Friend WithEvents btnNaK As NETXP.Controls.XPButton
    Friend WithEvents btnCaMg As NETXP.Controls.XPButton
    Friend WithEvents cmbSelectElement As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelectElement As System.Windows.Forms.Label
    Friend WithEvents btnCancel As NETXP.Controls.XPButton
    Friend WithEvents btnCrCoCuFeMnNi As NETXP.Controls.XPButton
    Friend WithEvents btnBlank As NETXP.Controls.XPButton
    Friend WithEvents btnTa As NETXP.Controls.XPButton
    Friend WithEvents btnNb As NETXP.Controls.XPButton
    Friend WithEvents btnV As NETXP.Controls.XPButton
    Friend WithEvents CustomPanelMain As GradientPanel.CustomPanel
    Friend WithEvents lblVIIIB As System.Windows.Forms.Label
    Friend WithEvents VIIB As System.Windows.Forms.Label
    Friend WithEvents lblVIB As System.Windows.Forms.Label
    Friend WithEvents lblVB As System.Windows.Forms.Label
    Friend WithEvents IVB As System.Windows.Forms.Label
    Friend WithEvents lblIIIB As System.Windows.Forms.Label
    Friend WithEvents lblIIB As System.Windows.Forms.Label
    Friend WithEvents lblIB As System.Windows.Forms.Label
    Friend WithEvents lblVIIIA As System.Windows.Forms.Label
    Friend WithEvents lblVIIA As System.Windows.Forms.Label
    Friend WithEvents lblVIA As System.Windows.Forms.Label
    Friend WithEvents lblVA As System.Windows.Forms.Label
    Friend WithEvents lblIVA As System.Windows.Forms.Label
    Friend WithEvents IIIA As System.Windows.Forms.Label
    Friend WithEvents lblIIA As System.Windows.Forms.Label
    Friend WithEvents lblIA As System.Windows.Forms.Label
    Friend WithEvents btnSelect As NETXP.Controls.XPButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnExtinguish As NETXP.Controls.XPButton
    Friend WithEvents btnIgnite As NETXP.Controls.XPButton
    Friend WithEvents StatusBarPanelInfo As System.Windows.Forms.StatusBarPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnN2OIgnite As NETXP.Controls.XPButton
    Friend WithEvents btnDelete As NETXP.Controls.XPButton
    Friend WithEvents btnR As NETXP.Controls.XPButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCookBook))
        Me.CustomPanelMain = New GradientPanel.CustomPanel
        Me.btnCancel = New NETXP.Controls.XPButton
        Me.btnDelete = New NETXP.Controls.XPButton
        Me.btnR = New NETXP.Controls.XPButton
        Me.btnN2OIgnite = New NETXP.Controls.XPButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnExtinguish = New NETXP.Controls.XPButton
        Me.btnIgnite = New NETXP.Controls.XPButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSelect = New NETXP.Controls.XPButton
        Me.cmbSelectElement = New System.Windows.Forms.ComboBox
        Me.lblSelectElement = New System.Windows.Forms.Label
        Me.lblVIIIB = New System.Windows.Forms.Label
        Me.VIIB = New System.Windows.Forms.Label
        Me.lblVIB = New System.Windows.Forms.Label
        Me.lblVB = New System.Windows.Forms.Label
        Me.IVB = New System.Windows.Forms.Label
        Me.lblIIIB = New System.Windows.Forms.Label
        Me.lblIIB = New System.Windows.Forms.Label
        Me.lblIB = New System.Windows.Forms.Label
        Me.lblVIIIA = New System.Windows.Forms.Label
        Me.lblVIIA = New System.Windows.Forms.Label
        Me.lblVIA = New System.Windows.Forms.Label
        Me.lblVA = New System.Windows.Forms.Label
        Me.lblIVA = New System.Windows.Forms.Label
        Me.IIIA = New System.Windows.Forms.Label
        Me.lblIIA = New System.Windows.Forms.Label
        Me.lblIA = New System.Windows.Forms.Label
        Me.GroupBoxMultielementLamps = New System.Windows.Forms.GroupBox
        Me.btnCrCoCuFeMnNi = New NETXP.Controls.XPButton
        Me.btnCuZn = New NETXP.Controls.XPButton
        Me.btnNaK = New NETXP.Controls.XPButton
        Me.btnCaMg = New NETXP.Controls.XPButton
        Me.btnBlank = New NETXP.Controls.XPButton
        Me.btnHa = New NETXP.Controls.XPButton
        Me.btnRf = New NETXP.Controls.XPButton
        Me.btnHe = New NETXP.Controls.XPButton
        Me.btnLr = New NETXP.Controls.XPButton
        Me.btnNo = New NETXP.Controls.XPButton
        Me.btnMd = New NETXP.Controls.XPButton
        Me.btnFm = New NETXP.Controls.XPButton
        Me.btnEs = New NETXP.Controls.XPButton
        Me.btnCf = New NETXP.Controls.XPButton
        Me.btnBk = New NETXP.Controls.XPButton
        Me.btnCm = New NETXP.Controls.XPButton
        Me.btnAm = New NETXP.Controls.XPButton
        Me.btnPu = New NETXP.Controls.XPButton
        Me.btnNp = New NETXP.Controls.XPButton
        Me.btnU = New NETXP.Controls.XPButton
        Me.btnPa = New NETXP.Controls.XPButton
        Me.btnTh = New NETXP.Controls.XPButton
        Me.btnAc = New NETXP.Controls.XPButton
        Me.btnRa = New NETXP.Controls.XPButton
        Me.btnFr = New NETXP.Controls.XPButton
        Me.btnRn = New NETXP.Controls.XPButton
        Me.btnAt = New NETXP.Controls.XPButton
        Me.btnPo = New NETXP.Controls.XPButton
        Me.btnBi = New NETXP.Controls.XPButton
        Me.btnPb = New NETXP.Controls.XPButton
        Me.btnTl = New NETXP.Controls.XPButton
        Me.btnHg = New NETXP.Controls.XPButton
        Me.btnAu = New NETXP.Controls.XPButton
        Me.btnPt = New NETXP.Controls.XPButton
        Me.btnIr = New NETXP.Controls.XPButton
        Me.btnOs = New NETXP.Controls.XPButton
        Me.btnRe = New NETXP.Controls.XPButton
        Me.btnW = New NETXP.Controls.XPButton
        Me.btnTa = New NETXP.Controls.XPButton
        Me.btnHf = New NETXP.Controls.XPButton
        Me.btnLu = New NETXP.Controls.XPButton
        Me.btnYb = New NETXP.Controls.XPButton
        Me.btnTm = New NETXP.Controls.XPButton
        Me.btnEr = New NETXP.Controls.XPButton
        Me.btnHo = New NETXP.Controls.XPButton
        Me.btnDy = New NETXP.Controls.XPButton
        Me.btnTb = New NETXP.Controls.XPButton
        Me.btnGd = New NETXP.Controls.XPButton
        Me.btnEu = New NETXP.Controls.XPButton
        Me.btnSm = New NETXP.Controls.XPButton
        Me.btnPm = New NETXP.Controls.XPButton
        Me.btnNd = New NETXP.Controls.XPButton
        Me.btnPr = New NETXP.Controls.XPButton
        Me.btnCe = New NETXP.Controls.XPButton
        Me.btnLa = New NETXP.Controls.XPButton
        Me.btnBa = New NETXP.Controls.XPButton
        Me.btnCs = New NETXP.Controls.XPButton
        Me.btnXe = New NETXP.Controls.XPButton
        Me.btnI = New NETXP.Controls.XPButton
        Me.btnTe = New NETXP.Controls.XPButton
        Me.btnSb = New NETXP.Controls.XPButton
        Me.btnSn = New NETXP.Controls.XPButton
        Me.btnIn = New NETXP.Controls.XPButton
        Me.btnCd = New NETXP.Controls.XPButton
        Me.btnAg = New NETXP.Controls.XPButton
        Me.btnPd = New NETXP.Controls.XPButton
        Me.btnRh = New NETXP.Controls.XPButton
        Me.btnRu = New NETXP.Controls.XPButton
        Me.btnTc = New NETXP.Controls.XPButton
        Me.btnMo = New NETXP.Controls.XPButton
        Me.btnNb = New NETXP.Controls.XPButton
        Me.btnZr = New NETXP.Controls.XPButton
        Me.btnY = New NETXP.Controls.XPButton
        Me.btnSr = New NETXP.Controls.XPButton
        Me.btnRb = New NETXP.Controls.XPButton
        Me.btnKr = New NETXP.Controls.XPButton
        Me.btnBr = New NETXP.Controls.XPButton
        Me.btnSe = New NETXP.Controls.XPButton
        Me.btnAs = New NETXP.Controls.XPButton
        Me.btnGe = New NETXP.Controls.XPButton
        Me.btnGa = New NETXP.Controls.XPButton
        Me.btnZn = New NETXP.Controls.XPButton
        Me.btnCu = New NETXP.Controls.XPButton
        Me.btnNi = New NETXP.Controls.XPButton
        Me.btnCo = New NETXP.Controls.XPButton
        Me.btnFe = New NETXP.Controls.XPButton
        Me.btnMn = New NETXP.Controls.XPButton
        Me.btnCr = New NETXP.Controls.XPButton
        Me.btnV = New NETXP.Controls.XPButton
        Me.btnTi = New NETXP.Controls.XPButton
        Me.btnSc = New NETXP.Controls.XPButton
        Me.btnCa = New NETXP.Controls.XPButton
        Me.btnK = New NETXP.Controls.XPButton
        Me.btnAr = New NETXP.Controls.XPButton
        Me.btnCl = New NETXP.Controls.XPButton
        Me.btnS = New NETXP.Controls.XPButton
        Me.btnP = New NETXP.Controls.XPButton
        Me.btnSi = New NETXP.Controls.XPButton
        Me.btnAl = New NETXP.Controls.XPButton
        Me.btnMg = New NETXP.Controls.XPButton
        Me.btnNa = New NETXP.Controls.XPButton
        Me.btnNe = New NETXP.Controls.XPButton
        Me.btnF = New NETXP.Controls.XPButton
        Me.btnO = New NETXP.Controls.XPButton
        Me.btnN = New NETXP.Controls.XPButton
        Me.btnC = New NETXP.Controls.XPButton
        Me.btnB = New NETXP.Controls.XPButton
        Me.btnBe = New NETXP.Controls.XPButton
        Me.btnLi = New NETXP.Controls.XPButton
        Me.btnH = New NETXP.Controls.XPButton
        Me.StatusBar1 = New NETXP.Controls.Bars.StatusBar
        Me.StatusBarPanelInfo = New System.Windows.Forms.StatusBarPanel
        Me.CustomPanelMain.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBoxMultielementLamps.SuspendLayout()
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomPanelMain
        '
        Me.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue
        Me.CustomPanelMain.Controls.Add(Me.btnCancel)
        Me.CustomPanelMain.Controls.Add(Me.btnDelete)
        Me.CustomPanelMain.Controls.Add(Me.btnR)
        Me.CustomPanelMain.Controls.Add(Me.btnN2OIgnite)
        Me.CustomPanelMain.Controls.Add(Me.GroupBox3)
        Me.CustomPanelMain.Controls.Add(Me.btnExtinguish)
        Me.CustomPanelMain.Controls.Add(Me.btnIgnite)
        Me.CustomPanelMain.Controls.Add(Me.GroupBox1)
        Me.CustomPanelMain.Controls.Add(Me.btnSelect)
        Me.CustomPanelMain.Controls.Add(Me.cmbSelectElement)
        Me.CustomPanelMain.Controls.Add(Me.lblSelectElement)
        Me.CustomPanelMain.Controls.Add(Me.lblVIIIB)
        Me.CustomPanelMain.Controls.Add(Me.VIIB)
        Me.CustomPanelMain.Controls.Add(Me.lblVIB)
        Me.CustomPanelMain.Controls.Add(Me.lblVB)
        Me.CustomPanelMain.Controls.Add(Me.IVB)
        Me.CustomPanelMain.Controls.Add(Me.lblIIIB)
        Me.CustomPanelMain.Controls.Add(Me.lblIIB)
        Me.CustomPanelMain.Controls.Add(Me.lblIB)
        Me.CustomPanelMain.Controls.Add(Me.lblVIIIA)
        Me.CustomPanelMain.Controls.Add(Me.lblVIIA)
        Me.CustomPanelMain.Controls.Add(Me.lblVIA)
        Me.CustomPanelMain.Controls.Add(Me.lblVA)
        Me.CustomPanelMain.Controls.Add(Me.lblIVA)
        Me.CustomPanelMain.Controls.Add(Me.IIIA)
        Me.CustomPanelMain.Controls.Add(Me.lblIIA)
        Me.CustomPanelMain.Controls.Add(Me.lblIA)
        Me.CustomPanelMain.Controls.Add(Me.GroupBoxMultielementLamps)
        Me.CustomPanelMain.Controls.Add(Me.btnBlank)
        Me.CustomPanelMain.Controls.Add(Me.btnHa)
        Me.CustomPanelMain.Controls.Add(Me.btnRf)
        Me.CustomPanelMain.Controls.Add(Me.btnHe)
        Me.CustomPanelMain.Controls.Add(Me.btnLr)
        Me.CustomPanelMain.Controls.Add(Me.btnNo)
        Me.CustomPanelMain.Controls.Add(Me.btnMd)
        Me.CustomPanelMain.Controls.Add(Me.btnFm)
        Me.CustomPanelMain.Controls.Add(Me.btnEs)
        Me.CustomPanelMain.Controls.Add(Me.btnCf)
        Me.CustomPanelMain.Controls.Add(Me.btnBk)
        Me.CustomPanelMain.Controls.Add(Me.btnCm)
        Me.CustomPanelMain.Controls.Add(Me.btnAm)
        Me.CustomPanelMain.Controls.Add(Me.btnPu)
        Me.CustomPanelMain.Controls.Add(Me.btnNp)
        Me.CustomPanelMain.Controls.Add(Me.btnU)
        Me.CustomPanelMain.Controls.Add(Me.btnPa)
        Me.CustomPanelMain.Controls.Add(Me.btnTh)
        Me.CustomPanelMain.Controls.Add(Me.btnAc)
        Me.CustomPanelMain.Controls.Add(Me.btnRa)
        Me.CustomPanelMain.Controls.Add(Me.btnFr)
        Me.CustomPanelMain.Controls.Add(Me.btnRn)
        Me.CustomPanelMain.Controls.Add(Me.btnAt)
        Me.CustomPanelMain.Controls.Add(Me.btnPo)
        Me.CustomPanelMain.Controls.Add(Me.btnBi)
        Me.CustomPanelMain.Controls.Add(Me.btnPb)
        Me.CustomPanelMain.Controls.Add(Me.btnTl)
        Me.CustomPanelMain.Controls.Add(Me.btnHg)
        Me.CustomPanelMain.Controls.Add(Me.btnAu)
        Me.CustomPanelMain.Controls.Add(Me.btnPt)
        Me.CustomPanelMain.Controls.Add(Me.btnIr)
        Me.CustomPanelMain.Controls.Add(Me.btnOs)
        Me.CustomPanelMain.Controls.Add(Me.btnRe)
        Me.CustomPanelMain.Controls.Add(Me.btnW)
        Me.CustomPanelMain.Controls.Add(Me.btnTa)
        Me.CustomPanelMain.Controls.Add(Me.btnHf)
        Me.CustomPanelMain.Controls.Add(Me.btnLu)
        Me.CustomPanelMain.Controls.Add(Me.btnYb)
        Me.CustomPanelMain.Controls.Add(Me.btnTm)
        Me.CustomPanelMain.Controls.Add(Me.btnEr)
        Me.CustomPanelMain.Controls.Add(Me.btnHo)
        Me.CustomPanelMain.Controls.Add(Me.btnDy)
        Me.CustomPanelMain.Controls.Add(Me.btnTb)
        Me.CustomPanelMain.Controls.Add(Me.btnGd)
        Me.CustomPanelMain.Controls.Add(Me.btnEu)
        Me.CustomPanelMain.Controls.Add(Me.btnSm)
        Me.CustomPanelMain.Controls.Add(Me.btnPm)
        Me.CustomPanelMain.Controls.Add(Me.btnNd)
        Me.CustomPanelMain.Controls.Add(Me.btnPr)
        Me.CustomPanelMain.Controls.Add(Me.btnCe)
        Me.CustomPanelMain.Controls.Add(Me.btnLa)
        Me.CustomPanelMain.Controls.Add(Me.btnBa)
        Me.CustomPanelMain.Controls.Add(Me.btnCs)
        Me.CustomPanelMain.Controls.Add(Me.btnXe)
        Me.CustomPanelMain.Controls.Add(Me.btnI)
        Me.CustomPanelMain.Controls.Add(Me.btnTe)
        Me.CustomPanelMain.Controls.Add(Me.btnSb)
        Me.CustomPanelMain.Controls.Add(Me.btnSn)
        Me.CustomPanelMain.Controls.Add(Me.btnIn)
        Me.CustomPanelMain.Controls.Add(Me.btnCd)
        Me.CustomPanelMain.Controls.Add(Me.btnAg)
        Me.CustomPanelMain.Controls.Add(Me.btnPd)
        Me.CustomPanelMain.Controls.Add(Me.btnRh)
        Me.CustomPanelMain.Controls.Add(Me.btnRu)
        Me.CustomPanelMain.Controls.Add(Me.btnTc)
        Me.CustomPanelMain.Controls.Add(Me.btnMo)
        Me.CustomPanelMain.Controls.Add(Me.btnNb)
        Me.CustomPanelMain.Controls.Add(Me.btnZr)
        Me.CustomPanelMain.Controls.Add(Me.btnY)
        Me.CustomPanelMain.Controls.Add(Me.btnSr)
        Me.CustomPanelMain.Controls.Add(Me.btnRb)
        Me.CustomPanelMain.Controls.Add(Me.btnKr)
        Me.CustomPanelMain.Controls.Add(Me.btnBr)
        Me.CustomPanelMain.Controls.Add(Me.btnSe)
        Me.CustomPanelMain.Controls.Add(Me.btnAs)
        Me.CustomPanelMain.Controls.Add(Me.btnGe)
        Me.CustomPanelMain.Controls.Add(Me.btnGa)
        Me.CustomPanelMain.Controls.Add(Me.btnZn)
        Me.CustomPanelMain.Controls.Add(Me.btnCu)
        Me.CustomPanelMain.Controls.Add(Me.btnNi)
        Me.CustomPanelMain.Controls.Add(Me.btnCo)
        Me.CustomPanelMain.Controls.Add(Me.btnFe)
        Me.CustomPanelMain.Controls.Add(Me.btnMn)
        Me.CustomPanelMain.Controls.Add(Me.btnCr)
        Me.CustomPanelMain.Controls.Add(Me.btnV)
        Me.CustomPanelMain.Controls.Add(Me.btnTi)
        Me.CustomPanelMain.Controls.Add(Me.btnSc)
        Me.CustomPanelMain.Controls.Add(Me.btnCa)
        Me.CustomPanelMain.Controls.Add(Me.btnK)
        Me.CustomPanelMain.Controls.Add(Me.btnAr)
        Me.CustomPanelMain.Controls.Add(Me.btnCl)
        Me.CustomPanelMain.Controls.Add(Me.btnS)
        Me.CustomPanelMain.Controls.Add(Me.btnP)
        Me.CustomPanelMain.Controls.Add(Me.btnSi)
        Me.CustomPanelMain.Controls.Add(Me.btnAl)
        Me.CustomPanelMain.Controls.Add(Me.btnMg)
        Me.CustomPanelMain.Controls.Add(Me.btnNa)
        Me.CustomPanelMain.Controls.Add(Me.btnNe)
        Me.CustomPanelMain.Controls.Add(Me.btnF)
        Me.CustomPanelMain.Controls.Add(Me.btnO)
        Me.CustomPanelMain.Controls.Add(Me.btnN)
        Me.CustomPanelMain.Controls.Add(Me.btnC)
        Me.CustomPanelMain.Controls.Add(Me.btnB)
        Me.CustomPanelMain.Controls.Add(Me.btnBe)
        Me.CustomPanelMain.Controls.Add(Me.btnLi)
        Me.CustomPanelMain.Controls.Add(Me.btnH)
        Me.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomPanelMain.Location = New System.Drawing.Point(0, 0)
        Me.CustomPanelMain.Name = "CustomPanelMain"
        Me.CustomPanelMain.Size = New System.Drawing.Size(700, 491)
        Me.CustomPanelMain.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(558, 419)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 40)
        Me.btnCancel.TabIndex = 111
        Me.btnCancel.Text = "Ca&ncel"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(626, 424)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(8, 8)
        Me.btnDelete.TabIndex = 137
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnR
        '
        Me.btnR.BackColor = System.Drawing.Color.Transparent
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnR.Location = New System.Drawing.Point(636, 424)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(8, 8)
        Me.btnR.TabIndex = 136
        Me.btnR.TabStop = False
        Me.btnR.Text = "&R"
        Me.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnN2OIgnite
        '
        Me.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN2OIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN2OIgnite.Location = New System.Drawing.Point(608, 422)
        Me.btnN2OIgnite.Name = "btnN2OIgnite"
        Me.btnN2OIgnite.Size = New System.Drawing.Size(5, 5)
        Me.btnN2OIgnite.TabIndex = 135
        Me.btnN2OIgnite.TabStop = False
        Me.btnN2OIgnite.Text = "N2O&C"
        Me.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(320, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(122, 100)
        Me.GroupBox3.TabIndex = 134
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Key To Element"
        '
        'Label13
        '
        Me.Label13.Image = CType(resources.GetObject("Label13.Image"), System.Drawing.Image)
        Me.Label13.Location = New System.Drawing.Point(-6, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(134, 76)
        Me.Label13.TabIndex = 0
        '
        'btnExtinguish
        '
        Me.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExtinguish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExtinguish.Location = New System.Drawing.Point(570, 432)
        Me.btnExtinguish.Name = "btnExtinguish"
        Me.btnExtinguish.Size = New System.Drawing.Size(26, 18)
        Me.btnExtinguish.TabIndex = 132
        Me.btnExtinguish.TabStop = False
        Me.btnExtinguish.Text = "&Extinguish"
        Me.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'btnIgnite
        '
        Me.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIgnite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIgnite.Location = New System.Drawing.Point(616, 432)
        Me.btnIgnite.Name = "btnIgnite"
        Me.btnIgnite.Size = New System.Drawing.Size(22, 17)
        Me.btnIgnite.TabIndex = 131
        Me.btnIgnite.TabStop = False
        Me.btnIgnite.Text = "&Ignition"
        Me.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(172, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(144, 100)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "COLOR KEY"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(94, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(48, 60)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(2, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 48)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "State of    E lements at room temp.  "
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(56, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 20)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "SYNTHETICALLY CREATED"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(56, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 10)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "RADIOACTIVE"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(56, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 10)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "SOLID"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(56, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 10)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "LIQUID"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 10)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "GAS"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LimeGreen
        Me.Label6.Location = New System.Drawing.Point(9, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 14)
        Me.Label6.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Magenta
        Me.Label5.Location = New System.Drawing.Point(9, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 14)
        Me.Label5.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(9, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 14)
        Me.Label4.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(9, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 14)
        Me.Label3.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Goldenrod
        Me.Label2.Location = New System.Drawing.Point(9, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 0
        '
        'btnSelect
        '
        Me.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelect.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.Image = CType(resources.GetObject("btnSelect.Image"), System.Drawing.Image)
        Me.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSelect.Location = New System.Drawing.Point(444, 8)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(90, 34)
        Me.btnSelect.TabIndex = 1
        Me.btnSelect.Text = "&Select"
        '
        'cmbSelectElement
        '
        Me.cmbSelectElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelectElement.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSelectElement.Location = New System.Drawing.Point(268, 9)
        Me.cmbSelectElement.Name = "cmbSelectElement"
        Me.cmbSelectElement.Size = New System.Drawing.Size(152, 23)
        Me.cmbSelectElement.TabIndex = 0
        '
        'lblSelectElement
        '
        Me.lblSelectElement.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectElement.Location = New System.Drawing.Point(96, 13)
        Me.lblSelectElement.Name = "lblSelectElement"
        Me.lblSelectElement.Size = New System.Drawing.Size(170, 20)
        Me.lblSelectElement.TabIndex = 128
        Me.lblSelectElement.Text = "Select element from the list :-"
        '
        'lblVIIIB
        '
        Me.lblVIIIB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIIIB.Location = New System.Drawing.Point(306, 124)
        Me.lblVIIIB.Name = "lblVIIIB"
        Me.lblVIIIB.Size = New System.Drawing.Size(50, 34)
        Me.lblVIIIB.TabIndex = 127
        Me.lblVIIIB.Text = "VIIIB"
        Me.lblVIIIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'VIIB
        '
        Me.VIIB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VIIB.Location = New System.Drawing.Point(236, 122)
        Me.VIIB.Name = "VIIB"
        Me.VIIB.Size = New System.Drawing.Size(44, 36)
        Me.VIIB.TabIndex = 126
        Me.VIIB.Text = "VIIB"
        Me.VIIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblVIB
        '
        Me.lblVIB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIB.Location = New System.Drawing.Point(201, 128)
        Me.lblVIB.Name = "lblVIB"
        Me.lblVIB.Size = New System.Drawing.Size(38, 30)
        Me.lblVIB.TabIndex = 125
        Me.lblVIB.Text = "VIB"
        Me.lblVIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblVB
        '
        Me.lblVB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVB.Location = New System.Drawing.Point(171, 126)
        Me.lblVB.Name = "lblVB"
        Me.lblVB.Size = New System.Drawing.Size(36, 32)
        Me.lblVB.TabIndex = 124
        Me.lblVB.Text = "VB"
        Me.lblVB.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'IVB
        '
        Me.IVB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IVB.Location = New System.Drawing.Point(132, 126)
        Me.IVB.Name = "IVB"
        Me.IVB.Size = New System.Drawing.Size(40, 32)
        Me.IVB.TabIndex = 123
        Me.IVB.Text = "IVB"
        Me.IVB.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblIIIB
        '
        Me.lblIIIB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIIIB.Location = New System.Drawing.Point(96, 124)
        Me.lblIIIB.Name = "lblIIIB"
        Me.lblIIIB.Size = New System.Drawing.Size(38, 34)
        Me.lblIIIB.TabIndex = 122
        Me.lblIIIB.Text = "IIIB"
        Me.lblIIIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblIIB
        '
        Me.lblIIB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIIB.Location = New System.Drawing.Point(420, 125)
        Me.lblIIB.Name = "lblIIB"
        Me.lblIIB.Size = New System.Drawing.Size(38, 32)
        Me.lblIIB.TabIndex = 121
        Me.lblIIB.Text = "IIB"
        Me.lblIIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblIB
        '
        Me.lblIB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIB.Location = New System.Drawing.Point(388, 127)
        Me.lblIB.Name = "lblIB"
        Me.lblIB.Size = New System.Drawing.Size(34, 30)
        Me.lblIB.TabIndex = 120
        Me.lblIB.Text = "IB"
        Me.lblIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblVIIIA
        '
        Me.lblVIIIA.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIIIA.Location = New System.Drawing.Point(628, 28)
        Me.lblVIIIA.Name = "lblVIIIA"
        Me.lblVIIIA.Size = New System.Drawing.Size(50, 26)
        Me.lblVIIIA.TabIndex = 119
        Me.lblVIIIA.Text = "VIIIA"
        Me.lblVIIIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblVIIA
        '
        Me.lblVIIA.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIIA.Location = New System.Drawing.Point(594, 55)
        Me.lblVIIA.Name = "lblVIIA"
        Me.lblVIIA.Size = New System.Drawing.Size(44, 30)
        Me.lblVIIA.TabIndex = 118
        Me.lblVIIA.Text = "VIIA"
        Me.lblVIIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblVIA
        '
        Me.lblVIA.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIA.Location = New System.Drawing.Point(558, 53)
        Me.lblVIA.Name = "lblVIA"
        Me.lblVIA.Size = New System.Drawing.Size(41, 32)
        Me.lblVIA.TabIndex = 117
        Me.lblVIA.Text = "VIA"
        Me.lblVIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblVA
        '
        Me.lblVA.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVA.Location = New System.Drawing.Point(526, 54)
        Me.lblVA.Name = "lblVA"
        Me.lblVA.Size = New System.Drawing.Size(38, 32)
        Me.lblVA.TabIndex = 116
        Me.lblVA.Text = "VA"
        Me.lblVA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblIVA
        '
        Me.lblIVA.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVA.Location = New System.Drawing.Point(492, 56)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(38, 30)
        Me.lblIVA.TabIndex = 115
        Me.lblIVA.Text = "IVA"
        Me.lblIVA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'IIIA
        '
        Me.IIIA.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IIIA.Location = New System.Drawing.Point(455, 54)
        Me.IIIA.Name = "IIIA"
        Me.IIIA.Size = New System.Drawing.Size(38, 32)
        Me.IIIA.TabIndex = 114
        Me.IIIA.Text = "IIIA"
        Me.IIIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblIIA
        '
        Me.lblIIA.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIIA.Location = New System.Drawing.Point(62, 60)
        Me.lblIIA.Name = "lblIIA"
        Me.lblIIA.Size = New System.Drawing.Size(32, 26)
        Me.lblIIA.TabIndex = 113
        Me.lblIIA.Text = "IIA"
        Me.lblIIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblIA
        '
        Me.lblIA.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIA.Location = New System.Drawing.Point(28, 28)
        Me.lblIA.Name = "lblIA"
        Me.lblIA.Size = New System.Drawing.Size(32, 26)
        Me.lblIA.TabIndex = 112
        Me.lblIA.Text = "IA"
        Me.lblIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBoxMultielementLamps
        '
        Me.GroupBoxMultielementLamps.Controls.Add(Me.btnCrCoCuFeMnNi)
        Me.GroupBoxMultielementLamps.Controls.Add(Me.btnCuZn)
        Me.GroupBoxMultielementLamps.Controls.Add(Me.btnNaK)
        Me.GroupBoxMultielementLamps.Controls.Add(Me.btnCaMg)
        Me.GroupBoxMultielementLamps.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxMultielementLamps.Location = New System.Drawing.Point(50, 400)
        Me.GroupBoxMultielementLamps.Name = "GroupBoxMultielementLamps"
        Me.GroupBoxMultielementLamps.Size = New System.Drawing.Size(480, 68)
        Me.GroupBoxMultielementLamps.TabIndex = 109
        Me.GroupBoxMultielementLamps.TabStop = False
        Me.GroupBoxMultielementLamps.Text = "Multielement Lamps"
        '
        'btnCrCoCuFeMnNi
        '
        Me.btnCrCoCuFeMnNi.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCrCoCuFeMnNi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrCoCuFeMnNi.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrCoCuFeMnNi.ForeColor = System.Drawing.Color.White
        Me.btnCrCoCuFeMnNi.Image = CType(resources.GetObject("btnCrCoCuFeMnNi.Image"), System.Drawing.Image)
        Me.btnCrCoCuFeMnNi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCrCoCuFeMnNi.Location = New System.Drawing.Point(272, 20)
        Me.btnCrCoCuFeMnNi.Name = "btnCrCoCuFeMnNi"
        Me.btnCrCoCuFeMnNi.Size = New System.Drawing.Size(177, 32)
        Me.btnCrCoCuFeMnNi.TabIndex = 3
        Me.btnCrCoCuFeMnNi.Tag = "70"
        '
        'btnCuZn
        '
        Me.btnCuZn.BackColor = System.Drawing.Color.White
        Me.btnCuZn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCuZn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCuZn.ForeColor = System.Drawing.Color.White
        Me.btnCuZn.Image = CType(resources.GetObject("btnCuZn.Image"), System.Drawing.Image)
        Me.btnCuZn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCuZn.Location = New System.Drawing.Point(186, 20)
        Me.btnCuZn.Name = "btnCuZn"
        Me.btnCuZn.Size = New System.Drawing.Size(67, 32)
        Me.btnCuZn.TabIndex = 2
        Me.btnCuZn.Tag = "69"
        '
        'btnNaK
        '
        Me.btnNaK.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnNaK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNaK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNaK.ForeColor = System.Drawing.Color.White
        Me.btnNaK.Image = CType(resources.GetObject("btnNaK.Image"), System.Drawing.Image)
        Me.btnNaK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNaK.Location = New System.Drawing.Point(100, 20)
        Me.btnNaK.Name = "btnNaK"
        Me.btnNaK.Size = New System.Drawing.Size(63, 32)
        Me.btnNaK.TabIndex = 1
        Me.btnNaK.Tag = "68"
        '
        'btnCaMg
        '
        Me.btnCaMg.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCaMg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCaMg.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCaMg.ForeColor = System.Drawing.Color.White
        Me.btnCaMg.Image = CType(resources.GetObject("btnCaMg.Image"), System.Drawing.Image)
        Me.btnCaMg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCaMg.Location = New System.Drawing.Point(12, 20)
        Me.btnCaMg.Name = "btnCaMg"
        Me.btnCaMg.Size = New System.Drawing.Size(63, 32)
        Me.btnCaMg.TabIndex = 0
        Me.btnCaMg.Tag = "67"
        '
        'btnBlank
        '
        Me.btnBlank.BackColor = System.Drawing.Color.White
        Me.btnBlank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBlank.Image = CType(resources.GetObject("btnBlank.Image"), System.Drawing.Image)
        Me.btnBlank.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBlank.Location = New System.Drawing.Point(206, 260)
        Me.btnBlank.Name = "btnBlank"
        Me.btnBlank.Size = New System.Drawing.Size(32, 32)
        Me.btnBlank.TabIndex = 108
        '
        'btnHa
        '
        Me.btnHa.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnHa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHa.Image = CType(resources.GetObject("btnHa.Image"), System.Drawing.Image)
        Me.btnHa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHa.Location = New System.Drawing.Point(170, 260)
        Me.btnHa.Name = "btnHa"
        Me.btnHa.Size = New System.Drawing.Size(32, 32)
        Me.btnHa.TabIndex = 107
        Me.btnHa.Tag = "103"
        '
        'btnRf
        '
        Me.btnRf.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnRf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRf.Image = CType(resources.GetObject("btnRf.Image"), System.Drawing.Image)
        Me.btnRf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRf.Location = New System.Drawing.Point(134, 260)
        Me.btnRf.Name = "btnRf"
        Me.btnRf.Size = New System.Drawing.Size(32, 32)
        Me.btnRf.TabIndex = 106
        Me.btnRf.Tag = "106"
        '
        'btnHe
        '
        Me.btnHe.BackColor = System.Drawing.Color.Gold
        Me.btnHe.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHe.Image = CType(resources.GetObject("btnHe.Image"), System.Drawing.Image)
        Me.btnHe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHe.Location = New System.Drawing.Point(26, 56)
        Me.btnHe.Name = "btnHe"
        Me.btnHe.Size = New System.Drawing.Size(32, 32)
        Me.btnHe.TabIndex = 2
        Me.btnHe.Tag = "71"
        '
        'btnLr
        '
        Me.btnLr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnLr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLr.Image = CType(resources.GetObject("btnLr.Image"), System.Drawing.Image)
        Me.btnLr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLr.Location = New System.Drawing.Point(638, 354)
        Me.btnLr.Name = "btnLr"
        Me.btnLr.Size = New System.Drawing.Size(32, 32)
        Me.btnLr.TabIndex = 104
        Me.btnLr.Tag = "98"
        '
        'btnNo
        '
        Me.btnNo.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNo.Image = CType(resources.GetObject("btnNo.Image"), System.Drawing.Image)
        Me.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNo.Location = New System.Drawing.Point(602, 354)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(32, 32)
        Me.btnNo.TabIndex = 103
        Me.btnNo.Tag = "97"
        '
        'btnMd
        '
        Me.btnMd.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnMd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMd.Image = CType(resources.GetObject("btnMd.Image"), System.Drawing.Image)
        Me.btnMd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMd.Location = New System.Drawing.Point(566, 354)
        Me.btnMd.Name = "btnMd"
        Me.btnMd.Size = New System.Drawing.Size(32, 32)
        Me.btnMd.TabIndex = 102
        Me.btnMd.Tag = "96"
        '
        'btnFm
        '
        Me.btnFm.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnFm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFm.Image = CType(resources.GetObject("btnFm.Image"), System.Drawing.Image)
        Me.btnFm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFm.Location = New System.Drawing.Point(530, 354)
        Me.btnFm.Name = "btnFm"
        Me.btnFm.Size = New System.Drawing.Size(32, 32)
        Me.btnFm.TabIndex = 101
        Me.btnFm.Tag = "95"
        '
        'btnEs
        '
        Me.btnEs.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnEs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEs.Image = CType(resources.GetObject("btnEs.Image"), System.Drawing.Image)
        Me.btnEs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEs.Location = New System.Drawing.Point(494, 354)
        Me.btnEs.Name = "btnEs"
        Me.btnEs.Size = New System.Drawing.Size(32, 32)
        Me.btnEs.TabIndex = 100
        Me.btnEs.Tag = "94"
        '
        'btnCf
        '
        Me.btnCf.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnCf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCf.Image = CType(resources.GetObject("btnCf.Image"), System.Drawing.Image)
        Me.btnCf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCf.Location = New System.Drawing.Point(458, 354)
        Me.btnCf.Name = "btnCf"
        Me.btnCf.Size = New System.Drawing.Size(32, 32)
        Me.btnCf.TabIndex = 99
        Me.btnCf.Tag = "93"
        '
        'btnBk
        '
        Me.btnBk.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnBk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBk.Image = CType(resources.GetObject("btnBk.Image"), System.Drawing.Image)
        Me.btnBk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBk.Location = New System.Drawing.Point(422, 354)
        Me.btnBk.Name = "btnBk"
        Me.btnBk.Size = New System.Drawing.Size(32, 32)
        Me.btnBk.TabIndex = 98
        Me.btnBk.Tag = "92"
        '
        'btnCm
        '
        Me.btnCm.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnCm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCm.Image = CType(resources.GetObject("btnCm.Image"), System.Drawing.Image)
        Me.btnCm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCm.Location = New System.Drawing.Point(386, 354)
        Me.btnCm.Name = "btnCm"
        Me.btnCm.Size = New System.Drawing.Size(32, 32)
        Me.btnCm.TabIndex = 97
        Me.btnCm.Tag = "91"
        '
        'btnAm
        '
        Me.btnAm.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnAm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAm.Image = CType(resources.GetObject("btnAm.Image"), System.Drawing.Image)
        Me.btnAm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAm.Location = New System.Drawing.Point(350, 354)
        Me.btnAm.Name = "btnAm"
        Me.btnAm.Size = New System.Drawing.Size(32, 32)
        Me.btnAm.TabIndex = 96
        Me.btnAm.Tag = "90"
        '
        'btnPu
        '
        Me.btnPu.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnPu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPu.Image = CType(resources.GetObject("btnPu.Image"), System.Drawing.Image)
        Me.btnPu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPu.Location = New System.Drawing.Point(314, 354)
        Me.btnPu.Name = "btnPu"
        Me.btnPu.Size = New System.Drawing.Size(32, 32)
        Me.btnPu.TabIndex = 95
        Me.btnPu.Tag = "89"
        '
        'btnNp
        '
        Me.btnNp.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnNp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNp.Image = CType(resources.GetObject("btnNp.Image"), System.Drawing.Image)
        Me.btnNp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNp.Location = New System.Drawing.Point(278, 354)
        Me.btnNp.Name = "btnNp"
        Me.btnNp.Size = New System.Drawing.Size(32, 32)
        Me.btnNp.TabIndex = 94
        Me.btnNp.Tag = "88"
        '
        'btnU
        '
        Me.btnU.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnU.Image = CType(resources.GetObject("btnU.Image"), System.Drawing.Image)
        Me.btnU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnU.Location = New System.Drawing.Point(242, 354)
        Me.btnU.Name = "btnU"
        Me.btnU.Size = New System.Drawing.Size(32, 32)
        Me.btnU.TabIndex = 93
        Me.btnU.Tag = "60"
        '
        'btnPa
        '
        Me.btnPa.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnPa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPa.Image = CType(resources.GetObject("btnPa.Image"), System.Drawing.Image)
        Me.btnPa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPa.Location = New System.Drawing.Point(206, 354)
        Me.btnPa.Name = "btnPa"
        Me.btnPa.Size = New System.Drawing.Size(32, 32)
        Me.btnPa.TabIndex = 92
        Me.btnPa.Tag = "87"
        '
        'btnTh
        '
        Me.btnTh.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnTh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTh.Image = CType(resources.GetObject("btnTh.Image"), System.Drawing.Image)
        Me.btnTh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTh.Location = New System.Drawing.Point(170, 354)
        Me.btnTh.Name = "btnTh"
        Me.btnTh.Size = New System.Drawing.Size(32, 32)
        Me.btnTh.TabIndex = 91
        Me.btnTh.Tag = "86"
        '
        'btnAc
        '
        Me.btnAc.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnAc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAc.Image = CType(resources.GetObject("btnAc.Image"), System.Drawing.Image)
        Me.btnAc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAc.Location = New System.Drawing.Point(134, 354)
        Me.btnAc.Name = "btnAc"
        Me.btnAc.Size = New System.Drawing.Size(32, 32)
        Me.btnAc.TabIndex = 90
        Me.btnAc.Tag = "84"
        '
        'btnRa
        '
        Me.btnRa.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnRa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRa.Image = CType(resources.GetObject("btnRa.Image"), System.Drawing.Image)
        Me.btnRa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRa.Location = New System.Drawing.Point(62, 260)
        Me.btnRa.Name = "btnRa"
        Me.btnRa.Size = New System.Drawing.Size(32, 32)
        Me.btnRa.TabIndex = 89
        Me.btnRa.Tag = "83"
        '
        'btnFr
        '
        Me.btnFr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnFr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFr.Image = CType(resources.GetObject("btnFr.Image"), System.Drawing.Image)
        Me.btnFr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFr.Location = New System.Drawing.Point(26, 260)
        Me.btnFr.Name = "btnFr"
        Me.btnFr.Size = New System.Drawing.Size(32, 32)
        Me.btnFr.TabIndex = 88
        Me.btnFr.Tag = "82"
        '
        'btnRn
        '
        Me.btnRn.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnRn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRn.Image = CType(resources.GetObject("btnRn.Image"), System.Drawing.Image)
        Me.btnRn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRn.Location = New System.Drawing.Point(638, 226)
        Me.btnRn.Name = "btnRn"
        Me.btnRn.Size = New System.Drawing.Size(32, 32)
        Me.btnRn.TabIndex = 87
        Me.btnRn.Tag = "107"
        '
        'btnAt
        '
        Me.btnAt.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnAt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAt.Image = CType(resources.GetObject("btnAt.Image"), System.Drawing.Image)
        Me.btnAt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAt.Location = New System.Drawing.Point(602, 226)
        Me.btnAt.Name = "btnAt"
        Me.btnAt.Size = New System.Drawing.Size(32, 32)
        Me.btnAt.TabIndex = 86
        Me.btnAt.Tag = "100"
        '
        'btnPo
        '
        Me.btnPo.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnPo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPo.Image = CType(resources.GetObject("btnPo.Image"), System.Drawing.Image)
        Me.btnPo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPo.Location = New System.Drawing.Point(566, 226)
        Me.btnPo.Name = "btnPo"
        Me.btnPo.Size = New System.Drawing.Size(32, 32)
        Me.btnPo.TabIndex = 85
        Me.btnPo.Tag = "99"
        '
        'btnBi
        '
        Me.btnBi.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnBi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBi.Image = CType(resources.GetObject("btnBi.Image"), System.Drawing.Image)
        Me.btnBi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBi.Location = New System.Drawing.Point(530, 226)
        Me.btnBi.Name = "btnBi"
        Me.btnBi.Size = New System.Drawing.Size(32, 32)
        Me.btnBi.TabIndex = 84
        Me.btnBi.Tag = "8"
        '
        'btnPb
        '
        Me.btnPb.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnPb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPb.Image = CType(resources.GetObject("btnPb.Image"), System.Drawing.Image)
        Me.btnPb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPb.Location = New System.Drawing.Point(494, 226)
        Me.btnPb.Name = "btnPb"
        Me.btnPb.Size = New System.Drawing.Size(32, 32)
        Me.btnPb.TabIndex = 83
        Me.btnPb.Tag = "39"
        '
        'btnTl
        '
        Me.btnTl.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnTl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTl.Image = CType(resources.GetObject("btnTl.Image"), System.Drawing.Image)
        Me.btnTl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTl.Location = New System.Drawing.Point(458, 226)
        Me.btnTl.Name = "btnTl"
        Me.btnTl.Size = New System.Drawing.Size(32, 32)
        Me.btnTl.TabIndex = 82
        Me.btnTl.Tag = "58"
        '
        'btnHg
        '
        Me.btnHg.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnHg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHg.Image = CType(resources.GetObject("btnHg.Image"), System.Drawing.Image)
        Me.btnHg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHg.Location = New System.Drawing.Point(422, 226)
        Me.btnHg.Name = "btnHg"
        Me.btnHg.Size = New System.Drawing.Size(32, 32)
        Me.btnHg.TabIndex = 81
        Me.btnHg.Tag = "23"
        '
        'btnAu
        '
        Me.btnAu.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnAu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAu.Image = CType(resources.GetObject("btnAu.Image"), System.Drawing.Image)
        Me.btnAu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAu.Location = New System.Drawing.Point(386, 226)
        Me.btnAu.Name = "btnAu"
        Me.btnAu.Size = New System.Drawing.Size(32, 32)
        Me.btnAu.TabIndex = 80
        Me.btnAu.Tag = "4"
        '
        'btnPt
        '
        Me.btnPt.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnPt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPt.Image = CType(resources.GetObject("btnPt.Image"), System.Drawing.Image)
        Me.btnPt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPt.Location = New System.Drawing.Point(350, 226)
        Me.btnPt.Name = "btnPt"
        Me.btnPt.Size = New System.Drawing.Size(32, 32)
        Me.btnPt.TabIndex = 79
        Me.btnPt.Tag = "42"
        '
        'btnIr
        '
        Me.btnIr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnIr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIr.Image = CType(resources.GetObject("btnIr.Image"), System.Drawing.Image)
        Me.btnIr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIr.Location = New System.Drawing.Point(314, 226)
        Me.btnIr.Name = "btnIr"
        Me.btnIr.Size = New System.Drawing.Size(32, 32)
        Me.btnIr.TabIndex = 78
        Me.btnIr.Tag = "26"
        '
        'btnOs
        '
        Me.btnOs.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnOs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOs.Image = CType(resources.GetObject("btnOs.Image"), System.Drawing.Image)
        Me.btnOs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOs.Location = New System.Drawing.Point(278, 226)
        Me.btnOs.Name = "btnOs"
        Me.btnOs.Size = New System.Drawing.Size(32, 32)
        Me.btnOs.TabIndex = 77
        Me.btnOs.Tag = "38"
        '
        'btnRe
        '
        Me.btnRe.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnRe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRe.Image = CType(resources.GetObject("btnRe.Image"), System.Drawing.Image)
        Me.btnRe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRe.Location = New System.Drawing.Point(242, 226)
        Me.btnRe.Name = "btnRe"
        Me.btnRe.Size = New System.Drawing.Size(32, 32)
        Me.btnRe.TabIndex = 76
        Me.btnRe.Tag = "44"
        '
        'btnW
        '
        Me.btnW.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnW.Image = CType(resources.GetObject("btnW.Image"), System.Drawing.Image)
        Me.btnW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnW.Location = New System.Drawing.Point(206, 226)
        Me.btnW.Name = "btnW"
        Me.btnW.Size = New System.Drawing.Size(32, 32)
        Me.btnW.TabIndex = 75
        Me.btnW.Tag = "62"
        '
        'btnTa
        '
        Me.btnTa.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnTa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTa.Image = CType(resources.GetObject("btnTa.Image"), System.Drawing.Image)
        Me.btnTa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTa.Location = New System.Drawing.Point(170, 226)
        Me.btnTa.Name = "btnTa"
        Me.btnTa.Size = New System.Drawing.Size(32, 32)
        Me.btnTa.TabIndex = 74
        Me.btnTa.Tag = "54"
        '
        'btnHf
        '
        Me.btnHf.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnHf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHf.Image = CType(resources.GetObject("btnHf.Image"), System.Drawing.Image)
        Me.btnHf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHf.Location = New System.Drawing.Point(134, 226)
        Me.btnHf.Name = "btnHf"
        Me.btnHf.Size = New System.Drawing.Size(32, 32)
        Me.btnHf.TabIndex = 73
        Me.btnHf.Tag = "22"
        '
        'btnLu
        '
        Me.btnLu.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnLu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLu.Image = CType(resources.GetObject("btnLu.Image"), System.Drawing.Image)
        Me.btnLu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLu.Location = New System.Drawing.Point(638, 314)
        Me.btnLu.Name = "btnLu"
        Me.btnLu.Size = New System.Drawing.Size(32, 32)
        Me.btnLu.TabIndex = 72
        Me.btnLu.Tag = "30"
        '
        'btnYb
        '
        Me.btnYb.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnYb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYb.Image = CType(resources.GetObject("btnYb.Image"), System.Drawing.Image)
        Me.btnYb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnYb.Location = New System.Drawing.Point(602, 314)
        Me.btnYb.Name = "btnYb"
        Me.btnYb.Size = New System.Drawing.Size(32, 32)
        Me.btnYb.TabIndex = 71
        Me.btnYb.Tag = "64"
        '
        'btnTm
        '
        Me.btnTm.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnTm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTm.Image = CType(resources.GetObject("btnTm.Image"), System.Drawing.Image)
        Me.btnTm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTm.Location = New System.Drawing.Point(566, 314)
        Me.btnTm.Name = "btnTm"
        Me.btnTm.Size = New System.Drawing.Size(32, 32)
        Me.btnTm.TabIndex = 70
        Me.btnTm.Tag = "59"
        '
        'btnEr
        '
        Me.btnEr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnEr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEr.Image = CType(resources.GetObject("btnEr.Image"), System.Drawing.Image)
        Me.btnEr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEr.Location = New System.Drawing.Point(530, 314)
        Me.btnEr.Name = "btnEr"
        Me.btnEr.Size = New System.Drawing.Size(32, 32)
        Me.btnEr.TabIndex = 69
        Me.btnEr.Tag = "16"
        '
        'btnHo
        '
        Me.btnHo.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnHo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHo.Image = CType(resources.GetObject("btnHo.Image"), System.Drawing.Image)
        Me.btnHo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHo.Location = New System.Drawing.Point(494, 314)
        Me.btnHo.Name = "btnHo"
        Me.btnHo.Size = New System.Drawing.Size(32, 32)
        Me.btnHo.TabIndex = 68
        Me.btnHo.Tag = "24"
        '
        'btnDy
        '
        Me.btnDy.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnDy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDy.Image = CType(resources.GetObject("btnDy.Image"), System.Drawing.Image)
        Me.btnDy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDy.Location = New System.Drawing.Point(458, 314)
        Me.btnDy.Name = "btnDy"
        Me.btnDy.Size = New System.Drawing.Size(32, 32)
        Me.btnDy.TabIndex = 67
        Me.btnDy.Tag = "15"
        '
        'btnTb
        '
        Me.btnTb.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnTb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTb.Image = CType(resources.GetObject("btnTb.Image"), System.Drawing.Image)
        Me.btnTb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTb.Location = New System.Drawing.Point(422, 314)
        Me.btnTb.Name = "btnTb"
        Me.btnTb.Size = New System.Drawing.Size(32, 32)
        Me.btnTb.TabIndex = 66
        Me.btnTb.Tag = "55"
        '
        'btnGd
        '
        Me.btnGd.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnGd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGd.Image = CType(resources.GetObject("btnGd.Image"), System.Drawing.Image)
        Me.btnGd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGd.Location = New System.Drawing.Point(386, 314)
        Me.btnGd.Name = "btnGd"
        Me.btnGd.Size = New System.Drawing.Size(32, 32)
        Me.btnGd.TabIndex = 65
        Me.btnGd.Tag = "20"
        '
        'btnEu
        '
        Me.btnEu.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnEu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEu.Image = CType(resources.GetObject("btnEu.Image"), System.Drawing.Image)
        Me.btnEu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEu.Location = New System.Drawing.Point(350, 314)
        Me.btnEu.Name = "btnEu"
        Me.btnEu.Size = New System.Drawing.Size(32, 32)
        Me.btnEu.TabIndex = 64
        Me.btnEu.Tag = "17"
        '
        'btnSm
        '
        Me.btnSm.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnSm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSm.Image = CType(resources.GetObject("btnSm.Image"), System.Drawing.Image)
        Me.btnSm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSm.Location = New System.Drawing.Point(314, 314)
        Me.btnSm.Name = "btnSm"
        Me.btnSm.Size = New System.Drawing.Size(32, 32)
        Me.btnSm.TabIndex = 63
        Me.btnSm.Tag = "51"
        '
        'btnPm
        '
        Me.btnPm.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnPm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPm.Image = CType(resources.GetObject("btnPm.Image"), System.Drawing.Image)
        Me.btnPm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPm.Location = New System.Drawing.Point(278, 314)
        Me.btnPm.Name = "btnPm"
        Me.btnPm.Size = New System.Drawing.Size(32, 32)
        Me.btnPm.TabIndex = 62
        Me.btnPm.Tag = "105"
        '
        'btnNd
        '
        Me.btnNd.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnNd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNd.Image = CType(resources.GetObject("btnNd.Image"), System.Drawing.Image)
        Me.btnNd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNd.Location = New System.Drawing.Point(242, 314)
        Me.btnNd.Name = "btnNd"
        Me.btnNd.Size = New System.Drawing.Size(32, 32)
        Me.btnNd.TabIndex = 61
        Me.btnNd.Tag = "36"
        '
        'btnPr
        '
        Me.btnPr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnPr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPr.Image = CType(resources.GetObject("btnPr.Image"), System.Drawing.Image)
        Me.btnPr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPr.Location = New System.Drawing.Point(206, 314)
        Me.btnPr.Name = "btnPr"
        Me.btnPr.Size = New System.Drawing.Size(32, 32)
        Me.btnPr.TabIndex = 60
        Me.btnPr.Tag = "41"
        '
        'btnCe
        '
        Me.btnCe.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnCe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCe.Image = CType(resources.GetObject("btnCe.Image"), System.Drawing.Image)
        Me.btnCe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCe.Location = New System.Drawing.Point(170, 314)
        Me.btnCe.Name = "btnCe"
        Me.btnCe.Size = New System.Drawing.Size(32, 32)
        Me.btnCe.TabIndex = 59
        Me.btnCe.Tag = "85"
        '
        'btnLa
        '
        Me.btnLa.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnLa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLa.Image = CType(resources.GetObject("btnLa.Image"), System.Drawing.Image)
        Me.btnLa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLa.Location = New System.Drawing.Point(134, 314)
        Me.btnLa.Name = "btnLa"
        Me.btnLa.Size = New System.Drawing.Size(32, 32)
        Me.btnLa.TabIndex = 58
        Me.btnLa.Tag = "28"
        '
        'btnBa
        '
        Me.btnBa.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnBa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBa.Image = CType(resources.GetObject("btnBa.Image"), System.Drawing.Image)
        Me.btnBa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBa.Location = New System.Drawing.Point(62, 226)
        Me.btnBa.Name = "btnBa"
        Me.btnBa.Size = New System.Drawing.Size(32, 32)
        Me.btnBa.TabIndex = 57
        Me.btnBa.Tag = "6"
        '
        'btnCs
        '
        Me.btnCs.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnCs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCs.Image = CType(resources.GetObject("btnCs.Image"), System.Drawing.Image)
        Me.btnCs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCs.Location = New System.Drawing.Point(26, 226)
        Me.btnCs.Name = "btnCs"
        Me.btnCs.Size = New System.Drawing.Size(32, 32)
        Me.btnCs.TabIndex = 56
        Me.btnCs.Tag = "13"
        '
        'btnXe
        '
        Me.btnXe.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnXe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXe.Image = CType(resources.GetObject("btnXe.Image"), System.Drawing.Image)
        Me.btnXe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnXe.Location = New System.Drawing.Point(638, 192)
        Me.btnXe.Name = "btnXe"
        Me.btnXe.Size = New System.Drawing.Size(32, 32)
        Me.btnXe.TabIndex = 55
        Me.btnXe.Tag = "81"
        '
        'btnI
        '
        Me.btnI.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnI.Image = CType(resources.GetObject("btnI.Image"), System.Drawing.Image)
        Me.btnI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnI.Location = New System.Drawing.Point(602, 192)
        Me.btnI.Name = "btnI"
        Me.btnI.Size = New System.Drawing.Size(32, 32)
        Me.btnI.TabIndex = 54
        Me.btnI.Tag = "102"
        '
        'btnTe
        '
        Me.btnTe.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnTe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTe.Image = CType(resources.GetObject("btnTe.Image"), System.Drawing.Image)
        Me.btnTe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTe.Location = New System.Drawing.Point(566, 192)
        Me.btnTe.Name = "btnTe"
        Me.btnTe.Size = New System.Drawing.Size(32, 32)
        Me.btnTe.TabIndex = 53
        Me.btnTe.Tag = "56"
        '
        'btnSb
        '
        Me.btnSb.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnSb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSb.Image = CType(resources.GetObject("btnSb.Image"), System.Drawing.Image)
        Me.btnSb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSb.Location = New System.Drawing.Point(530, 192)
        Me.btnSb.Name = "btnSb"
        Me.btnSb.Size = New System.Drawing.Size(32, 32)
        Me.btnSb.TabIndex = 52
        Me.btnSb.Tag = "47"
        '
        'btnSn
        '
        Me.btnSn.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnSn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSn.Image = CType(resources.GetObject("btnSn.Image"), System.Drawing.Image)
        Me.btnSn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSn.Location = New System.Drawing.Point(494, 192)
        Me.btnSn.Name = "btnSn"
        Me.btnSn.Size = New System.Drawing.Size(32, 32)
        Me.btnSn.TabIndex = 51
        Me.btnSn.Tag = "52"
        '
        'btnIn
        '
        Me.btnIn.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIn.Image = CType(resources.GetObject("btnIn.Image"), System.Drawing.Image)
        Me.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIn.Location = New System.Drawing.Point(458, 192)
        Me.btnIn.Name = "btnIn"
        Me.btnIn.Size = New System.Drawing.Size(32, 32)
        Me.btnIn.TabIndex = 50
        Me.btnIn.Tag = "25"
        '
        'btnCd
        '
        Me.btnCd.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnCd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCd.Image = CType(resources.GetObject("btnCd.Image"), System.Drawing.Image)
        Me.btnCd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCd.Location = New System.Drawing.Point(422, 192)
        Me.btnCd.Name = "btnCd"
        Me.btnCd.Size = New System.Drawing.Size(32, 32)
        Me.btnCd.TabIndex = 49
        Me.btnCd.Tag = "10"
        '
        'btnAg
        '
        Me.btnAg.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnAg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAg.Image = CType(resources.GetObject("btnAg.Image"), System.Drawing.Image)
        Me.btnAg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAg.Location = New System.Drawing.Point(386, 192)
        Me.btnAg.Name = "btnAg"
        Me.btnAg.Size = New System.Drawing.Size(32, 32)
        Me.btnAg.TabIndex = 48
        Me.btnAg.Tag = "1"
        '
        'btnPd
        '
        Me.btnPd.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnPd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPd.Image = CType(resources.GetObject("btnPd.Image"), System.Drawing.Image)
        Me.btnPd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPd.Location = New System.Drawing.Point(350, 192)
        Me.btnPd.Name = "btnPd"
        Me.btnPd.Size = New System.Drawing.Size(32, 32)
        Me.btnPd.TabIndex = 47
        Me.btnPd.Tag = "40"
        '
        'btnRh
        '
        Me.btnRh.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnRh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRh.Image = CType(resources.GetObject("btnRh.Image"), System.Drawing.Image)
        Me.btnRh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRh.Location = New System.Drawing.Point(314, 192)
        Me.btnRh.Name = "btnRh"
        Me.btnRh.Size = New System.Drawing.Size(32, 32)
        Me.btnRh.TabIndex = 46
        Me.btnRh.Tag = "45"
        '
        'btnRu
        '
        Me.btnRu.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnRu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRu.Image = CType(resources.GetObject("btnRu.Image"), System.Drawing.Image)
        Me.btnRu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRu.Location = New System.Drawing.Point(278, 192)
        Me.btnRu.Name = "btnRu"
        Me.btnRu.Size = New System.Drawing.Size(32, 32)
        Me.btnRu.TabIndex = 45
        Me.btnRu.Tag = "46"
        '
        'btnTc
        '
        Me.btnTc.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnTc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTc.Image = CType(resources.GetObject("btnTc.Image"), System.Drawing.Image)
        Me.btnTc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTc.Location = New System.Drawing.Point(242, 192)
        Me.btnTc.Name = "btnTc"
        Me.btnTc.Size = New System.Drawing.Size(32, 32)
        Me.btnTc.TabIndex = 44
        Me.btnTc.Tag = "109"
        '
        'btnMo
        '
        Me.btnMo.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnMo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMo.Image = CType(resources.GetObject("btnMo.Image"), System.Drawing.Image)
        Me.btnMo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMo.Location = New System.Drawing.Point(206, 192)
        Me.btnMo.Name = "btnMo"
        Me.btnMo.Size = New System.Drawing.Size(32, 32)
        Me.btnMo.TabIndex = 43
        Me.btnMo.Tag = "33"
        '
        'btnNb
        '
        Me.btnNb.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnNb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNb.Image = CType(resources.GetObject("btnNb.Image"), System.Drawing.Image)
        Me.btnNb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNb.Location = New System.Drawing.Point(170, 192)
        Me.btnNb.Name = "btnNb"
        Me.btnNb.Size = New System.Drawing.Size(32, 32)
        Me.btnNb.TabIndex = 42
        Me.btnNb.Tag = "35"
        '
        'btnZr
        '
        Me.btnZr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnZr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZr.Image = CType(resources.GetObject("btnZr.Image"), System.Drawing.Image)
        Me.btnZr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnZr.Location = New System.Drawing.Point(134, 192)
        Me.btnZr.Name = "btnZr"
        Me.btnZr.Size = New System.Drawing.Size(32, 32)
        Me.btnZr.TabIndex = 41
        Me.btnZr.Tag = "66"
        '
        'btnY
        '
        Me.btnY.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnY.Image = CType(resources.GetObject("btnY.Image"), System.Drawing.Image)
        Me.btnY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnY.Location = New System.Drawing.Point(98, 192)
        Me.btnY.Name = "btnY"
        Me.btnY.Size = New System.Drawing.Size(32, 32)
        Me.btnY.TabIndex = 40
        Me.btnY.Tag = "63"
        '
        'btnSr
        '
        Me.btnSr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnSr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSr.Image = CType(resources.GetObject("btnSr.Image"), System.Drawing.Image)
        Me.btnSr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSr.Location = New System.Drawing.Point(62, 192)
        Me.btnSr.Name = "btnSr"
        Me.btnSr.Size = New System.Drawing.Size(32, 32)
        Me.btnSr.TabIndex = 39
        Me.btnSr.Tag = "53"
        '
        'btnRb
        '
        Me.btnRb.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnRb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRb.Image = CType(resources.GetObject("btnRb.Image"), System.Drawing.Image)
        Me.btnRb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRb.Location = New System.Drawing.Point(26, 192)
        Me.btnRb.Name = "btnRb"
        Me.btnRb.Size = New System.Drawing.Size(32, 32)
        Me.btnRb.TabIndex = 38
        Me.btnRb.Tag = "43"
        '
        'btnKr
        '
        Me.btnKr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnKr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKr.Image = CType(resources.GetObject("btnKr.Image"), System.Drawing.Image)
        Me.btnKr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKr.Location = New System.Drawing.Point(638, 158)
        Me.btnKr.Name = "btnKr"
        Me.btnKr.Size = New System.Drawing.Size(32, 32)
        Me.btnKr.TabIndex = 37
        Me.btnKr.Tag = "80"
        '
        'btnBr
        '
        Me.btnBr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnBr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBr.Image = CType(resources.GetObject("btnBr.Image"), System.Drawing.Image)
        Me.btnBr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBr.Location = New System.Drawing.Point(602, 158)
        Me.btnBr.Name = "btnBr"
        Me.btnBr.Size = New System.Drawing.Size(32, 32)
        Me.btnBr.TabIndex = 36
        Me.btnBr.Tag = "101"
        '
        'btnSe
        '
        Me.btnSe.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnSe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSe.Image = CType(resources.GetObject("btnSe.Image"), System.Drawing.Image)
        Me.btnSe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSe.Location = New System.Drawing.Point(566, 158)
        Me.btnSe.Name = "btnSe"
        Me.btnSe.Size = New System.Drawing.Size(32, 32)
        Me.btnSe.TabIndex = 35
        Me.btnSe.Tag = "49"
        '
        'btnAs
        '
        Me.btnAs.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAs.Image = CType(resources.GetObject("btnAs.Image"), System.Drawing.Image)
        Me.btnAs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAs.Location = New System.Drawing.Point(530, 158)
        Me.btnAs.Name = "btnAs"
        Me.btnAs.Size = New System.Drawing.Size(32, 32)
        Me.btnAs.TabIndex = 34
        Me.btnAs.Tag = "3"
        '
        'btnGe
        '
        Me.btnGe.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnGe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGe.Image = CType(resources.GetObject("btnGe.Image"), System.Drawing.Image)
        Me.btnGe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGe.Location = New System.Drawing.Point(494, 158)
        Me.btnGe.Name = "btnGe"
        Me.btnGe.Size = New System.Drawing.Size(32, 32)
        Me.btnGe.TabIndex = 33
        Me.btnGe.Tag = "21"
        '
        'btnGa
        '
        Me.btnGa.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnGa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGa.Image = CType(resources.GetObject("btnGa.Image"), System.Drawing.Image)
        Me.btnGa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGa.Location = New System.Drawing.Point(458, 158)
        Me.btnGa.Name = "btnGa"
        Me.btnGa.Size = New System.Drawing.Size(32, 32)
        Me.btnGa.TabIndex = 32
        Me.btnGa.Tag = "19"
        '
        'btnZn
        '
        Me.btnZn.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnZn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZn.Image = CType(resources.GetObject("btnZn.Image"), System.Drawing.Image)
        Me.btnZn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnZn.Location = New System.Drawing.Point(422, 158)
        Me.btnZn.Name = "btnZn"
        Me.btnZn.Size = New System.Drawing.Size(32, 32)
        Me.btnZn.TabIndex = 31
        Me.btnZn.Tag = "65"
        '
        'btnCu
        '
        Me.btnCu.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnCu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCu.Image = CType(resources.GetObject("btnCu.Image"), System.Drawing.Image)
        Me.btnCu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCu.Location = New System.Drawing.Point(386, 158)
        Me.btnCu.Name = "btnCu"
        Me.btnCu.Size = New System.Drawing.Size(32, 32)
        Me.btnCu.TabIndex = 30
        Me.btnCu.Tag = "14"
        '
        'btnNi
        '
        Me.btnNi.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnNi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNi.Image = CType(resources.GetObject("btnNi.Image"), System.Drawing.Image)
        Me.btnNi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNi.Location = New System.Drawing.Point(350, 158)
        Me.btnNi.Name = "btnNi"
        Me.btnNi.Size = New System.Drawing.Size(32, 32)
        Me.btnNi.TabIndex = 29
        Me.btnNi.Tag = "37"
        '
        'btnCo
        '
        Me.btnCo.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCo.Image = CType(resources.GetObject("btnCo.Image"), System.Drawing.Image)
        Me.btnCo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCo.Location = New System.Drawing.Point(314, 158)
        Me.btnCo.Name = "btnCo"
        Me.btnCo.Size = New System.Drawing.Size(32, 32)
        Me.btnCo.TabIndex = 28
        Me.btnCo.Tag = "11"
        '
        'btnFe
        '
        Me.btnFe.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnFe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFe.Image = CType(resources.GetObject("btnFe.Image"), System.Drawing.Image)
        Me.btnFe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFe.Location = New System.Drawing.Point(278, 158)
        Me.btnFe.Name = "btnFe"
        Me.btnFe.Size = New System.Drawing.Size(32, 32)
        Me.btnFe.TabIndex = 27
        Me.btnFe.Tag = "18"
        '
        'btnMn
        '
        Me.btnMn.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnMn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMn.Image = CType(resources.GetObject("btnMn.Image"), System.Drawing.Image)
        Me.btnMn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMn.Location = New System.Drawing.Point(242, 158)
        Me.btnMn.Name = "btnMn"
        Me.btnMn.Size = New System.Drawing.Size(32, 32)
        Me.btnMn.TabIndex = 26
        Me.btnMn.Tag = "32"
        '
        'btnCr
        '
        Me.btnCr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnCr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCr.Image = CType(resources.GetObject("btnCr.Image"), System.Drawing.Image)
        Me.btnCr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCr.Location = New System.Drawing.Point(206, 158)
        Me.btnCr.Name = "btnCr"
        Me.btnCr.Size = New System.Drawing.Size(32, 32)
        Me.btnCr.TabIndex = 25
        Me.btnCr.Tag = "12"
        '
        'btnV
        '
        Me.btnV.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnV.Image = CType(resources.GetObject("btnV.Image"), System.Drawing.Image)
        Me.btnV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnV.Location = New System.Drawing.Point(170, 158)
        Me.btnV.Name = "btnV"
        Me.btnV.Size = New System.Drawing.Size(32, 32)
        Me.btnV.TabIndex = 24
        Me.btnV.Tag = "61"
        '
        'btnTi
        '
        Me.btnTi.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnTi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTi.Image = CType(resources.GetObject("btnTi.Image"), System.Drawing.Image)
        Me.btnTi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTi.Location = New System.Drawing.Point(134, 158)
        Me.btnTi.Name = "btnTi"
        Me.btnTi.Size = New System.Drawing.Size(32, 32)
        Me.btnTi.TabIndex = 23
        Me.btnTi.Tag = "57"
        '
        'btnSc
        '
        Me.btnSc.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnSc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSc.Image = CType(resources.GetObject("btnSc.Image"), System.Drawing.Image)
        Me.btnSc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSc.Location = New System.Drawing.Point(98, 158)
        Me.btnSc.Name = "btnSc"
        Me.btnSc.Size = New System.Drawing.Size(32, 32)
        Me.btnSc.TabIndex = 22
        Me.btnSc.Tag = "48"
        '
        'btnCa
        '
        Me.btnCa.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCa.Image = CType(resources.GetObject("btnCa.Image"), System.Drawing.Image)
        Me.btnCa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCa.Location = New System.Drawing.Point(62, 158)
        Me.btnCa.Name = "btnCa"
        Me.btnCa.Size = New System.Drawing.Size(32, 32)
        Me.btnCa.TabIndex = 21
        Me.btnCa.Tag = "9"
        '
        'btnK
        '
        Me.btnK.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnK.Image = CType(resources.GetObject("btnK.Image"), System.Drawing.Image)
        Me.btnK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnK.Location = New System.Drawing.Point(26, 158)
        Me.btnK.Name = "btnK"
        Me.btnK.Size = New System.Drawing.Size(32, 32)
        Me.btnK.TabIndex = 20
        Me.btnK.Tag = "27"
        '
        'btnAr
        '
        Me.btnAr.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnAr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAr.Image = CType(resources.GetObject("btnAr.Image"), System.Drawing.Image)
        Me.btnAr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAr.Location = New System.Drawing.Point(638, 124)
        Me.btnAr.Name = "btnAr"
        Me.btnAr.Size = New System.Drawing.Size(32, 32)
        Me.btnAr.TabIndex = 19
        Me.btnAr.Tag = "79"
        '
        'btnCl
        '
        Me.btnCl.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnCl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCl.Image = CType(resources.GetObject("btnCl.Image"), System.Drawing.Image)
        Me.btnCl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCl.Location = New System.Drawing.Point(602, 124)
        Me.btnCl.Name = "btnCl"
        Me.btnCl.Size = New System.Drawing.Size(32, 32)
        Me.btnCl.TabIndex = 18
        Me.btnCl.Tag = "78"
        '
        'btnS
        '
        Me.btnS.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnS.Image = CType(resources.GetObject("btnS.Image"), System.Drawing.Image)
        Me.btnS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnS.Location = New System.Drawing.Point(566, 124)
        Me.btnS.Name = "btnS"
        Me.btnS.Size = New System.Drawing.Size(32, 32)
        Me.btnS.TabIndex = 17
        Me.btnS.Tag = "108"
        '
        'btnP
        '
        Me.btnP.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnP.Image = CType(resources.GetObject("btnP.Image"), System.Drawing.Image)
        Me.btnP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnP.Location = New System.Drawing.Point(530, 124)
        Me.btnP.Name = "btnP"
        Me.btnP.Size = New System.Drawing.Size(32, 32)
        Me.btnP.TabIndex = 16
        Me.btnP.Tag = "104"
        '
        'btnSi
        '
        Me.btnSi.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSi.Image = CType(resources.GetObject("btnSi.Image"), System.Drawing.Image)
        Me.btnSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSi.Location = New System.Drawing.Point(494, 124)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(32, 32)
        Me.btnSi.TabIndex = 15
        Me.btnSi.Tag = "50"
        '
        'btnAl
        '
        Me.btnAl.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAl.Image = CType(resources.GetObject("btnAl.Image"), System.Drawing.Image)
        Me.btnAl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAl.Location = New System.Drawing.Point(458, 124)
        Me.btnAl.Name = "btnAl"
        Me.btnAl.Size = New System.Drawing.Size(32, 32)
        Me.btnAl.TabIndex = 14
        Me.btnAl.Tag = "2"
        '
        'btnMg
        '
        Me.btnMg.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnMg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMg.Image = CType(resources.GetObject("btnMg.Image"), System.Drawing.Image)
        Me.btnMg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMg.Location = New System.Drawing.Point(62, 124)
        Me.btnMg.Name = "btnMg"
        Me.btnMg.Size = New System.Drawing.Size(32, 32)
        Me.btnMg.TabIndex = 13
        Me.btnMg.Tag = "31"
        '
        'btnNa
        '
        Me.btnNa.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnNa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNa.Image = CType(resources.GetObject("btnNa.Image"), System.Drawing.Image)
        Me.btnNa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNa.Location = New System.Drawing.Point(26, 124)
        Me.btnNa.Name = "btnNa"
        Me.btnNa.Size = New System.Drawing.Size(32, 32)
        Me.btnNa.TabIndex = 12
        Me.btnNa.Tag = "34"
        '
        'btnNe
        '
        Me.btnNe.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnNe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNe.Image = CType(resources.GetObject("btnNe.Image"), System.Drawing.Image)
        Me.btnNe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNe.Location = New System.Drawing.Point(638, 90)
        Me.btnNe.Name = "btnNe"
        Me.btnNe.Size = New System.Drawing.Size(32, 32)
        Me.btnNe.TabIndex = 11
        Me.btnNe.Tag = "77"
        '
        'btnF
        '
        Me.btnF.BackColor = System.Drawing.Color.Gold
        Me.btnF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnF.Image = CType(resources.GetObject("btnF.Image"), System.Drawing.Image)
        Me.btnF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF.Location = New System.Drawing.Point(602, 90)
        Me.btnF.Name = "btnF"
        Me.btnF.Size = New System.Drawing.Size(32, 32)
        Me.btnF.TabIndex = 10
        Me.btnF.Tag = "76"
        '
        'btnO
        '
        Me.btnO.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnO.Image = CType(resources.GetObject("btnO.Image"), System.Drawing.Image)
        Me.btnO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnO.Location = New System.Drawing.Point(566, 90)
        Me.btnO.Name = "btnO"
        Me.btnO.Size = New System.Drawing.Size(32, 32)
        Me.btnO.TabIndex = 9
        Me.btnO.Tag = "75"
        '
        'btnN
        '
        Me.btnN.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN.Image = CType(resources.GetObject("btnN.Image"), System.Drawing.Image)
        Me.btnN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnN.Location = New System.Drawing.Point(530, 90)
        Me.btnN.Name = "btnN"
        Me.btnN.Size = New System.Drawing.Size(32, 32)
        Me.btnN.TabIndex = 8
        Me.btnN.Tag = "74"
        '
        'btnC
        '
        Me.btnC.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnC.Image = CType(resources.GetObject("btnC.Image"), System.Drawing.Image)
        Me.btnC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnC.Location = New System.Drawing.Point(494, 90)
        Me.btnC.Name = "btnC"
        Me.btnC.Size = New System.Drawing.Size(32, 32)
        Me.btnC.TabIndex = 7
        Me.btnC.Tag = "73"
        '
        'btnB
        '
        Me.btnB.BackColor = System.Drawing.Color.AliceBlue
        Me.btnB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnB.Image = CType(resources.GetObject("btnB.Image"), System.Drawing.Image)
        Me.btnB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnB.Location = New System.Drawing.Point(458, 90)
        Me.btnB.Name = "btnB"
        Me.btnB.Size = New System.Drawing.Size(32, 32)
        Me.btnB.TabIndex = 5
        Me.btnB.Tag = "5"
        '
        'btnBe
        '
        Me.btnBe.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnBe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBe.Image = CType(resources.GetObject("btnBe.Image"), System.Drawing.Image)
        Me.btnBe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBe.Location = New System.Drawing.Point(62, 90)
        Me.btnBe.Name = "btnBe"
        Me.btnBe.Size = New System.Drawing.Size(32, 32)
        Me.btnBe.TabIndex = 4
        Me.btnBe.Tag = "7"
        '
        'btnLi
        '
        Me.btnLi.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnLi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLi.Image = CType(resources.GetObject("btnLi.Image"), System.Drawing.Image)
        Me.btnLi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLi.Location = New System.Drawing.Point(26, 90)
        Me.btnLi.Name = "btnLi"
        Me.btnLi.Size = New System.Drawing.Size(32, 32)
        Me.btnLi.TabIndex = 3
        Me.btnLi.Tag = "29"
        '
        'btnH
        '
        Me.btnH.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnH.Image = CType(resources.GetObject("btnH.Image"), System.Drawing.Image)
        Me.btnH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnH.Location = New System.Drawing.Point(638, 56)
        Me.btnH.Name = "btnH"
        Me.btnH.Size = New System.Drawing.Size(32, 32)
        Me.btnH.TabIndex = 2
        Me.btnH.Tag = "72"
        '
        'StatusBar1
        '
        Me.StatusBar1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar1.Location = New System.Drawing.Point(0, 471)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanelInfo})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(700, 20)
        Me.StatusBar1.TabIndex = 1
        '
        'StatusBarPanelInfo
        '
        Me.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.StatusBarPanelInfo.Width = 500
        '
        'frmCookBook
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(700, 491)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.CustomPanelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCookBook"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periodic Chart Of The Elements"
        Me.CustomPanelMain.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBoxMultielementLamps.ResumeLayout(False)
        CType(Me.StatusBarPanelInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private Variables"
    Private mintElementID As Integer = 0
    Private mblnAvoidProcessing As Boolean = False
#End Region

#Region "Properties"
    Public Property ElementID() As Integer
        ''this is used to set and get a element ID
        Get
            Return mintElementID
        End Get
        Set(ByVal Value As Integer)
            mintElementID = Value
        End Set
    End Property
#End Region

#Region "Form Events"

    Private Sub frmCookBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=====================================================================
        ' Procedure Name        : frmCookBook_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To Load cook-book 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim DtCookBook As DataTable
        Dim intCtrlCount As Integer
        Dim ToolTip1 As ToolTip
        Dim dtToolTipCookBook As DataTable
        Dim strToolTip As String
        Try
            If gstructSettings.AppMode = EnumAppMode.FullVersion_201 Then
                ''check for 201
                btnIgnite.Enabled = False
                btnExtinguish.Enabled = False
            End If

            btnCancel.BringToFront()
            '---get cook book data
            DtCookBook = gobjDataAccess.GetCookBookData()
            '---set element names to combobox.
            If Not DtCookBook Is Nothing Then
                cmbSelectElement.DataSource = DtCookBook
                cmbSelectElement.ValueMember = DtCookBook.Columns(ConstColumnElementID).ColumnName
                cmbSelectElement.DisplayMember = DtCookBook.Columns(ConstColumnElementName).ColumnName
                ''show the value from DtCookBook  object to screen 
            End If
            AddHandlers()
            ''for adding a event to a control

            '---add handlers for mouse hover to display tooltip
            For intCtrlCount = 0 To Me.CustomPanelMain.Controls.Count - 1
                If TypeOf Me.CustomPanelMain.Controls(intCtrlCount) Is NETXP.Controls.XPButton Then
                    If Me.CustomPanelMain.Controls(intCtrlCount).Tag <> Nothing Then
                        AddHandler Me.CustomPanelMain.Controls(intCtrlCount).MouseHover, AddressOf SubGetWavelength
                        AddHandler Me.CustomPanelMain.Controls(intCtrlCount).MouseLeave, AddressOf SubSetBlank
                    End If
                End If
            Next

            '---add tool tips for all elements
            For intCtrlCount = 0 To Me.CustomPanelMain.Controls.Count - 1
                If TypeOf Me.CustomPanelMain.Controls(intCtrlCount) Is NETXP.Controls.XPButton Then
                    If Me.CustomPanelMain.Controls(intCtrlCount).Tag <> Nothing Then
                        CType(Me.CustomPanelMain.Controls(intCtrlCount), NETXP.Controls.XPButton).ImageAlign = ContentAlignment.MiddleCenter
                        If CType(Me.CustomPanelMain.Controls(intCtrlCount), NETXP.Controls.XPButton).Tag > 0 And _
                        CType(Me.CustomPanelMain.Controls(intCtrlCount), NETXP.Controls.XPButton).Tag < 110 Then
                            ToolTip1 = New ToolTip
                            dtToolTipCookBook = gobjClsAAS203.funcGetElement_AtomicNo(CType(Me.CustomPanelMain.Controls(intCtrlCount), NETXP.Controls.XPButton).Tag)
                            If dtToolTipCookBook.Rows(0).Item(4) = 0 Then
                                strToolTip = "Element:" & dtToolTipCookBook.Rows(0).Item(2) & "(" & dtToolTipCookBook.Rows(0).Item(1) & ")" & " Atomic No.:" & dtToolTipCookBook.Rows(0).Item(3) & " Flame Type: AA Flame " '& dtToolTipCookBook.Rows(0).Item(3)
                            ElseIf dtToolTipCookBook.Rows(0).Item(4) = -1 Then
                                strToolTip = "Element:" & dtToolTipCookBook.Rows(0).Item(2) & "(" & dtToolTipCookBook.Rows(0).Item(1) & ")" & " Atomic No.:" & dtToolTipCookBook.Rows(0).Item(3) & " Flame Type: NA Flame " '& dtToolTipCookBook.Rows(0).Item(3)
                            Else
                                strToolTip = "Element:" & dtToolTipCookBook.Rows(0).Item(2) & "(" & dtToolTipCookBook.Rows(0).Item(1) & ")" & " Atomic No.:" & dtToolTipCookBook.Rows(0).Item(3) '& " Flame Type: NA Flame " '& dtToolTipCookBook.Rows(0).Item(3)
                            End If
                            ToolTip1.SetToolTip(Me.CustomPanelMain.Controls(intCtrlCount), strToolTip)
                        End If
                    End If
                End If
            Next
            btnBlank.ImageAlign = ContentAlignment.MiddleCenter
            ToolTip1.SetToolTip(btnBlank, "Element: Blank Atomic No.: 106")
            btnCuZn.ImageAlign = ContentAlignment.MiddleCenter
            ToolTip1.SetToolTip(btnCuZn, "Element: Cu-Zn Flame Type: AA Flame")
            btnCaMg.ImageAlign = ContentAlignment.MiddleCenter
            ToolTip1.SetToolTip(btnCaMg, "Element: Ca-Mg Flame Type: NA/AA Flame")
            btnNaK.ImageAlign = ContentAlignment.MiddleCenter
            ToolTip1.SetToolTip(btnNaK, "Element: Na-K Flame Type: AA Flame")
            btnCrCoCuFeMnNi.ImageAlign = ContentAlignment.MiddleCenter
            ToolTip1.SetToolTip(btnCrCoCuFeMnNi, "Element: Cr-Co-Cu-Fe-Mn-Mi Flame Type: AA Flame")
            '-------------------------------------------------------------


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

#Region "Private Functions"

    Private Sub AddHandlers()
        '=====================================================================
        ' Procedure Name        : AddHandlers
        ' Parameters Passed     : None
        ' Returns               : None
        ' Purpose               : To Add event handlers
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim intCtrlCount As Integer
        Try
            '---add handlers for all elements
            For intCtrlCount = 0 To Me.CustomPanelMain.Controls.Count - 1
                If TypeOf Me.CustomPanelMain.Controls(intCtrlCount) Is NETXP.Controls.XPButton Then
                    If Me.CustomPanelMain.Controls(intCtrlCount).Tag <> Nothing Then
                        AddHandler Me.CustomPanelMain.Controls(intCtrlCount).Click, AddressOf SubGetElement
                    End If
                End If
            Next
            For intCtrlCount = 0 To Me.GroupBoxMultielementLamps.Controls.Count - 1
                If TypeOf Me.GroupBoxMultielementLamps.Controls(intCtrlCount) Is NETXP.Controls.XPButton Then
                    If Me.GroupBoxMultielementLamps.Controls(intCtrlCount).Tag <> Nothing Then
                        AddHandler Me.GroupBoxMultielementLamps.Controls(intCtrlCount).Click, AddressOf SubGetElement
                    End If
                End If
            Next
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            AddHandler btnDelete.Click, AddressOf btnDelete_Click
            AddHandler btnR.Click, AddressOf btnR_Click
            ''this will add a handler to cancel button click.
            AddHandler cmbSelectElement.SelectedIndexChanged, AddressOf cmbSelectElement_SelectedIndexChanged
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnCancel_Click
        ' Parameters Passed     : sender,EventArgs
        ' Returns               : None
        ' Purpose               : To close the control
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            '---to close the form
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
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub SubSetBlank(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : SubSetBlank
        ' Parameters Passed     : sender,EventArgs
        ' Returns               : None
        ' Purpose               : set blank message for progress bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        'note:
        ''---to set blank message for progress bar
        Dim strBlank As String = ""
        ShowProgressBar(strBlank)
    End Sub

    Private Sub SubGetWavelength(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : SubGetWavelength
        ' Parameters Passed     : sender,EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : To display wavelengths on progress bar
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saurabh S
        ' Created               : 06.08.07
        ' Revisions             : 
        '=====================================================================
        Dim DtCookBook As DataTable
        Dim DtElementWavelengths As DataTable
        Dim objclsPrintDocument As clsPrintDocument
        Dim intCount As Integer
        Dim strWv As String = ""
        Dim strElement As String
        Try
            '---get element id
            ElementID = CInt(CType(sender, NETXP.Controls.XPButton).Tag)

            '--- get wavelengths of that element
            DtElementWavelengths = gobjDataAccess.GetElementWavelengths(ElementID)

            DtCookBook = gobjDataAccess.GetCookBookData(ElementID)
            strElement = DtCookBook.Rows(0).Item(1) & DtCookBook.Rows(0).Item(2) & " : (" & DtCookBook.Rows(0).Item(7) & ")"
            If Not IsNothing(DtElementWavelengths) Then
                For intCount = 0 To DtElementWavelengths.Rows.Count - 1
                    strWv = strWv & ", " & DtElementWavelengths.Rows(intCount).Item(2)
                Next
            Else
                strWv = " - Not used in Atomic Absorption"
            End If
            '---display it on progress bar
            ShowProgressBar(strElement & strWv)
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

    Private Sub SubGetElement(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : SubGetElement
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the selected element id to property
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim DtCookBook As DataTable
        Dim DtElementWavelengths As DataTable
        Dim objclsPrintDocument As clsPrintDocument
        Try
            ElementID = CInt(CType(sender, NETXP.Controls.XPButton).Tag)
            'get a element ID as per button tag on a cook book.
            If gblnCookBookReport = True Then
                '---for cook book report print
                If funcCookBookPrint() = True Then
                    '---for printing a cookbokk report.
                End If
                'Saurabh 28 May 2007
            ElseIf ElementID > 70 Then
                '' 18.04.11 for version 5.0
                If ElementID = 104 Then
                    Me.DialogResult = DialogResult.OK
                Else
                    Exit Sub
                End If
                '' 18.04.11


                ''element id cond
                ''Exit Sub  'commented on 18.04.11 for version 5.0
                'Saurabh 28 May 2007
            Else
                Me.DialogResult = DialogResult.OK
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

    Private Function funcCookBookPrint() As Boolean
        '=====================================================================
        ' Procedure Name        : funcCookBookPrint
        ' Parameters Passed     : None
        ' Returns               : BOOL True if success
        ' Purpose               : To print the report of selected Element characteristics
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================

        Dim objclsPrintDocument As New clsPrintDocument
        Dim objDtImagesList As New DataTable
        Dim arrGraphControlsList As New ArrayList
        Dim objstructReportFormatIn As New clsReportingMode.structReportFormat
        'Dim strPageHeader As String = ""    '" Test Page Header "
        Dim strPageHeader As New clsPrintDocument.struHeaderString  ' = ""    '" Test Page Header "
        Dim strPageText As String = " Test Page Text "
        Dim objarrMoreTabularData As New ArrayList
        Dim DtCookBook As DataTable
        Dim DtElementWavelengths As DataTable

        Try
            '--- Set print report object
            '--- "ElementID" holds the Element ID 
            strPageHeader.TextString = ""
            strPageHeader.TextFormat = New clsReportHeaderFormat
            strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleCenter
            '--- get the Element details info. from CookBook 
            DtCookBook = gobjDataAccess.GetCookBookData(ElementID)
            '---- Get the Element Wavelengths detals into data table
            DtElementWavelengths = gobjDataAccess.GetElementWavelengths(ElementID)
            If (IsNothing(DtElementWavelengths)) Then
                objclsPrintDocument = Nothing
                Return False
            End If
            '--- Set print report object parameters
            objstructReportFormatIn.PageBottomMargin = 0.5
            objstructReportFormatIn.PageLeftMargin = 0.5
            objstructReportFormatIn.PageTopMargin = 0.5
            '--- Set the report details (data tables, array list) to print report object
            objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, _
                       arrGraphControlsList, objarrMoreTabularData, _
                       objDtImagesList, DtCookBook, DtElementWavelengths, clsPrintDocument.enumReportType.CookBook)
            '---- Show report on print preview
            If Not IsNothing(objclsPrintDocument) = True Then
                If objclsPrintDocument.PrintPreview() = True Then
                    objclsPrintDocument.Dispose()
                    objclsPrintDocument = Nothing
                End If
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
            '---------------------------------------------------------
        End Try
    End Function

    Private Function funcSetPrintDocument(ByVal objstructReportFormatIn As clsReportingMode.structReportFormat, _
                      ByVal strPageHeaderIn As clsPrintDocument.struHeaderString, _
                      ByVal strPageTextIn As String, _
                      ByVal arrGraphControlsListIn As ArrayList, _
                      ByVal arrDtTablesListIn As ArrayList, _
                      ByVal objDtImagesListIn As DataTable, _
                      ByVal DtCookBook As DataTable, _
                      ByVal DtElementWavelengths As DataTable, _
                      ByVal intReportTypeIn As clsPrintDocument.enumReportType) As clsPrintDocument
        '=====================================================================
        ' Procedure Name        : funcSetPrintDocument
        ' Parameters Passed     : objstructReportFormatIn,strPageHeaderIn,strPageTextIn,
        '                         arrGraphControlsListIn,objDtImagesListIn,DtCookBook,DtElementWavelengths
        '                         intReportTypeIn as enumReportType
        ' Returns               : clsPrintDocument as print object
        ' Purpose               : To set the clsPrintDocument object
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Mangesh Shardul At Machine SOFT1
        ' Created               : Monday, January 31, 2005
        ' Revisions             : 1
        '=====================================================================
        Dim intCount As Integer
        Dim objDtTable2In As DataTable
        Dim objclsPrintDocument As New clsPrintDocument
        Dim FontStyles As System.Drawing.Font = Me.DefaultFont
        Dim objDtElements As DataTable
        Try

            'objstructReportFormatIn.IsDisplayCompanyLogo = gobjNewMethod.ReportParameters.IsLogo
            'objstructReportFormatIn.IsDisplayReportDate = gobjNewMethod.ReportParameters.IsDate
            'objstructReportFormatIn.IsDisplayReportFooter = gobjNewMethod.ReportParameters.IsReportFooter
            '
            'objstructReportFormatIn.IsDisplayReport = gobjNewMethod.ReportParameters.IsReportFooter
            '//----- commented by Sachin Dokhale as per Requirement
            'objstructReportFormatIn.IsDisplaySecondReportTitle = True
            'objstructReportFormatIn.IsDisplaySubsequentPageHeader = True

            objstructReportFormatIn.IsDisplayReportTitle = False
            objstructReportFormatIn.IsDisplayReportHeader = False
            objstructReportFormatIn.IsDisplayCompanyLogo = False
            objstructReportFormatIn.LogoAlignment = Left
            objstructReportFormatIn.LogoFileName = Application.StartupPath & "\" & "CHEMITO.BMP" '"D:\ALDYS\AAS 203 Borland Windows SW\win203.5\BMP\BMP\CHEMITO.BMP"

            ''objstructReportFormatIn.PageBottomMargin = gobjNewMethod.ReportParameters.BottomMargin   '0.5
            ''objstructReportFormatIn.PageLeftMargin = gobjNewMethod.ReportParameters.LeftMargin    '0.32
            ''objstructReportFormatIn.PageTopMargin = gobjNewMethod.ReportParameters.TopMargin     '1
            ''gobjNewMethod.ReportParameters.


            objclsPrintDocument.ReportFormat = objstructReportFormatIn
            objclsPrintDocument.PageHeader = strPageHeaderIn

            'objclsPrintDocument.PageHeader = gobjNewMethod.ReportParameters.ReportHeader
            ' = gobjNewMethod.ReportParameters.ReportFooter 

            objclsPrintDocument.PageText = strPageTextIn
            objclsPrintDocument.DisplayFont = Me.DefaultFont
            objclsPrintDocument.TableHeaderFont = FontStyles
            objclsPrintDocument.ReportImageList = objDtImagesListIn
            objclsPrintDocument.ReportType = intReportTypeIn
            objclsPrintDocument.ReportLayoutType = clsPrintDocument.enumReportLayoutType.Portrate
            objclsPrintDocument.PageSetting = gobjPageSetting
            objclsPrintDocument.SetTableColoumnFormat = False
            ''---Set Property ReportDataTables
            
            '---Set Property ReportGraphControls
            If IsNothing(arrGraphControlsListIn) = False Then
                objclsPrintDocument.ReportGraphControls = New ArrayList
                For intCount = 0 To arrGraphControlsListIn.Count - 1
                    If IsNothing(arrGraphControlsListIn.Item(intCount)) = False Then
                        objclsPrintDocument.ReportGraphControls.Add(arrGraphControlsListIn.Item(intCount))
                    End If
                Next intCount
            End If

            If Not DtCookBook Is Nothing Then
                objclsPrintDocument.ElamentInfo = New ArrayList
                objclsPrintDocument.ElamentInfo.Add(DtCookBook)
            End If

            '//----- Set Caption for Coloumn Header
            DtElementWavelengths.Columns.Item("WV").Caption = "Wavelength"
            DtElementWavelengths.Columns.Item("SLIT").Caption = "Spectral Bandpass"
            DtElementWavelengths.Columns.Item("WORK_RANGE").Caption = "Optimium Working Range"
            '//----- Remove index field from table
            DtElementWavelengths.Columns.Remove("ELE_ID")
            '//-----


            If Not DtElementWavelengths Is Nothing Then
                objclsPrintDocument.ElamentInfo.Add(DtElementWavelengths)

            End If

            '---Set Property ReportDataTables
            objclsPrintDocument.ReportDataTables = New ArrayList
            If Not DtElementWavelengths Is Nothing Then
                objDtElements = New DataTable
                Dim dtRow As DataRow
                Dim DtCol01 As New DataColumn("Col01", GetType(String))
                Dim DtCol02 As New DataColumn("Col02", GetType(String))
                Dim DtCol03 As New DataColumn("Col03", GetType(String))
                objDtElements.Columns.Add(DtCol01)
                objDtElements.Columns.Item(0).Caption = "Wavelength (nm)"

                objDtElements.Columns.Add(DtCol02)
                objDtElements.Columns.Item(1).Caption = "Spectral Bandpass(nm)"


                objDtElements.Columns.Add(DtCol03)
                objDtElements.Columns.Item(2).Caption = "Optimium Working Range(ppm)"
                Dim intRowCount As Integer
                intRowCount = 0

                Do While intRowCount < DtElementWavelengths.Rows.Count
                    dtRow = objDtElements.NewRow()

                    dtRow(0) = CStr(Format(DtElementWavelengths.Rows(intRowCount).Item(1), "#0.000"))  'CStr(gobjMethodCollection.item(mintSelectedMethodID).InstrumentConditions(0).ElementName)     '  ""
                    dtRow(1) = CStr(Format(DtElementWavelengths.Rows(intRowCount).Item(2), "#0.0"))
                    dtRow(2) = CStr(DtElementWavelengths.Rows(intRowCount).Item(3))
                    objDtElements.Rows.Add(dtRow)
                    intRowCount += 1
                Loop

                objclsPrintDocument.ReportDataTables.Add(objDtElements)

            End If


            Return objclsPrintDocument

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            Return Nothing
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not IsNothing(objclsPrintDocument) = True Then
                objclsPrintDocument.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        '=====================================================================
        ' Procedure Name        : btnSelect_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : as Handles btnSelect.Click
        ' Purpose               : To select the selected element 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Dim DtCookBook As DataTable
        Dim DtElementWavelengths As DataTable
        Dim objclsPrintDocument As clsPrintDocument
        Try

            If gblnCookBookReport = True Then
                '---for cook book report
                If funcCookBookPrint() = True Then
                End If
                'Saurabh 28 May 2007
            ElseIf ElementID > 70 Then
                Exit Sub
                'Saurabh 28 May 2007
            Else
                Me.DialogResult = DialogResult.OK
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

    Private Sub cmbSelectElement_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : cmbSelectElement_SelectedIndexChanged
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To set the selected element to property
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        '---to set selected element id to property
        ElementID = cmbSelectElement.SelectedValue
    End Sub

    Private Sub btnIgnite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIgnite.Click
        '=====================================================================
        ' Procedure Name        : btnIgnite_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To auto ignite the flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            If Not IsNothing(gobjMain) Then
                '---for alt-I auto ignition
                gobjMain.AutoIgnition()
            End If
            
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            mblnAvoidProcessing = False
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

    Private Sub btnExtinguish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExtinguish.Click
        '=====================================================================
        ' Procedure Name        : btnExtinguish_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To extinguish the flame
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            '---to extinguish the flame
            gobjMain.Extinguish()
            
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
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

    Private Sub btnN2OIgnite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnN2OIgnite.Click
        '=====================================================================
        ' Procedure Name        : btnN2OIgnite_Click
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To N2O auto ignition
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : 
        ' Created               : 05.10.06
        ' Revisions             : 
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call gobjMain.N2OAutoIgnition()
            '--- call a function for N2O ignition.
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnDelete_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call gobjMain.funcAltDelete()
            mblnAvoidProcessing = False
        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
            mblnAvoidProcessing = False
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '=====================================================================
        ' Procedure Name        : btnR_Click
        ' Parameters Passed     : Object, EventArgs
        ' Returns               : None
        ' Purpose               : 
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Sachin Dokhale
        ' Created               : 18-Dec-2007 03:15 pm
        ' Revisions             : 0
        '=====================================================================
        Try
            If mblnAvoidProcessing = True Then
                Exit Sub
            End If
            mblnAvoidProcessing = True
            Call gobjMain.funcAltR()
            mblnAvoidProcessing = False
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

    Public Sub ShowProgressBar(ByVal message As String)
        '=====================================================================
        ' Procedure Name        : ShowProgressBar
        ' Parameters Passed     : message
        ' Returns               : None
        ' Purpose               : to show the progress bar
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Deepak Bhati
        ' Created               : Saturday, January 22, 2005
        ' Revisions             : 
        '=====================================================================
        Try
            '--- show a status on progressbar

            'StatusBarPanelInfo.Text = message
            If gblnShowThreadOnfrmMDIStatusBar Then
                StatusBarPanelInfo.Text = StatusBarPanelInfo.Text & " " & message
            Else
                StatusBarPanelInfo.Text = message
                Application.DoEvents()
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

#End Region

End Class
