using AAS203.Common;
//'class behind the form
public class frmCookBook : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmCookBook()
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









	internal System.Windows.Forms.Label Label1;
	internal NETXP.Controls.Bars.StatusBar StatusBar1;
	internal NETXP.Controls.XPButton btnHa;
	internal NETXP.Controls.XPButton btnRf;
	internal NETXP.Controls.XPButton btnHe;
	internal NETXP.Controls.XPButton btnFm;
	internal NETXP.Controls.XPButton btnEs;
	internal NETXP.Controls.XPButton btnCf;
	internal NETXP.Controls.XPButton btnBk;
	internal NETXP.Controls.XPButton btnCm;
	internal NETXP.Controls.XPButton btnAm;
	internal NETXP.Controls.XPButton btnPu;
	internal NETXP.Controls.XPButton btnNp;
	internal NETXP.Controls.XPButton btnU;
	internal NETXP.Controls.XPButton btnPa;
	internal NETXP.Controls.XPButton btnTh;
	internal NETXP.Controls.XPButton btnAc;
	internal NETXP.Controls.XPButton btnRa;
	internal NETXP.Controls.XPButton btnFr;
	internal NETXP.Controls.XPButton btnBi;
	internal NETXP.Controls.XPButton btnPb;
	internal NETXP.Controls.XPButton btnTl;
	internal NETXP.Controls.XPButton btnHg;
	internal NETXP.Controls.XPButton btnAu;
	internal NETXP.Controls.XPButton btnPt;
	internal NETXP.Controls.XPButton btnIr;
	internal NETXP.Controls.XPButton btnOs;
	internal NETXP.Controls.XPButton btnRe;
	internal NETXP.Controls.XPButton btnW;
	internal NETXP.Controls.XPButton btnHf;
	internal NETXP.Controls.XPButton btnEr;
	internal NETXP.Controls.XPButton btnHo;
	internal NETXP.Controls.XPButton btnDy;
	internal NETXP.Controls.XPButton btnTb;
	internal NETXP.Controls.XPButton btnGd;
	internal NETXP.Controls.XPButton btnEu;
	internal NETXP.Controls.XPButton btnSm;
	internal NETXP.Controls.XPButton btnPm;
	internal NETXP.Controls.XPButton btnNd;
	internal NETXP.Controls.XPButton btnPr;
	internal NETXP.Controls.XPButton btnCe;
	internal NETXP.Controls.XPButton btnLa;
	internal NETXP.Controls.XPButton btnBa;
	internal NETXP.Controls.XPButton btnCs;
	internal NETXP.Controls.XPButton btnSb;
	internal NETXP.Controls.XPButton btnSn;
	internal NETXP.Controls.XPButton btnIn;
	internal NETXP.Controls.XPButton btnCd;
	internal NETXP.Controls.XPButton btnAg;
	internal NETXP.Controls.XPButton btnPd;
	internal NETXP.Controls.XPButton btnRh;
	internal NETXP.Controls.XPButton btnRu;
	internal NETXP.Controls.XPButton btnTc;
	internal NETXP.Controls.XPButton btnMo;
	internal NETXP.Controls.XPButton btnZr;
	internal NETXP.Controls.XPButton btnY;
	internal NETXP.Controls.XPButton btnSr;
	internal NETXP.Controls.XPButton btnRb;
	internal NETXP.Controls.XPButton btnAs;
	internal NETXP.Controls.XPButton btnGe;
	internal NETXP.Controls.XPButton btnGa;
	internal NETXP.Controls.XPButton btnZn;
	internal NETXP.Controls.XPButton btnCu;
	internal NETXP.Controls.XPButton btnNi;
	internal NETXP.Controls.XPButton btnCo;
	internal NETXP.Controls.XPButton btnFe;
	internal NETXP.Controls.XPButton btnMn;
	internal NETXP.Controls.XPButton btnCr;
	internal NETXP.Controls.XPButton btnTi;
	internal NETXP.Controls.XPButton btnSc;
	internal NETXP.Controls.XPButton btnCa;
	internal NETXP.Controls.XPButton btnK;
	internal NETXP.Controls.XPButton btnP;
	internal NETXP.Controls.XPButton btnSi;
	internal NETXP.Controls.XPButton btnAl;
	internal NETXP.Controls.XPButton btnMg;
	internal NETXP.Controls.XPButton btnNa;
	internal NETXP.Controls.XPButton btnN;
	internal NETXP.Controls.XPButton btnC;
	internal NETXP.Controls.XPButton btnB;
	internal NETXP.Controls.XPButton btnBe;
	internal NETXP.Controls.XPButton btnLi;
	internal NETXP.Controls.XPButton btnH;
	internal NETXP.Controls.XPButton btnLr;
	internal NETXP.Controls.XPButton btnNo;
	internal NETXP.Controls.XPButton btnMd;
	internal NETXP.Controls.XPButton btnRn;
	internal NETXP.Controls.XPButton btnAt;
	internal NETXP.Controls.XPButton btnPo;
	internal NETXP.Controls.XPButton btnLu;
	internal NETXP.Controls.XPButton btnYb;
	internal NETXP.Controls.XPButton btnTm;
	internal NETXP.Controls.XPButton btnXe;
	internal NETXP.Controls.XPButton btnI;
	internal NETXP.Controls.XPButton btnTe;
	internal NETXP.Controls.XPButton btnKr;
	internal NETXP.Controls.XPButton btnBr;
	internal NETXP.Controls.XPButton btnSe;
	internal NETXP.Controls.XPButton btnAr;
	internal NETXP.Controls.XPButton btnCl;
	internal NETXP.Controls.XPButton btnS;
	internal NETXP.Controls.XPButton btnNe;
	internal NETXP.Controls.XPButton btnF;
	internal NETXP.Controls.XPButton btnO;
	internal System.Windows.Forms.GroupBox GroupBoxMultielementLamps;
	internal NETXP.Controls.XPButton btnCuZn;
	internal NETXP.Controls.XPButton btnNaK;
	internal NETXP.Controls.XPButton btnCaMg;
	internal System.Windows.Forms.ComboBox cmbSelectElement;
	internal System.Windows.Forms.Label lblSelectElement;
	internal NETXP.Controls.XPButton btnCancel;
	internal NETXP.Controls.XPButton btnCrCoCuFeMnNi;
	internal NETXP.Controls.XPButton btnBlank;
	internal NETXP.Controls.XPButton btnTa;
	internal NETXP.Controls.XPButton btnNb;
	internal NETXP.Controls.XPButton btnV;
	internal GradientPanel.CustomPanel CustomPanelMain;
	internal System.Windows.Forms.Label lblVIIIB;
	internal System.Windows.Forms.Label VIIB;
	internal System.Windows.Forms.Label lblVIB;
	internal System.Windows.Forms.Label lblVB;
	internal System.Windows.Forms.Label IVB;
	internal System.Windows.Forms.Label lblIIIB;
	internal System.Windows.Forms.Label lblIIB;
	internal System.Windows.Forms.Label lblIB;
	internal System.Windows.Forms.Label lblVIIIA;
	internal System.Windows.Forms.Label lblVIIA;
	internal System.Windows.Forms.Label lblVIA;
	internal System.Windows.Forms.Label lblVA;
	internal System.Windows.Forms.Label lblIVA;
	internal System.Windows.Forms.Label IIIA;
	internal System.Windows.Forms.Label lblIIA;
	internal System.Windows.Forms.Label lblIA;
	internal NETXP.Controls.XPButton btnSelect;
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.Label Label5;
	internal System.Windows.Forms.Label Label6;
	internal System.Windows.Forms.Label Label7;
	internal System.Windows.Forms.Label Label8;
	internal System.Windows.Forms.Label Label9;
	internal System.Windows.Forms.Label Label10;
	internal System.Windows.Forms.Label Label11;
	internal NETXP.Controls.XPButton btnExtinguish;
	internal NETXP.Controls.XPButton btnIgnite;
	internal System.Windows.Forms.StatusBarPanel StatusBarPanelInfo;
	internal System.Windows.Forms.GroupBox GroupBox2;
	internal System.Windows.Forms.Label Label12;
	internal System.Windows.Forms.GroupBox GroupBox3;
	internal System.Windows.Forms.Label Label13;
	internal NETXP.Controls.XPButton btnN2OIgnite;
	internal NETXP.Controls.XPButton btnDelete;
	internal NETXP.Controls.XPButton btnR;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCookBook));
		this.CustomPanelMain = new GradientPanel.CustomPanel();
		this.btnCancel = new NETXP.Controls.XPButton();
		this.btnDelete = new NETXP.Controls.XPButton();
		this.btnR = new NETXP.Controls.XPButton();
		this.btnN2OIgnite = new NETXP.Controls.XPButton();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.Label13 = new System.Windows.Forms.Label();
		this.btnExtinguish = new NETXP.Controls.XPButton();
		this.btnIgnite = new NETXP.Controls.XPButton();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Label12 = new System.Windows.Forms.Label();
		this.Label11 = new System.Windows.Forms.Label();
		this.Label10 = new System.Windows.Forms.Label();
		this.Label9 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.btnSelect = new NETXP.Controls.XPButton();
		this.cmbSelectElement = new System.Windows.Forms.ComboBox();
		this.lblSelectElement = new System.Windows.Forms.Label();
		this.lblVIIIB = new System.Windows.Forms.Label();
		this.VIIB = new System.Windows.Forms.Label();
		this.lblVIB = new System.Windows.Forms.Label();
		this.lblVB = new System.Windows.Forms.Label();
		this.IVB = new System.Windows.Forms.Label();
		this.lblIIIB = new System.Windows.Forms.Label();
		this.lblIIB = new System.Windows.Forms.Label();
		this.lblIB = new System.Windows.Forms.Label();
		this.lblVIIIA = new System.Windows.Forms.Label();
		this.lblVIIA = new System.Windows.Forms.Label();
		this.lblVIA = new System.Windows.Forms.Label();
		this.lblVA = new System.Windows.Forms.Label();
		this.lblIVA = new System.Windows.Forms.Label();
		this.IIIA = new System.Windows.Forms.Label();
		this.lblIIA = new System.Windows.Forms.Label();
		this.lblIA = new System.Windows.Forms.Label();
		this.GroupBoxMultielementLamps = new System.Windows.Forms.GroupBox();
		this.btnCrCoCuFeMnNi = new NETXP.Controls.XPButton();
		this.btnCuZn = new NETXP.Controls.XPButton();
		this.btnNaK = new NETXP.Controls.XPButton();
		this.btnCaMg = new NETXP.Controls.XPButton();
		this.btnBlank = new NETXP.Controls.XPButton();
		this.btnHa = new NETXP.Controls.XPButton();
		this.btnRf = new NETXP.Controls.XPButton();
		this.btnHe = new NETXP.Controls.XPButton();
		this.btnLr = new NETXP.Controls.XPButton();
		this.btnNo = new NETXP.Controls.XPButton();
		this.btnMd = new NETXP.Controls.XPButton();
		this.btnFm = new NETXP.Controls.XPButton();
		this.btnEs = new NETXP.Controls.XPButton();
		this.btnCf = new NETXP.Controls.XPButton();
		this.btnBk = new NETXP.Controls.XPButton();
		this.btnCm = new NETXP.Controls.XPButton();
		this.btnAm = new NETXP.Controls.XPButton();
		this.btnPu = new NETXP.Controls.XPButton();
		this.btnNp = new NETXP.Controls.XPButton();
		this.btnU = new NETXP.Controls.XPButton();
		this.btnPa = new NETXP.Controls.XPButton();
		this.btnTh = new NETXP.Controls.XPButton();
		this.btnAc = new NETXP.Controls.XPButton();
		this.btnRa = new NETXP.Controls.XPButton();
		this.btnFr = new NETXP.Controls.XPButton();
		this.btnRn = new NETXP.Controls.XPButton();
		this.btnAt = new NETXP.Controls.XPButton();
		this.btnPo = new NETXP.Controls.XPButton();
		this.btnBi = new NETXP.Controls.XPButton();
		this.btnPb = new NETXP.Controls.XPButton();
		this.btnTl = new NETXP.Controls.XPButton();
		this.btnHg = new NETXP.Controls.XPButton();
		this.btnAu = new NETXP.Controls.XPButton();
		this.btnPt = new NETXP.Controls.XPButton();
		this.btnIr = new NETXP.Controls.XPButton();
		this.btnOs = new NETXP.Controls.XPButton();
		this.btnRe = new NETXP.Controls.XPButton();
		this.btnW = new NETXP.Controls.XPButton();
		this.btnTa = new NETXP.Controls.XPButton();
		this.btnHf = new NETXP.Controls.XPButton();
		this.btnLu = new NETXP.Controls.XPButton();
		this.btnYb = new NETXP.Controls.XPButton();
		this.btnTm = new NETXP.Controls.XPButton();
		this.btnEr = new NETXP.Controls.XPButton();
		this.btnHo = new NETXP.Controls.XPButton();
		this.btnDy = new NETXP.Controls.XPButton();
		this.btnTb = new NETXP.Controls.XPButton();
		this.btnGd = new NETXP.Controls.XPButton();
		this.btnEu = new NETXP.Controls.XPButton();
		this.btnSm = new NETXP.Controls.XPButton();
		this.btnPm = new NETXP.Controls.XPButton();
		this.btnNd = new NETXP.Controls.XPButton();
		this.btnPr = new NETXP.Controls.XPButton();
		this.btnCe = new NETXP.Controls.XPButton();
		this.btnLa = new NETXP.Controls.XPButton();
		this.btnBa = new NETXP.Controls.XPButton();
		this.btnCs = new NETXP.Controls.XPButton();
		this.btnXe = new NETXP.Controls.XPButton();
		this.btnI = new NETXP.Controls.XPButton();
		this.btnTe = new NETXP.Controls.XPButton();
		this.btnSb = new NETXP.Controls.XPButton();
		this.btnSn = new NETXP.Controls.XPButton();
		this.btnIn = new NETXP.Controls.XPButton();
		this.btnCd = new NETXP.Controls.XPButton();
		this.btnAg = new NETXP.Controls.XPButton();
		this.btnPd = new NETXP.Controls.XPButton();
		this.btnRh = new NETXP.Controls.XPButton();
		this.btnRu = new NETXP.Controls.XPButton();
		this.btnTc = new NETXP.Controls.XPButton();
		this.btnMo = new NETXP.Controls.XPButton();
		this.btnNb = new NETXP.Controls.XPButton();
		this.btnZr = new NETXP.Controls.XPButton();
		this.btnY = new NETXP.Controls.XPButton();
		this.btnSr = new NETXP.Controls.XPButton();
		this.btnRb = new NETXP.Controls.XPButton();
		this.btnKr = new NETXP.Controls.XPButton();
		this.btnBr = new NETXP.Controls.XPButton();
		this.btnSe = new NETXP.Controls.XPButton();
		this.btnAs = new NETXP.Controls.XPButton();
		this.btnGe = new NETXP.Controls.XPButton();
		this.btnGa = new NETXP.Controls.XPButton();
		this.btnZn = new NETXP.Controls.XPButton();
		this.btnCu = new NETXP.Controls.XPButton();
		this.btnNi = new NETXP.Controls.XPButton();
		this.btnCo = new NETXP.Controls.XPButton();
		this.btnFe = new NETXP.Controls.XPButton();
		this.btnMn = new NETXP.Controls.XPButton();
		this.btnCr = new NETXP.Controls.XPButton();
		this.btnV = new NETXP.Controls.XPButton();
		this.btnTi = new NETXP.Controls.XPButton();
		this.btnSc = new NETXP.Controls.XPButton();
		this.btnCa = new NETXP.Controls.XPButton();
		this.btnK = new NETXP.Controls.XPButton();
		this.btnAr = new NETXP.Controls.XPButton();
		this.btnCl = new NETXP.Controls.XPButton();
		this.btnS = new NETXP.Controls.XPButton();
		this.btnP = new NETXP.Controls.XPButton();
		this.btnSi = new NETXP.Controls.XPButton();
		this.btnAl = new NETXP.Controls.XPButton();
		this.btnMg = new NETXP.Controls.XPButton();
		this.btnNa = new NETXP.Controls.XPButton();
		this.btnNe = new NETXP.Controls.XPButton();
		this.btnF = new NETXP.Controls.XPButton();
		this.btnO = new NETXP.Controls.XPButton();
		this.btnN = new NETXP.Controls.XPButton();
		this.btnC = new NETXP.Controls.XPButton();
		this.btnB = new NETXP.Controls.XPButton();
		this.btnBe = new NETXP.Controls.XPButton();
		this.btnLi = new NETXP.Controls.XPButton();
		this.btnH = new NETXP.Controls.XPButton();
		this.StatusBar1 = new NETXP.Controls.Bars.StatusBar();
		this.StatusBarPanelInfo = new System.Windows.Forms.StatusBarPanel();
		this.CustomPanelMain.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBoxMultielementLamps.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).BeginInit();
		this.SuspendLayout();
		//
		//CustomPanelMain
		//
		this.CustomPanelMain.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelMain.Controls.Add(this.btnCancel);
		this.CustomPanelMain.Controls.Add(this.btnDelete);
		this.CustomPanelMain.Controls.Add(this.btnR);
		this.CustomPanelMain.Controls.Add(this.btnN2OIgnite);
		this.CustomPanelMain.Controls.Add(this.GroupBox3);
		this.CustomPanelMain.Controls.Add(this.btnExtinguish);
		this.CustomPanelMain.Controls.Add(this.btnIgnite);
		this.CustomPanelMain.Controls.Add(this.GroupBox1);
		this.CustomPanelMain.Controls.Add(this.btnSelect);
		this.CustomPanelMain.Controls.Add(this.cmbSelectElement);
		this.CustomPanelMain.Controls.Add(this.lblSelectElement);
		this.CustomPanelMain.Controls.Add(this.lblVIIIB);
		this.CustomPanelMain.Controls.Add(this.VIIB);
		this.CustomPanelMain.Controls.Add(this.lblVIB);
		this.CustomPanelMain.Controls.Add(this.lblVB);
		this.CustomPanelMain.Controls.Add(this.IVB);
		this.CustomPanelMain.Controls.Add(this.lblIIIB);
		this.CustomPanelMain.Controls.Add(this.lblIIB);
		this.CustomPanelMain.Controls.Add(this.lblIB);
		this.CustomPanelMain.Controls.Add(this.lblVIIIA);
		this.CustomPanelMain.Controls.Add(this.lblVIIA);
		this.CustomPanelMain.Controls.Add(this.lblVIA);
		this.CustomPanelMain.Controls.Add(this.lblVA);
		this.CustomPanelMain.Controls.Add(this.lblIVA);
		this.CustomPanelMain.Controls.Add(this.IIIA);
		this.CustomPanelMain.Controls.Add(this.lblIIA);
		this.CustomPanelMain.Controls.Add(this.lblIA);
		this.CustomPanelMain.Controls.Add(this.GroupBoxMultielementLamps);
		this.CustomPanelMain.Controls.Add(this.btnBlank);
		this.CustomPanelMain.Controls.Add(this.btnHa);
		this.CustomPanelMain.Controls.Add(this.btnRf);
		this.CustomPanelMain.Controls.Add(this.btnHe);
		this.CustomPanelMain.Controls.Add(this.btnLr);
		this.CustomPanelMain.Controls.Add(this.btnNo);
		this.CustomPanelMain.Controls.Add(this.btnMd);
		this.CustomPanelMain.Controls.Add(this.btnFm);
		this.CustomPanelMain.Controls.Add(this.btnEs);
		this.CustomPanelMain.Controls.Add(this.btnCf);
		this.CustomPanelMain.Controls.Add(this.btnBk);
		this.CustomPanelMain.Controls.Add(this.btnCm);
		this.CustomPanelMain.Controls.Add(this.btnAm);
		this.CustomPanelMain.Controls.Add(this.btnPu);
		this.CustomPanelMain.Controls.Add(this.btnNp);
		this.CustomPanelMain.Controls.Add(this.btnU);
		this.CustomPanelMain.Controls.Add(this.btnPa);
		this.CustomPanelMain.Controls.Add(this.btnTh);
		this.CustomPanelMain.Controls.Add(this.btnAc);
		this.CustomPanelMain.Controls.Add(this.btnRa);
		this.CustomPanelMain.Controls.Add(this.btnFr);
		this.CustomPanelMain.Controls.Add(this.btnRn);
		this.CustomPanelMain.Controls.Add(this.btnAt);
		this.CustomPanelMain.Controls.Add(this.btnPo);
		this.CustomPanelMain.Controls.Add(this.btnBi);
		this.CustomPanelMain.Controls.Add(this.btnPb);
		this.CustomPanelMain.Controls.Add(this.btnTl);
		this.CustomPanelMain.Controls.Add(this.btnHg);
		this.CustomPanelMain.Controls.Add(this.btnAu);
		this.CustomPanelMain.Controls.Add(this.btnPt);
		this.CustomPanelMain.Controls.Add(this.btnIr);
		this.CustomPanelMain.Controls.Add(this.btnOs);
		this.CustomPanelMain.Controls.Add(this.btnRe);
		this.CustomPanelMain.Controls.Add(this.btnW);
		this.CustomPanelMain.Controls.Add(this.btnTa);
		this.CustomPanelMain.Controls.Add(this.btnHf);
		this.CustomPanelMain.Controls.Add(this.btnLu);
		this.CustomPanelMain.Controls.Add(this.btnYb);
		this.CustomPanelMain.Controls.Add(this.btnTm);
		this.CustomPanelMain.Controls.Add(this.btnEr);
		this.CustomPanelMain.Controls.Add(this.btnHo);
		this.CustomPanelMain.Controls.Add(this.btnDy);
		this.CustomPanelMain.Controls.Add(this.btnTb);
		this.CustomPanelMain.Controls.Add(this.btnGd);
		this.CustomPanelMain.Controls.Add(this.btnEu);
		this.CustomPanelMain.Controls.Add(this.btnSm);
		this.CustomPanelMain.Controls.Add(this.btnPm);
		this.CustomPanelMain.Controls.Add(this.btnNd);
		this.CustomPanelMain.Controls.Add(this.btnPr);
		this.CustomPanelMain.Controls.Add(this.btnCe);
		this.CustomPanelMain.Controls.Add(this.btnLa);
		this.CustomPanelMain.Controls.Add(this.btnBa);
		this.CustomPanelMain.Controls.Add(this.btnCs);
		this.CustomPanelMain.Controls.Add(this.btnXe);
		this.CustomPanelMain.Controls.Add(this.btnI);
		this.CustomPanelMain.Controls.Add(this.btnTe);
		this.CustomPanelMain.Controls.Add(this.btnSb);
		this.CustomPanelMain.Controls.Add(this.btnSn);
		this.CustomPanelMain.Controls.Add(this.btnIn);
		this.CustomPanelMain.Controls.Add(this.btnCd);
		this.CustomPanelMain.Controls.Add(this.btnAg);
		this.CustomPanelMain.Controls.Add(this.btnPd);
		this.CustomPanelMain.Controls.Add(this.btnRh);
		this.CustomPanelMain.Controls.Add(this.btnRu);
		this.CustomPanelMain.Controls.Add(this.btnTc);
		this.CustomPanelMain.Controls.Add(this.btnMo);
		this.CustomPanelMain.Controls.Add(this.btnNb);
		this.CustomPanelMain.Controls.Add(this.btnZr);
		this.CustomPanelMain.Controls.Add(this.btnY);
		this.CustomPanelMain.Controls.Add(this.btnSr);
		this.CustomPanelMain.Controls.Add(this.btnRb);
		this.CustomPanelMain.Controls.Add(this.btnKr);
		this.CustomPanelMain.Controls.Add(this.btnBr);
		this.CustomPanelMain.Controls.Add(this.btnSe);
		this.CustomPanelMain.Controls.Add(this.btnAs);
		this.CustomPanelMain.Controls.Add(this.btnGe);
		this.CustomPanelMain.Controls.Add(this.btnGa);
		this.CustomPanelMain.Controls.Add(this.btnZn);
		this.CustomPanelMain.Controls.Add(this.btnCu);
		this.CustomPanelMain.Controls.Add(this.btnNi);
		this.CustomPanelMain.Controls.Add(this.btnCo);
		this.CustomPanelMain.Controls.Add(this.btnFe);
		this.CustomPanelMain.Controls.Add(this.btnMn);
		this.CustomPanelMain.Controls.Add(this.btnCr);
		this.CustomPanelMain.Controls.Add(this.btnV);
		this.CustomPanelMain.Controls.Add(this.btnTi);
		this.CustomPanelMain.Controls.Add(this.btnSc);
		this.CustomPanelMain.Controls.Add(this.btnCa);
		this.CustomPanelMain.Controls.Add(this.btnK);
		this.CustomPanelMain.Controls.Add(this.btnAr);
		this.CustomPanelMain.Controls.Add(this.btnCl);
		this.CustomPanelMain.Controls.Add(this.btnS);
		this.CustomPanelMain.Controls.Add(this.btnP);
		this.CustomPanelMain.Controls.Add(this.btnSi);
		this.CustomPanelMain.Controls.Add(this.btnAl);
		this.CustomPanelMain.Controls.Add(this.btnMg);
		this.CustomPanelMain.Controls.Add(this.btnNa);
		this.CustomPanelMain.Controls.Add(this.btnNe);
		this.CustomPanelMain.Controls.Add(this.btnF);
		this.CustomPanelMain.Controls.Add(this.btnO);
		this.CustomPanelMain.Controls.Add(this.btnN);
		this.CustomPanelMain.Controls.Add(this.btnC);
		this.CustomPanelMain.Controls.Add(this.btnB);
		this.CustomPanelMain.Controls.Add(this.btnBe);
		this.CustomPanelMain.Controls.Add(this.btnLi);
		this.CustomPanelMain.Controls.Add(this.btnH);
		this.CustomPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelMain.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelMain.Name = "CustomPanelMain";
		this.CustomPanelMain.Size = new System.Drawing.Size(700, 491);
		this.CustomPanelMain.TabIndex = 0;
		//
		//btnCancel
		//
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCancel.Location = new System.Drawing.Point(558, 419);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(96, 40);
		this.btnCancel.TabIndex = 111;
		this.btnCancel.Text = "Ca&ncel";
		//
		//btnDelete
		//
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDelete.Location = new System.Drawing.Point(626, 424);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Size = new System.Drawing.Size(8, 8);
		this.btnDelete.TabIndex = 137;
		this.btnDelete.TabStop = false;
		this.btnDelete.Text = "&Delete";
		this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnR
		//
		this.btnR.BackColor = System.Drawing.Color.Transparent;
		this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnR.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnR.Location = new System.Drawing.Point(636, 424);
		this.btnR.Name = "btnR";
		this.btnR.Size = new System.Drawing.Size(8, 8);
		this.btnR.TabIndex = 136;
		this.btnR.TabStop = false;
		this.btnR.Text = "&R";
		this.btnR.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnN2OIgnite
		//
		this.btnN2OIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN2OIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnN2OIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN2OIgnite.Location = new System.Drawing.Point(608, 422);
		this.btnN2OIgnite.Name = "btnN2OIgnite";
		this.btnN2OIgnite.Size = new System.Drawing.Size(5, 5);
		this.btnN2OIgnite.TabIndex = 135;
		this.btnN2OIgnite.TabStop = false;
		this.btnN2OIgnite.Text = "N2O&C";
		this.btnN2OIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//GroupBox3
		//
		this.GroupBox3.Controls.Add(this.Label13);
		this.GroupBox3.Location = new System.Drawing.Point(320, 34);
		this.GroupBox3.Name = "GroupBox3";
		this.GroupBox3.Size = new System.Drawing.Size(122, 100);
		this.GroupBox3.TabIndex = 134;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Key To Element";
		//
		//Label13
		//
		this.Label13.Image = (System.Drawing.Image)resources.GetObject("Label13.Image");
		this.Label13.Location = new System.Drawing.Point(-6, 20);
		this.Label13.Name = "Label13";
		this.Label13.Size = new System.Drawing.Size(134, 76);
		this.Label13.TabIndex = 0;
		//
		//btnExtinguish
		//
		this.btnExtinguish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExtinguish.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnExtinguish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnExtinguish.Location = new System.Drawing.Point(570, 432);
		this.btnExtinguish.Name = "btnExtinguish";
		this.btnExtinguish.Size = new System.Drawing.Size(26, 18);
		this.btnExtinguish.TabIndex = 132;
		this.btnExtinguish.TabStop = false;
		this.btnExtinguish.Text = "&Extinguish";
		this.btnExtinguish.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//btnIgnite
		//
		this.btnIgnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIgnite.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnIgnite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIgnite.Location = new System.Drawing.Point(616, 432);
		this.btnIgnite.Name = "btnIgnite";
		this.btnIgnite.Size = new System.Drawing.Size(22, 17);
		this.btnIgnite.TabIndex = 131;
		this.btnIgnite.TabStop = false;
		this.btnIgnite.Text = "&Ignition";
		this.btnIgnite.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		//
		//GroupBox1
		//
		this.GroupBox1.Controls.Add(this.GroupBox2);
		this.GroupBox1.Controls.Add(this.Label11);
		this.GroupBox1.Controls.Add(this.Label10);
		this.GroupBox1.Controls.Add(this.Label9);
		this.GroupBox1.Controls.Add(this.Label8);
		this.GroupBox1.Controls.Add(this.Label7);
		this.GroupBox1.Controls.Add(this.Label6);
		this.GroupBox1.Controls.Add(this.Label5);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.GroupBox1.Location = new System.Drawing.Point(172, 34);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(144, 100);
		this.GroupBox1.TabIndex = 130;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "COLOR KEY";
		//
		//GroupBox2
		//
		this.GroupBox2.Controls.Add(this.Label12);
		this.GroupBox2.Location = new System.Drawing.Point(94, 4);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(48, 60);
		this.GroupBox2.TabIndex = 10;
		this.GroupBox2.TabStop = false;
		//
		//Label12
		//
		this.Label12.Font = new System.Drawing.Font("Arial", 6.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label12.Location = new System.Drawing.Point(2, 10);
		this.Label12.Name = "Label12";
		this.Label12.Size = new System.Drawing.Size(48, 48);
		this.Label12.TabIndex = 0;
		this.Label12.Text = "State of    E lements at room temp.  ";
		//
		//Label11
		//
		this.Label11.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label11.Location = new System.Drawing.Point(56, 77);
		this.Label11.Name = "Label11";
		this.Label11.Size = new System.Drawing.Size(98, 20);
		this.Label11.TabIndex = 9;
		this.Label11.Text = "SYNTHETICALLY CREATED";
		//
		//Label10
		//
		this.Label10.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label10.Location = new System.Drawing.Point(56, 64);
		this.Label10.Name = "Label10";
		this.Label10.Size = new System.Drawing.Size(86, 10);
		this.Label10.TabIndex = 8;
		this.Label10.Text = "RADIOACTIVE";
		//
		//Label9
		//
		this.Label9.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label9.Location = new System.Drawing.Point(56, 48);
		this.Label9.Name = "Label9";
		this.Label9.Size = new System.Drawing.Size(44, 10);
		this.Label9.TabIndex = 7;
		this.Label9.Text = "SOLID";
		//
		//Label8
		//
		this.Label8.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label8.Location = new System.Drawing.Point(56, 34);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(42, 10);
		this.Label8.TabIndex = 6;
		this.Label8.Text = "LIQUID";
		//
		//Label7
		//
		this.Label7.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.Label7.Location = new System.Drawing.Point(56, 18);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(36, 10);
		this.Label7.TabIndex = 5;
		this.Label7.Text = "GAS";
		//
		//Label6
		//
		this.Label6.BackColor = System.Drawing.Color.LimeGreen;
		this.Label6.Location = new System.Drawing.Point(9, 61);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(41, 14);
		this.Label6.TabIndex = 4;
		//
		//Label5
		//
		this.Label5.BackColor = System.Drawing.Color.Magenta;
		this.Label5.Location = new System.Drawing.Point(9, 76);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(41, 14);
		this.Label5.TabIndex = 3;
		//
		//Label4
		//
		this.Label4.BackColor = System.Drawing.Color.DodgerBlue;
		this.Label4.Location = new System.Drawing.Point(9, 46);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(41, 14);
		this.Label4.TabIndex = 2;
		//
		//Label3
		//
		this.Label3.BackColor = System.Drawing.Color.Red;
		this.Label3.Location = new System.Drawing.Point(9, 31);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(41, 14);
		this.Label3.TabIndex = 1;
		//
		//Label2
		//
		this.Label2.BackColor = System.Drawing.Color.Goldenrod;
		this.Label2.Location = new System.Drawing.Point(9, 16);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(41, 14);
		this.Label2.TabIndex = 0;
		//
		//btnSelect
		//
		this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSelect.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnSelect.Image = (System.Drawing.Image)resources.GetObject("btnSelect.Image");
		this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSelect.Location = new System.Drawing.Point(444, 8);
		this.btnSelect.Name = "btnSelect";
		this.btnSelect.Size = new System.Drawing.Size(90, 34);
		this.btnSelect.TabIndex = 1;
		this.btnSelect.Text = "&Select";
		//
		//cmbSelectElement
		//
		this.cmbSelectElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbSelectElement.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.cmbSelectElement.Location = new System.Drawing.Point(268, 9);
		this.cmbSelectElement.Name = "cmbSelectElement";
		this.cmbSelectElement.Size = new System.Drawing.Size(152, 23);
		this.cmbSelectElement.TabIndex = 0;
		//
		//lblSelectElement
		//
		this.lblSelectElement.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSelectElement.Location = new System.Drawing.Point(96, 13);
		this.lblSelectElement.Name = "lblSelectElement";
		this.lblSelectElement.Size = new System.Drawing.Size(170, 20);
		this.lblSelectElement.TabIndex = 128;
		this.lblSelectElement.Text = "Select element from the list :-";
		//
		//lblVIIIB
		//
		this.lblVIIIB.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblVIIIB.Location = new System.Drawing.Point(306, 124);
		this.lblVIIIB.Name = "lblVIIIB";
		this.lblVIIIB.Size = new System.Drawing.Size(50, 34);
		this.lblVIIIB.TabIndex = 127;
		this.lblVIIIB.Text = "VIIIB";
		this.lblVIIIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//VIIB
		//
		this.VIIB.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.VIIB.Location = new System.Drawing.Point(236, 122);
		this.VIIB.Name = "VIIB";
		this.VIIB.Size = new System.Drawing.Size(44, 36);
		this.VIIB.TabIndex = 126;
		this.VIIB.Text = "VIIB";
		this.VIIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblVIB
		//
		this.lblVIB.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblVIB.Location = new System.Drawing.Point(201, 128);
		this.lblVIB.Name = "lblVIB";
		this.lblVIB.Size = new System.Drawing.Size(38, 30);
		this.lblVIB.TabIndex = 125;
		this.lblVIB.Text = "VIB";
		this.lblVIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblVB
		//
		this.lblVB.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblVB.Location = new System.Drawing.Point(171, 126);
		this.lblVB.Name = "lblVB";
		this.lblVB.Size = new System.Drawing.Size(36, 32);
		this.lblVB.TabIndex = 124;
		this.lblVB.Text = "VB";
		this.lblVB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//IVB
		//
		this.IVB.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.IVB.Location = new System.Drawing.Point(132, 126);
		this.IVB.Name = "IVB";
		this.IVB.Size = new System.Drawing.Size(40, 32);
		this.IVB.TabIndex = 123;
		this.IVB.Text = "IVB";
		this.IVB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblIIIB
		//
		this.lblIIIB.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblIIIB.Location = new System.Drawing.Point(96, 124);
		this.lblIIIB.Name = "lblIIIB";
		this.lblIIIB.Size = new System.Drawing.Size(38, 34);
		this.lblIIIB.TabIndex = 122;
		this.lblIIIB.Text = "IIIB";
		this.lblIIIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblIIB
		//
		this.lblIIB.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblIIB.Location = new System.Drawing.Point(420, 125);
		this.lblIIB.Name = "lblIIB";
		this.lblIIB.Size = new System.Drawing.Size(38, 32);
		this.lblIIB.TabIndex = 121;
		this.lblIIB.Text = "IIB";
		this.lblIIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblIB
		//
		this.lblIB.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblIB.Location = new System.Drawing.Point(388, 127);
		this.lblIB.Name = "lblIB";
		this.lblIB.Size = new System.Drawing.Size(34, 30);
		this.lblIB.TabIndex = 120;
		this.lblIB.Text = "IB";
		this.lblIB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblVIIIA
		//
		this.lblVIIIA.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblVIIIA.Location = new System.Drawing.Point(628, 28);
		this.lblVIIIA.Name = "lblVIIIA";
		this.lblVIIIA.Size = new System.Drawing.Size(50, 26);
		this.lblVIIIA.TabIndex = 119;
		this.lblVIIIA.Text = "VIIIA";
		this.lblVIIIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblVIIA
		//
		this.lblVIIA.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblVIIA.Location = new System.Drawing.Point(594, 55);
		this.lblVIIA.Name = "lblVIIA";
		this.lblVIIA.Size = new System.Drawing.Size(44, 30);
		this.lblVIIA.TabIndex = 118;
		this.lblVIIA.Text = "VIIA";
		this.lblVIIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblVIA
		//
		this.lblVIA.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblVIA.Location = new System.Drawing.Point(558, 53);
		this.lblVIA.Name = "lblVIA";
		this.lblVIA.Size = new System.Drawing.Size(41, 32);
		this.lblVIA.TabIndex = 117;
		this.lblVIA.Text = "VIA";
		this.lblVIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblVA
		//
		this.lblVA.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblVA.Location = new System.Drawing.Point(526, 54);
		this.lblVA.Name = "lblVA";
		this.lblVA.Size = new System.Drawing.Size(38, 32);
		this.lblVA.TabIndex = 116;
		this.lblVA.Text = "VA";
		this.lblVA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblIVA
		//
		this.lblIVA.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblIVA.Location = new System.Drawing.Point(492, 56);
		this.lblIVA.Name = "lblIVA";
		this.lblIVA.Size = new System.Drawing.Size(38, 30);
		this.lblIVA.TabIndex = 115;
		this.lblIVA.Text = "IVA";
		this.lblIVA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//IIIA
		//
		this.IIIA.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.IIIA.Location = new System.Drawing.Point(455, 54);
		this.IIIA.Name = "IIIA";
		this.IIIA.Size = new System.Drawing.Size(38, 32);
		this.IIIA.TabIndex = 114;
		this.IIIA.Text = "IIIA";
		this.IIIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblIIA
		//
		this.lblIIA.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblIIA.Location = new System.Drawing.Point(62, 60);
		this.lblIIA.Name = "lblIIA";
		this.lblIIA.Size = new System.Drawing.Size(32, 26);
		this.lblIIA.TabIndex = 113;
		this.lblIIA.Text = "IIA";
		this.lblIIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//lblIA
		//
		this.lblIA.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblIA.Location = new System.Drawing.Point(28, 28);
		this.lblIA.Name = "lblIA";
		this.lblIA.Size = new System.Drawing.Size(32, 26);
		this.lblIA.TabIndex = 112;
		this.lblIA.Text = "IA";
		this.lblIA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		//
		//GroupBoxMultielementLamps
		//
		this.GroupBoxMultielementLamps.Controls.Add(this.btnCrCoCuFeMnNi);
		this.GroupBoxMultielementLamps.Controls.Add(this.btnCuZn);
		this.GroupBoxMultielementLamps.Controls.Add(this.btnNaK);
		this.GroupBoxMultielementLamps.Controls.Add(this.btnCaMg);
		this.GroupBoxMultielementLamps.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.GroupBoxMultielementLamps.Location = new System.Drawing.Point(50, 400);
		this.GroupBoxMultielementLamps.Name = "GroupBoxMultielementLamps";
		this.GroupBoxMultielementLamps.Size = new System.Drawing.Size(480, 68);
		this.GroupBoxMultielementLamps.TabIndex = 109;
		this.GroupBoxMultielementLamps.TabStop = false;
		this.GroupBoxMultielementLamps.Text = "Multielement Lamps";
		//
		//btnCrCoCuFeMnNi
		//
		this.btnCrCoCuFeMnNi.BackColor = System.Drawing.Color.DodgerBlue;
		this.btnCrCoCuFeMnNi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCrCoCuFeMnNi.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCrCoCuFeMnNi.ForeColor = System.Drawing.Color.White;
		this.btnCrCoCuFeMnNi.Image = (System.Drawing.Image)resources.GetObject("btnCrCoCuFeMnNi.Image");
		this.btnCrCoCuFeMnNi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCrCoCuFeMnNi.Location = new System.Drawing.Point(272, 20);
		this.btnCrCoCuFeMnNi.Name = "btnCrCoCuFeMnNi";
		this.btnCrCoCuFeMnNi.Size = new System.Drawing.Size(177, 32);
		this.btnCrCoCuFeMnNi.TabIndex = 3;
		this.btnCrCoCuFeMnNi.Tag = "70";
		//
		//btnCuZn
		//
		this.btnCuZn.BackColor = System.Drawing.Color.White;
		this.btnCuZn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCuZn.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCuZn.ForeColor = System.Drawing.Color.White;
		this.btnCuZn.Image = (System.Drawing.Image)resources.GetObject("btnCuZn.Image");
		this.btnCuZn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCuZn.Location = new System.Drawing.Point(186, 20);
		this.btnCuZn.Name = "btnCuZn";
		this.btnCuZn.Size = new System.Drawing.Size(67, 32);
		this.btnCuZn.TabIndex = 2;
		this.btnCuZn.Tag = "69";
		//
		//btnNaK
		//
		this.btnNaK.BackColor = System.Drawing.Color.DodgerBlue;
		this.btnNaK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNaK.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnNaK.ForeColor = System.Drawing.Color.White;
		this.btnNaK.Image = (System.Drawing.Image)resources.GetObject("btnNaK.Image");
		this.btnNaK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNaK.Location = new System.Drawing.Point(100, 20);
		this.btnNaK.Name = "btnNaK";
		this.btnNaK.Size = new System.Drawing.Size(63, 32);
		this.btnNaK.TabIndex = 1;
		this.btnNaK.Tag = "68";
		//
		//btnCaMg
		//
		this.btnCaMg.BackColor = System.Drawing.Color.DodgerBlue;
		this.btnCaMg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCaMg.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnCaMg.ForeColor = System.Drawing.Color.White;
		this.btnCaMg.Image = (System.Drawing.Image)resources.GetObject("btnCaMg.Image");
		this.btnCaMg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCaMg.Location = new System.Drawing.Point(12, 20);
		this.btnCaMg.Name = "btnCaMg";
		this.btnCaMg.Size = new System.Drawing.Size(63, 32);
		this.btnCaMg.TabIndex = 0;
		this.btnCaMg.Tag = "67";
		//
		//btnBlank
		//
		this.btnBlank.BackColor = System.Drawing.Color.White;
		this.btnBlank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnBlank.Image = (System.Drawing.Image)resources.GetObject("btnBlank.Image");
		this.btnBlank.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBlank.Location = new System.Drawing.Point(206, 260);
		this.btnBlank.Name = "btnBlank";
		this.btnBlank.Size = new System.Drawing.Size(32, 32);
		this.btnBlank.TabIndex = 108;
		//
		//btnHa
		//
		this.btnHa.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnHa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHa.Image = (System.Drawing.Image)resources.GetObject("btnHa.Image");
		this.btnHa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHa.Location = new System.Drawing.Point(170, 260);
		this.btnHa.Name = "btnHa";
		this.btnHa.Size = new System.Drawing.Size(32, 32);
		this.btnHa.TabIndex = 107;
		this.btnHa.Tag = "103";
		//
		//btnRf
		//
		this.btnRf.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnRf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRf.Image = (System.Drawing.Image)resources.GetObject("btnRf.Image");
		this.btnRf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRf.Location = new System.Drawing.Point(134, 260);
		this.btnRf.Name = "btnRf";
		this.btnRf.Size = new System.Drawing.Size(32, 32);
		this.btnRf.TabIndex = 106;
		this.btnRf.Tag = "106";
		//
		//btnHe
		//
		this.btnHe.BackColor = System.Drawing.Color.Gold;
		this.btnHe.Cursor = System.Windows.Forms.Cursors.Default;
		this.btnHe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHe.Image = (System.Drawing.Image)resources.GetObject("btnHe.Image");
		this.btnHe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHe.Location = new System.Drawing.Point(26, 56);
		this.btnHe.Name = "btnHe";
		this.btnHe.Size = new System.Drawing.Size(32, 32);
		this.btnHe.TabIndex = 2;
		this.btnHe.Tag = "71";
		//
		//btnLr
		//
		this.btnLr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnLr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnLr.Image = (System.Drawing.Image)resources.GetObject("btnLr.Image");
		this.btnLr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnLr.Location = new System.Drawing.Point(638, 354);
		this.btnLr.Name = "btnLr";
		this.btnLr.Size = new System.Drawing.Size(32, 32);
		this.btnLr.TabIndex = 104;
		this.btnLr.Tag = "98";
		//
		//btnNo
		//
		this.btnNo.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNo.Image = (System.Drawing.Image)resources.GetObject("btnNo.Image");
		this.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNo.Location = new System.Drawing.Point(602, 354);
		this.btnNo.Name = "btnNo";
		this.btnNo.Size = new System.Drawing.Size(32, 32);
		this.btnNo.TabIndex = 103;
		this.btnNo.Tag = "97";
		//
		//btnMd
		//
		this.btnMd.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnMd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnMd.Image = (System.Drawing.Image)resources.GetObject("btnMd.Image");
		this.btnMd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnMd.Location = new System.Drawing.Point(566, 354);
		this.btnMd.Name = "btnMd";
		this.btnMd.Size = new System.Drawing.Size(32, 32);
		this.btnMd.TabIndex = 102;
		this.btnMd.Tag = "96";
		//
		//btnFm
		//
		this.btnFm.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnFm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnFm.Image = (System.Drawing.Image)resources.GetObject("btnFm.Image");
		this.btnFm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnFm.Location = new System.Drawing.Point(530, 354);
		this.btnFm.Name = "btnFm";
		this.btnFm.Size = new System.Drawing.Size(32, 32);
		this.btnFm.TabIndex = 101;
		this.btnFm.Tag = "95";
		//
		//btnEs
		//
		this.btnEs.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnEs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnEs.Image = (System.Drawing.Image)resources.GetObject("btnEs.Image");
		this.btnEs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnEs.Location = new System.Drawing.Point(494, 354);
		this.btnEs.Name = "btnEs";
		this.btnEs.Size = new System.Drawing.Size(32, 32);
		this.btnEs.TabIndex = 100;
		this.btnEs.Tag = "94";
		//
		//btnCf
		//
		this.btnCf.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCf.Image = (System.Drawing.Image)resources.GetObject("btnCf.Image");
		this.btnCf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCf.Location = new System.Drawing.Point(458, 354);
		this.btnCf.Name = "btnCf";
		this.btnCf.Size = new System.Drawing.Size(32, 32);
		this.btnCf.TabIndex = 99;
		this.btnCf.Tag = "93";
		//
		//btnBk
		//
		this.btnBk.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnBk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnBk.Image = (System.Drawing.Image)resources.GetObject("btnBk.Image");
		this.btnBk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBk.Location = new System.Drawing.Point(422, 354);
		this.btnBk.Name = "btnBk";
		this.btnBk.Size = new System.Drawing.Size(32, 32);
		this.btnBk.TabIndex = 98;
		this.btnBk.Tag = "92";
		//
		//btnCm
		//
		this.btnCm.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCm.Image = (System.Drawing.Image)resources.GetObject("btnCm.Image");
		this.btnCm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCm.Location = new System.Drawing.Point(386, 354);
		this.btnCm.Name = "btnCm";
		this.btnCm.Size = new System.Drawing.Size(32, 32);
		this.btnCm.TabIndex = 97;
		this.btnCm.Tag = "91";
		//
		//btnAm
		//
		this.btnAm.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnAm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAm.Image = (System.Drawing.Image)resources.GetObject("btnAm.Image");
		this.btnAm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAm.Location = new System.Drawing.Point(350, 354);
		this.btnAm.Name = "btnAm";
		this.btnAm.Size = new System.Drawing.Size(32, 32);
		this.btnAm.TabIndex = 96;
		this.btnAm.Tag = "90";
		//
		//btnPu
		//
		this.btnPu.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnPu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPu.Image = (System.Drawing.Image)resources.GetObject("btnPu.Image");
		this.btnPu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPu.Location = new System.Drawing.Point(314, 354);
		this.btnPu.Name = "btnPu";
		this.btnPu.Size = new System.Drawing.Size(32, 32);
		this.btnPu.TabIndex = 95;
		this.btnPu.Tag = "89";
		//
		//btnNp
		//
		this.btnNp.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnNp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNp.Image = (System.Drawing.Image)resources.GetObject("btnNp.Image");
		this.btnNp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNp.Location = new System.Drawing.Point(278, 354);
		this.btnNp.Name = "btnNp";
		this.btnNp.Size = new System.Drawing.Size(32, 32);
		this.btnNp.TabIndex = 94;
		this.btnNp.Tag = "88";
		//
		//btnU
		//
		this.btnU.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnU.Image = (System.Drawing.Image)resources.GetObject("btnU.Image");
		this.btnU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnU.Location = new System.Drawing.Point(242, 354);
		this.btnU.Name = "btnU";
		this.btnU.Size = new System.Drawing.Size(32, 32);
		this.btnU.TabIndex = 93;
		this.btnU.Tag = "60";
		//
		//btnPa
		//
		this.btnPa.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnPa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPa.Image = (System.Drawing.Image)resources.GetObject("btnPa.Image");
		this.btnPa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPa.Location = new System.Drawing.Point(206, 354);
		this.btnPa.Name = "btnPa";
		this.btnPa.Size = new System.Drawing.Size(32, 32);
		this.btnPa.TabIndex = 92;
		this.btnPa.Tag = "87";
		//
		//btnTh
		//
		this.btnTh.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnTh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTh.Image = (System.Drawing.Image)resources.GetObject("btnTh.Image");
		this.btnTh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTh.Location = new System.Drawing.Point(170, 354);
		this.btnTh.Name = "btnTh";
		this.btnTh.Size = new System.Drawing.Size(32, 32);
		this.btnTh.TabIndex = 91;
		this.btnTh.Tag = "86";
		//
		//btnAc
		//
		this.btnAc.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnAc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAc.Image = (System.Drawing.Image)resources.GetObject("btnAc.Image");
		this.btnAc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAc.Location = new System.Drawing.Point(134, 354);
		this.btnAc.Name = "btnAc";
		this.btnAc.Size = new System.Drawing.Size(32, 32);
		this.btnAc.TabIndex = 90;
		this.btnAc.Tag = "84";
		//
		//btnRa
		//
		this.btnRa.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnRa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRa.Image = (System.Drawing.Image)resources.GetObject("btnRa.Image");
		this.btnRa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRa.Location = new System.Drawing.Point(62, 260);
		this.btnRa.Name = "btnRa";
		this.btnRa.Size = new System.Drawing.Size(32, 32);
		this.btnRa.TabIndex = 89;
		this.btnRa.Tag = "83";
		//
		//btnFr
		//
		this.btnFr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnFr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnFr.ForeColor = System.Drawing.SystemColors.ControlText;
		this.btnFr.Image = (System.Drawing.Image)resources.GetObject("btnFr.Image");
		this.btnFr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnFr.Location = new System.Drawing.Point(26, 260);
		this.btnFr.Name = "btnFr";
		this.btnFr.Size = new System.Drawing.Size(32, 32);
		this.btnFr.TabIndex = 88;
		this.btnFr.Tag = "82";
		//
		//btnRn
		//
		this.btnRn.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnRn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRn.Image = (System.Drawing.Image)resources.GetObject("btnRn.Image");
		this.btnRn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRn.Location = new System.Drawing.Point(638, 226);
		this.btnRn.Name = "btnRn";
		this.btnRn.Size = new System.Drawing.Size(32, 32);
		this.btnRn.TabIndex = 87;
		this.btnRn.Tag = "107";
		//
		//btnAt
		//
		this.btnAt.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnAt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAt.Image = (System.Drawing.Image)resources.GetObject("btnAt.Image");
		this.btnAt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAt.Location = new System.Drawing.Point(602, 226);
		this.btnAt.Name = "btnAt";
		this.btnAt.Size = new System.Drawing.Size(32, 32);
		this.btnAt.TabIndex = 86;
		this.btnAt.Tag = "100";
		//
		//btnPo
		//
		this.btnPo.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnPo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPo.Image = (System.Drawing.Image)resources.GetObject("btnPo.Image");
		this.btnPo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPo.Location = new System.Drawing.Point(566, 226);
		this.btnPo.Name = "btnPo";
		this.btnPo.Size = new System.Drawing.Size(32, 32);
		this.btnPo.TabIndex = 85;
		this.btnPo.Tag = "99";
		//
		//btnBi
		//
		this.btnBi.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnBi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnBi.Image = (System.Drawing.Image)resources.GetObject("btnBi.Image");
		this.btnBi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBi.Location = new System.Drawing.Point(530, 226);
		this.btnBi.Name = "btnBi";
		this.btnBi.Size = new System.Drawing.Size(32, 32);
		this.btnBi.TabIndex = 84;
		this.btnBi.Tag = "8";
		//
		//btnPb
		//
		this.btnPb.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnPb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPb.Image = (System.Drawing.Image)resources.GetObject("btnPb.Image");
		this.btnPb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPb.Location = new System.Drawing.Point(494, 226);
		this.btnPb.Name = "btnPb";
		this.btnPb.Size = new System.Drawing.Size(32, 32);
		this.btnPb.TabIndex = 83;
		this.btnPb.Tag = "39";
		//
		//btnTl
		//
		this.btnTl.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnTl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTl.Image = (System.Drawing.Image)resources.GetObject("btnTl.Image");
		this.btnTl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTl.Location = new System.Drawing.Point(458, 226);
		this.btnTl.Name = "btnTl";
		this.btnTl.Size = new System.Drawing.Size(32, 32);
		this.btnTl.TabIndex = 82;
		this.btnTl.Tag = "58";
		//
		//btnHg
		//
		this.btnHg.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnHg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHg.Image = (System.Drawing.Image)resources.GetObject("btnHg.Image");
		this.btnHg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHg.Location = new System.Drawing.Point(422, 226);
		this.btnHg.Name = "btnHg";
		this.btnHg.Size = new System.Drawing.Size(32, 32);
		this.btnHg.TabIndex = 81;
		this.btnHg.Tag = "23";
		//
		//btnAu
		//
		this.btnAu.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnAu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAu.Image = (System.Drawing.Image)resources.GetObject("btnAu.Image");
		this.btnAu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAu.Location = new System.Drawing.Point(386, 226);
		this.btnAu.Name = "btnAu";
		this.btnAu.Size = new System.Drawing.Size(32, 32);
		this.btnAu.TabIndex = 80;
		this.btnAu.Tag = "4";
		//
		//btnPt
		//
		this.btnPt.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnPt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPt.Image = (System.Drawing.Image)resources.GetObject("btnPt.Image");
		this.btnPt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPt.Location = new System.Drawing.Point(350, 226);
		this.btnPt.Name = "btnPt";
		this.btnPt.Size = new System.Drawing.Size(32, 32);
		this.btnPt.TabIndex = 79;
		this.btnPt.Tag = "42";
		//
		//btnIr
		//
		this.btnIr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnIr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIr.Image = (System.Drawing.Image)resources.GetObject("btnIr.Image");
		this.btnIr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIr.Location = new System.Drawing.Point(314, 226);
		this.btnIr.Name = "btnIr";
		this.btnIr.Size = new System.Drawing.Size(32, 32);
		this.btnIr.TabIndex = 78;
		this.btnIr.Tag = "26";
		//
		//btnOs
		//
		this.btnOs.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnOs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOs.Image = (System.Drawing.Image)resources.GetObject("btnOs.Image");
		this.btnOs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOs.Location = new System.Drawing.Point(278, 226);
		this.btnOs.Name = "btnOs";
		this.btnOs.Size = new System.Drawing.Size(32, 32);
		this.btnOs.TabIndex = 77;
		this.btnOs.Tag = "38";
		//
		//btnRe
		//
		this.btnRe.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnRe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRe.Image = (System.Drawing.Image)resources.GetObject("btnRe.Image");
		this.btnRe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRe.Location = new System.Drawing.Point(242, 226);
		this.btnRe.Name = "btnRe";
		this.btnRe.Size = new System.Drawing.Size(32, 32);
		this.btnRe.TabIndex = 76;
		this.btnRe.Tag = "44";
		//
		//btnW
		//
		this.btnW.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnW.Image = (System.Drawing.Image)resources.GetObject("btnW.Image");
		this.btnW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnW.Location = new System.Drawing.Point(206, 226);
		this.btnW.Name = "btnW";
		this.btnW.Size = new System.Drawing.Size(32, 32);
		this.btnW.TabIndex = 75;
		this.btnW.Tag = "62";
		//
		//btnTa
		//
		this.btnTa.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnTa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTa.Image = (System.Drawing.Image)resources.GetObject("btnTa.Image");
		this.btnTa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTa.Location = new System.Drawing.Point(170, 226);
		this.btnTa.Name = "btnTa";
		this.btnTa.Size = new System.Drawing.Size(32, 32);
		this.btnTa.TabIndex = 74;
		this.btnTa.Tag = "54";
		//
		//btnHf
		//
		this.btnHf.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnHf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHf.Image = (System.Drawing.Image)resources.GetObject("btnHf.Image");
		this.btnHf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHf.Location = new System.Drawing.Point(134, 226);
		this.btnHf.Name = "btnHf";
		this.btnHf.Size = new System.Drawing.Size(32, 32);
		this.btnHf.TabIndex = 73;
		this.btnHf.Tag = "22";
		//
		//btnLu
		//
		this.btnLu.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnLu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnLu.Image = (System.Drawing.Image)resources.GetObject("btnLu.Image");
		this.btnLu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnLu.Location = new System.Drawing.Point(638, 314);
		this.btnLu.Name = "btnLu";
		this.btnLu.Size = new System.Drawing.Size(32, 32);
		this.btnLu.TabIndex = 72;
		this.btnLu.Tag = "30";
		//
		//btnYb
		//
		this.btnYb.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnYb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnYb.Image = (System.Drawing.Image)resources.GetObject("btnYb.Image");
		this.btnYb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnYb.Location = new System.Drawing.Point(602, 314);
		this.btnYb.Name = "btnYb";
		this.btnYb.Size = new System.Drawing.Size(32, 32);
		this.btnYb.TabIndex = 71;
		this.btnYb.Tag = "64";
		//
		//btnTm
		//
		this.btnTm.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnTm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTm.Image = (System.Drawing.Image)resources.GetObject("btnTm.Image");
		this.btnTm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTm.Location = new System.Drawing.Point(566, 314);
		this.btnTm.Name = "btnTm";
		this.btnTm.Size = new System.Drawing.Size(32, 32);
		this.btnTm.TabIndex = 70;
		this.btnTm.Tag = "59";
		//
		//btnEr
		//
		this.btnEr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnEr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnEr.Image = (System.Drawing.Image)resources.GetObject("btnEr.Image");
		this.btnEr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnEr.Location = new System.Drawing.Point(530, 314);
		this.btnEr.Name = "btnEr";
		this.btnEr.Size = new System.Drawing.Size(32, 32);
		this.btnEr.TabIndex = 69;
		this.btnEr.Tag = "16";
		//
		//btnHo
		//
		this.btnHo.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnHo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnHo.Image = (System.Drawing.Image)resources.GetObject("btnHo.Image");
		this.btnHo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnHo.Location = new System.Drawing.Point(494, 314);
		this.btnHo.Name = "btnHo";
		this.btnHo.Size = new System.Drawing.Size(32, 32);
		this.btnHo.TabIndex = 68;
		this.btnHo.Tag = "24";
		//
		//btnDy
		//
		this.btnDy.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnDy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDy.Image = (System.Drawing.Image)resources.GetObject("btnDy.Image");
		this.btnDy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDy.Location = new System.Drawing.Point(458, 314);
		this.btnDy.Name = "btnDy";
		this.btnDy.Size = new System.Drawing.Size(32, 32);
		this.btnDy.TabIndex = 67;
		this.btnDy.Tag = "15";
		//
		//btnTb
		//
		this.btnTb.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnTb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTb.Image = (System.Drawing.Image)resources.GetObject("btnTb.Image");
		this.btnTb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTb.Location = new System.Drawing.Point(422, 314);
		this.btnTb.Name = "btnTb";
		this.btnTb.Size = new System.Drawing.Size(32, 32);
		this.btnTb.TabIndex = 66;
		this.btnTb.Tag = "55";
		//
		//btnGd
		//
		this.btnGd.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnGd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnGd.Image = (System.Drawing.Image)resources.GetObject("btnGd.Image");
		this.btnGd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnGd.Location = new System.Drawing.Point(386, 314);
		this.btnGd.Name = "btnGd";
		this.btnGd.Size = new System.Drawing.Size(32, 32);
		this.btnGd.TabIndex = 65;
		this.btnGd.Tag = "20";
		//
		//btnEu
		//
		this.btnEu.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnEu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnEu.Image = (System.Drawing.Image)resources.GetObject("btnEu.Image");
		this.btnEu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnEu.Location = new System.Drawing.Point(350, 314);
		this.btnEu.Name = "btnEu";
		this.btnEu.Size = new System.Drawing.Size(32, 32);
		this.btnEu.TabIndex = 64;
		this.btnEu.Tag = "17";
		//
		//btnSm
		//
		this.btnSm.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnSm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSm.Image = (System.Drawing.Image)resources.GetObject("btnSm.Image");
		this.btnSm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSm.Location = new System.Drawing.Point(314, 314);
		this.btnSm.Name = "btnSm";
		this.btnSm.Size = new System.Drawing.Size(32, 32);
		this.btnSm.TabIndex = 63;
		this.btnSm.Tag = "51";
		//
		//btnPm
		//
		this.btnPm.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnPm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPm.Image = (System.Drawing.Image)resources.GetObject("btnPm.Image");
		this.btnPm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPm.Location = new System.Drawing.Point(278, 314);
		this.btnPm.Name = "btnPm";
		this.btnPm.Size = new System.Drawing.Size(32, 32);
		this.btnPm.TabIndex = 62;
		this.btnPm.Tag = "105";
		//
		//btnNd
		//
		this.btnNd.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnNd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNd.Image = (System.Drawing.Image)resources.GetObject("btnNd.Image");
		this.btnNd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNd.Location = new System.Drawing.Point(242, 314);
		this.btnNd.Name = "btnNd";
		this.btnNd.Size = new System.Drawing.Size(32, 32);
		this.btnNd.TabIndex = 61;
		this.btnNd.Tag = "36";
		//
		//btnPr
		//
		this.btnPr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnPr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPr.Image = (System.Drawing.Image)resources.GetObject("btnPr.Image");
		this.btnPr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPr.Location = new System.Drawing.Point(206, 314);
		this.btnPr.Name = "btnPr";
		this.btnPr.Size = new System.Drawing.Size(32, 32);
		this.btnPr.TabIndex = 60;
		this.btnPr.Tag = "41";
		//
		//btnCe
		//
		this.btnCe.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCe.Image = (System.Drawing.Image)resources.GetObject("btnCe.Image");
		this.btnCe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCe.Location = new System.Drawing.Point(170, 314);
		this.btnCe.Name = "btnCe";
		this.btnCe.Size = new System.Drawing.Size(32, 32);
		this.btnCe.TabIndex = 59;
		this.btnCe.Tag = "85";
		//
		//btnLa
		//
		this.btnLa.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnLa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnLa.Image = (System.Drawing.Image)resources.GetObject("btnLa.Image");
		this.btnLa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnLa.Location = new System.Drawing.Point(134, 314);
		this.btnLa.Name = "btnLa";
		this.btnLa.Size = new System.Drawing.Size(32, 32);
		this.btnLa.TabIndex = 58;
		this.btnLa.Tag = "28";
		//
		//btnBa
		//
		this.btnBa.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnBa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnBa.Image = (System.Drawing.Image)resources.GetObject("btnBa.Image");
		this.btnBa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBa.Location = new System.Drawing.Point(62, 226);
		this.btnBa.Name = "btnBa";
		this.btnBa.Size = new System.Drawing.Size(32, 32);
		this.btnBa.TabIndex = 57;
		this.btnBa.Tag = "6";
		//
		//btnCs
		//
		this.btnCs.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCs.Image = (System.Drawing.Image)resources.GetObject("btnCs.Image");
		this.btnCs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCs.Location = new System.Drawing.Point(26, 226);
		this.btnCs.Name = "btnCs";
		this.btnCs.Size = new System.Drawing.Size(32, 32);
		this.btnCs.TabIndex = 56;
		this.btnCs.Tag = "13";
		//
		//btnXe
		//
		this.btnXe.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnXe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnXe.Image = (System.Drawing.Image)resources.GetObject("btnXe.Image");
		this.btnXe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnXe.Location = new System.Drawing.Point(638, 192);
		this.btnXe.Name = "btnXe";
		this.btnXe.Size = new System.Drawing.Size(32, 32);
		this.btnXe.TabIndex = 55;
		this.btnXe.Tag = "81";
		//
		//btnI
		//
		this.btnI.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnI.Image = (System.Drawing.Image)resources.GetObject("btnI.Image");
		this.btnI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnI.Location = new System.Drawing.Point(602, 192);
		this.btnI.Name = "btnI";
		this.btnI.Size = new System.Drawing.Size(32, 32);
		this.btnI.TabIndex = 54;
		this.btnI.Tag = "102";
		//
		//btnTe
		//
		this.btnTe.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnTe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTe.Image = (System.Drawing.Image)resources.GetObject("btnTe.Image");
		this.btnTe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTe.Location = new System.Drawing.Point(566, 192);
		this.btnTe.Name = "btnTe";
		this.btnTe.Size = new System.Drawing.Size(32, 32);
		this.btnTe.TabIndex = 53;
		this.btnTe.Tag = "56";
		//
		//btnSb
		//
		this.btnSb.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnSb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSb.Image = (System.Drawing.Image)resources.GetObject("btnSb.Image");
		this.btnSb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSb.Location = new System.Drawing.Point(530, 192);
		this.btnSb.Name = "btnSb";
		this.btnSb.Size = new System.Drawing.Size(32, 32);
		this.btnSb.TabIndex = 52;
		this.btnSb.Tag = "47";
		//
		//btnSn
		//
		this.btnSn.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnSn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSn.Image = (System.Drawing.Image)resources.GetObject("btnSn.Image");
		this.btnSn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSn.Location = new System.Drawing.Point(494, 192);
		this.btnSn.Name = "btnSn";
		this.btnSn.Size = new System.Drawing.Size(32, 32);
		this.btnSn.TabIndex = 51;
		this.btnSn.Tag = "52";
		//
		//btnIn
		//
		this.btnIn.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIn.Image = (System.Drawing.Image)resources.GetObject("btnIn.Image");
		this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIn.Location = new System.Drawing.Point(458, 192);
		this.btnIn.Name = "btnIn";
		this.btnIn.Size = new System.Drawing.Size(32, 32);
		this.btnIn.TabIndex = 50;
		this.btnIn.Tag = "25";
		//
		//btnCd
		//
		this.btnCd.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCd.Image = (System.Drawing.Image)resources.GetObject("btnCd.Image");
		this.btnCd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCd.Location = new System.Drawing.Point(422, 192);
		this.btnCd.Name = "btnCd";
		this.btnCd.Size = new System.Drawing.Size(32, 32);
		this.btnCd.TabIndex = 49;
		this.btnCd.Tag = "10";
		//
		//btnAg
		//
		this.btnAg.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnAg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAg.Image = (System.Drawing.Image)resources.GetObject("btnAg.Image");
		this.btnAg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAg.Location = new System.Drawing.Point(386, 192);
		this.btnAg.Name = "btnAg";
		this.btnAg.Size = new System.Drawing.Size(32, 32);
		this.btnAg.TabIndex = 48;
		this.btnAg.Tag = "1";
		//
		//btnPd
		//
		this.btnPd.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnPd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPd.Image = (System.Drawing.Image)resources.GetObject("btnPd.Image");
		this.btnPd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPd.Location = new System.Drawing.Point(350, 192);
		this.btnPd.Name = "btnPd";
		this.btnPd.Size = new System.Drawing.Size(32, 32);
		this.btnPd.TabIndex = 47;
		this.btnPd.Tag = "40";
		//
		//btnRh
		//
		this.btnRh.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnRh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRh.Image = (System.Drawing.Image)resources.GetObject("btnRh.Image");
		this.btnRh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRh.Location = new System.Drawing.Point(314, 192);
		this.btnRh.Name = "btnRh";
		this.btnRh.Size = new System.Drawing.Size(32, 32);
		this.btnRh.TabIndex = 46;
		this.btnRh.Tag = "45";
		//
		//btnRu
		//
		this.btnRu.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnRu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRu.Image = (System.Drawing.Image)resources.GetObject("btnRu.Image");
		this.btnRu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRu.Location = new System.Drawing.Point(278, 192);
		this.btnRu.Name = "btnRu";
		this.btnRu.Size = new System.Drawing.Size(32, 32);
		this.btnRu.TabIndex = 45;
		this.btnRu.Tag = "46";
		//
		//btnTc
		//
		this.btnTc.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnTc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTc.Image = (System.Drawing.Image)resources.GetObject("btnTc.Image");
		this.btnTc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTc.Location = new System.Drawing.Point(242, 192);
		this.btnTc.Name = "btnTc";
		this.btnTc.Size = new System.Drawing.Size(32, 32);
		this.btnTc.TabIndex = 44;
		this.btnTc.Tag = "109";
		//
		//btnMo
		//
		this.btnMo.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnMo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnMo.Image = (System.Drawing.Image)resources.GetObject("btnMo.Image");
		this.btnMo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnMo.Location = new System.Drawing.Point(206, 192);
		this.btnMo.Name = "btnMo";
		this.btnMo.Size = new System.Drawing.Size(32, 32);
		this.btnMo.TabIndex = 43;
		this.btnMo.Tag = "33";
		//
		//btnNb
		//
		this.btnNb.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnNb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNb.Image = (System.Drawing.Image)resources.GetObject("btnNb.Image");
		this.btnNb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNb.Location = new System.Drawing.Point(170, 192);
		this.btnNb.Name = "btnNb";
		this.btnNb.Size = new System.Drawing.Size(32, 32);
		this.btnNb.TabIndex = 42;
		this.btnNb.Tag = "35";
		//
		//btnZr
		//
		this.btnZr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnZr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnZr.Image = (System.Drawing.Image)resources.GetObject("btnZr.Image");
		this.btnZr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnZr.Location = new System.Drawing.Point(134, 192);
		this.btnZr.Name = "btnZr";
		this.btnZr.Size = new System.Drawing.Size(32, 32);
		this.btnZr.TabIndex = 41;
		this.btnZr.Tag = "66";
		//
		//btnY
		//
		this.btnY.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnY.Image = (System.Drawing.Image)resources.GetObject("btnY.Image");
		this.btnY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnY.Location = new System.Drawing.Point(98, 192);
		this.btnY.Name = "btnY";
		this.btnY.Size = new System.Drawing.Size(32, 32);
		this.btnY.TabIndex = 40;
		this.btnY.Tag = "63";
		//
		//btnSr
		//
		this.btnSr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnSr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSr.Image = (System.Drawing.Image)resources.GetObject("btnSr.Image");
		this.btnSr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSr.Location = new System.Drawing.Point(62, 192);
		this.btnSr.Name = "btnSr";
		this.btnSr.Size = new System.Drawing.Size(32, 32);
		this.btnSr.TabIndex = 39;
		this.btnSr.Tag = "53";
		//
		//btnRb
		//
		this.btnRb.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnRb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnRb.Image = (System.Drawing.Image)resources.GetObject("btnRb.Image");
		this.btnRb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRb.Location = new System.Drawing.Point(26, 192);
		this.btnRb.Name = "btnRb";
		this.btnRb.Size = new System.Drawing.Size(32, 32);
		this.btnRb.TabIndex = 38;
		this.btnRb.Tag = "43";
		//
		//btnKr
		//
		this.btnKr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnKr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnKr.Image = (System.Drawing.Image)resources.GetObject("btnKr.Image");
		this.btnKr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnKr.Location = new System.Drawing.Point(638, 158);
		this.btnKr.Name = "btnKr";
		this.btnKr.Size = new System.Drawing.Size(32, 32);
		this.btnKr.TabIndex = 37;
		this.btnKr.Tag = "80";
		//
		//btnBr
		//
		this.btnBr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnBr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnBr.Image = (System.Drawing.Image)resources.GetObject("btnBr.Image");
		this.btnBr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBr.Location = new System.Drawing.Point(602, 158);
		this.btnBr.Name = "btnBr";
		this.btnBr.Size = new System.Drawing.Size(32, 32);
		this.btnBr.TabIndex = 36;
		this.btnBr.Tag = "101";
		//
		//btnSe
		//
		this.btnSe.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnSe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSe.Image = (System.Drawing.Image)resources.GetObject("btnSe.Image");
		this.btnSe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSe.Location = new System.Drawing.Point(566, 158);
		this.btnSe.Name = "btnSe";
		this.btnSe.Size = new System.Drawing.Size(32, 32);
		this.btnSe.TabIndex = 35;
		this.btnSe.Tag = "49";
		//
		//btnAs
		//
		this.btnAs.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAs.Image = (System.Drawing.Image)resources.GetObject("btnAs.Image");
		this.btnAs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAs.Location = new System.Drawing.Point(530, 158);
		this.btnAs.Name = "btnAs";
		this.btnAs.Size = new System.Drawing.Size(32, 32);
		this.btnAs.TabIndex = 34;
		this.btnAs.Tag = "3";
		//
		//btnGe
		//
		this.btnGe.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnGe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnGe.Image = (System.Drawing.Image)resources.GetObject("btnGe.Image");
		this.btnGe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnGe.Location = new System.Drawing.Point(494, 158);
		this.btnGe.Name = "btnGe";
		this.btnGe.Size = new System.Drawing.Size(32, 32);
		this.btnGe.TabIndex = 33;
		this.btnGe.Tag = "21";
		//
		//btnGa
		//
		this.btnGa.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnGa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnGa.Image = (System.Drawing.Image)resources.GetObject("btnGa.Image");
		this.btnGa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnGa.Location = new System.Drawing.Point(458, 158);
		this.btnGa.Name = "btnGa";
		this.btnGa.Size = new System.Drawing.Size(32, 32);
		this.btnGa.TabIndex = 32;
		this.btnGa.Tag = "19";
		//
		//btnZn
		//
		this.btnZn.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnZn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnZn.Image = (System.Drawing.Image)resources.GetObject("btnZn.Image");
		this.btnZn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnZn.Location = new System.Drawing.Point(422, 158);
		this.btnZn.Name = "btnZn";
		this.btnZn.Size = new System.Drawing.Size(32, 32);
		this.btnZn.TabIndex = 31;
		this.btnZn.Tag = "65";
		//
		//btnCu
		//
		this.btnCu.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCu.Image = (System.Drawing.Image)resources.GetObject("btnCu.Image");
		this.btnCu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCu.Location = new System.Drawing.Point(386, 158);
		this.btnCu.Name = "btnCu";
		this.btnCu.Size = new System.Drawing.Size(32, 32);
		this.btnCu.TabIndex = 30;
		this.btnCu.Tag = "14";
		//
		//btnNi
		//
		this.btnNi.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnNi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNi.Image = (System.Drawing.Image)resources.GetObject("btnNi.Image");
		this.btnNi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNi.Location = new System.Drawing.Point(350, 158);
		this.btnNi.Name = "btnNi";
		this.btnNi.Size = new System.Drawing.Size(32, 32);
		this.btnNi.TabIndex = 29;
		this.btnNi.Tag = "37";
		//
		//btnCo
		//
		this.btnCo.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCo.Image = (System.Drawing.Image)resources.GetObject("btnCo.Image");
		this.btnCo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCo.Location = new System.Drawing.Point(314, 158);
		this.btnCo.Name = "btnCo";
		this.btnCo.Size = new System.Drawing.Size(32, 32);
		this.btnCo.TabIndex = 28;
		this.btnCo.Tag = "11";
		//
		//btnFe
		//
		this.btnFe.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnFe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnFe.Image = (System.Drawing.Image)resources.GetObject("btnFe.Image");
		this.btnFe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnFe.Location = new System.Drawing.Point(278, 158);
		this.btnFe.Name = "btnFe";
		this.btnFe.Size = new System.Drawing.Size(32, 32);
		this.btnFe.TabIndex = 27;
		this.btnFe.Tag = "18";
		//
		//btnMn
		//
		this.btnMn.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnMn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnMn.Image = (System.Drawing.Image)resources.GetObject("btnMn.Image");
		this.btnMn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnMn.Location = new System.Drawing.Point(242, 158);
		this.btnMn.Name = "btnMn";
		this.btnMn.Size = new System.Drawing.Size(32, 32);
		this.btnMn.TabIndex = 26;
		this.btnMn.Tag = "32";
		//
		//btnCr
		//
		this.btnCr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCr.Image = (System.Drawing.Image)resources.GetObject("btnCr.Image");
		this.btnCr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCr.Location = new System.Drawing.Point(206, 158);
		this.btnCr.Name = "btnCr";
		this.btnCr.Size = new System.Drawing.Size(32, 32);
		this.btnCr.TabIndex = 25;
		this.btnCr.Tag = "12";
		//
		//btnV
		//
		this.btnV.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnV.Image = (System.Drawing.Image)resources.GetObject("btnV.Image");
		this.btnV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnV.Location = new System.Drawing.Point(170, 158);
		this.btnV.Name = "btnV";
		this.btnV.Size = new System.Drawing.Size(32, 32);
		this.btnV.TabIndex = 24;
		this.btnV.Tag = "61";
		//
		//btnTi
		//
		this.btnTi.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnTi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTi.Image = (System.Drawing.Image)resources.GetObject("btnTi.Image");
		this.btnTi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnTi.Location = new System.Drawing.Point(134, 158);
		this.btnTi.Name = "btnTi";
		this.btnTi.Size = new System.Drawing.Size(32, 32);
		this.btnTi.TabIndex = 23;
		this.btnTi.Tag = "57";
		//
		//btnSc
		//
		this.btnSc.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnSc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSc.Image = (System.Drawing.Image)resources.GetObject("btnSc.Image");
		this.btnSc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSc.Location = new System.Drawing.Point(98, 158);
		this.btnSc.Name = "btnSc";
		this.btnSc.Size = new System.Drawing.Size(32, 32);
		this.btnSc.TabIndex = 22;
		this.btnSc.Tag = "48";
		//
		//btnCa
		//
		this.btnCa.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCa.Image = (System.Drawing.Image)resources.GetObject("btnCa.Image");
		this.btnCa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCa.Location = new System.Drawing.Point(62, 158);
		this.btnCa.Name = "btnCa";
		this.btnCa.Size = new System.Drawing.Size(32, 32);
		this.btnCa.TabIndex = 21;
		this.btnCa.Tag = "9";
		//
		//btnK
		//
		this.btnK.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnK.Image = (System.Drawing.Image)resources.GetObject("btnK.Image");
		this.btnK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnK.Location = new System.Drawing.Point(26, 158);
		this.btnK.Name = "btnK";
		this.btnK.Size = new System.Drawing.Size(32, 32);
		this.btnK.TabIndex = 20;
		this.btnK.Tag = "27";
		//
		//btnAr
		//
		this.btnAr.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnAr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAr.Image = (System.Drawing.Image)resources.GetObject("btnAr.Image");
		this.btnAr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAr.Location = new System.Drawing.Point(638, 124);
		this.btnAr.Name = "btnAr";
		this.btnAr.Size = new System.Drawing.Size(32, 32);
		this.btnAr.TabIndex = 19;
		this.btnAr.Tag = "79";
		//
		//btnCl
		//
		this.btnCl.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnCl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCl.Image = (System.Drawing.Image)resources.GetObject("btnCl.Image");
		this.btnCl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCl.Location = new System.Drawing.Point(602, 124);
		this.btnCl.Name = "btnCl";
		this.btnCl.Size = new System.Drawing.Size(32, 32);
		this.btnCl.TabIndex = 18;
		this.btnCl.Tag = "78";
		//
		//btnS
		//
		this.btnS.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnS.Image = (System.Drawing.Image)resources.GetObject("btnS.Image");
		this.btnS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnS.Location = new System.Drawing.Point(566, 124);
		this.btnS.Name = "btnS";
		this.btnS.Size = new System.Drawing.Size(32, 32);
		this.btnS.TabIndex = 17;
		this.btnS.Tag = "108";
		//
		//btnP
		//
		this.btnP.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnP.Image = (System.Drawing.Image)resources.GetObject("btnP.Image");
		this.btnP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnP.Location = new System.Drawing.Point(530, 124);
		this.btnP.Name = "btnP";
		this.btnP.Size = new System.Drawing.Size(32, 32);
		this.btnP.TabIndex = 16;
		this.btnP.Tag = "104";
		//
		//btnSi
		//
		this.btnSi.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSi.Image = (System.Drawing.Image)resources.GetObject("btnSi.Image");
		this.btnSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSi.Location = new System.Drawing.Point(494, 124);
		this.btnSi.Name = "btnSi";
		this.btnSi.Size = new System.Drawing.Size(32, 32);
		this.btnSi.TabIndex = 15;
		this.btnSi.Tag = "50";
		//
		//btnAl
		//
		this.btnAl.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAl.Image = (System.Drawing.Image)resources.GetObject("btnAl.Image");
		this.btnAl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnAl.Location = new System.Drawing.Point(458, 124);
		this.btnAl.Name = "btnAl";
		this.btnAl.Size = new System.Drawing.Size(32, 32);
		this.btnAl.TabIndex = 14;
		this.btnAl.Tag = "2";
		//
		//btnMg
		//
		this.btnMg.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnMg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnMg.Image = (System.Drawing.Image)resources.GetObject("btnMg.Image");
		this.btnMg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnMg.Location = new System.Drawing.Point(62, 124);
		this.btnMg.Name = "btnMg";
		this.btnMg.Size = new System.Drawing.Size(32, 32);
		this.btnMg.TabIndex = 13;
		this.btnMg.Tag = "31";
		//
		//btnNa
		//
		this.btnNa.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnNa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNa.Image = (System.Drawing.Image)resources.GetObject("btnNa.Image");
		this.btnNa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNa.Location = new System.Drawing.Point(26, 124);
		this.btnNa.Name = "btnNa";
		this.btnNa.Size = new System.Drawing.Size(32, 32);
		this.btnNa.TabIndex = 12;
		this.btnNa.Tag = "34";
		//
		//btnNe
		//
		this.btnNe.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnNe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNe.Image = (System.Drawing.Image)resources.GetObject("btnNe.Image");
		this.btnNe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNe.Location = new System.Drawing.Point(638, 90);
		this.btnNe.Name = "btnNe";
		this.btnNe.Size = new System.Drawing.Size(32, 32);
		this.btnNe.TabIndex = 11;
		this.btnNe.Tag = "77";
		//
		//btnF
		//
		this.btnF.BackColor = System.Drawing.Color.Gold;
		this.btnF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnF.Image = (System.Drawing.Image)resources.GetObject("btnF.Image");
		this.btnF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnF.Location = new System.Drawing.Point(602, 90);
		this.btnF.Name = "btnF";
		this.btnF.Size = new System.Drawing.Size(32, 32);
		this.btnF.TabIndex = 10;
		this.btnF.Tag = "76";
		//
		//btnO
		//
		this.btnO.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnO.Image = (System.Drawing.Image)resources.GetObject("btnO.Image");
		this.btnO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnO.Location = new System.Drawing.Point(566, 90);
		this.btnO.Name = "btnO";
		this.btnO.Size = new System.Drawing.Size(32, 32);
		this.btnO.TabIndex = 9;
		this.btnO.Tag = "75";
		//
		//btnN
		//
		this.btnN.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnN.Image = (System.Drawing.Image)resources.GetObject("btnN.Image");
		this.btnN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnN.Location = new System.Drawing.Point(530, 90);
		this.btnN.Name = "btnN";
		this.btnN.Size = new System.Drawing.Size(32, 32);
		this.btnN.TabIndex = 8;
		this.btnN.Tag = "74";
		//
		//btnC
		//
		this.btnC.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnC.Image = (System.Drawing.Image)resources.GetObject("btnC.Image");
		this.btnC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnC.Location = new System.Drawing.Point(494, 90);
		this.btnC.Name = "btnC";
		this.btnC.Size = new System.Drawing.Size(32, 32);
		this.btnC.TabIndex = 7;
		this.btnC.Tag = "73";
		//
		//btnB
		//
		this.btnB.BackColor = System.Drawing.Color.AliceBlue;
		this.btnB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnB.Image = (System.Drawing.Image)resources.GetObject("btnB.Image");
		this.btnB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnB.Location = new System.Drawing.Point(458, 90);
		this.btnB.Name = "btnB";
		this.btnB.Size = new System.Drawing.Size(32, 32);
		this.btnB.TabIndex = 5;
		this.btnB.Tag = "5";
		//
		//btnBe
		//
		this.btnBe.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnBe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnBe.Image = (System.Drawing.Image)resources.GetObject("btnBe.Image");
		this.btnBe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBe.Location = new System.Drawing.Point(62, 90);
		this.btnBe.Name = "btnBe";
		this.btnBe.Size = new System.Drawing.Size(32, 32);
		this.btnBe.TabIndex = 4;
		this.btnBe.Tag = "7";
		//
		//btnLi
		//
		this.btnLi.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnLi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnLi.Image = (System.Drawing.Image)resources.GetObject("btnLi.Image");
		this.btnLi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnLi.Location = new System.Drawing.Point(26, 90);
		this.btnLi.Name = "btnLi";
		this.btnLi.Size = new System.Drawing.Size(32, 32);
		this.btnLi.TabIndex = 3;
		this.btnLi.Tag = "29";
		//
		//btnH
		//
		this.btnH.BackColor = System.Drawing.Color.DarkKhaki;
		this.btnH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnH.Image = (System.Drawing.Image)resources.GetObject("btnH.Image");
		this.btnH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnH.Location = new System.Drawing.Point(638, 56);
		this.btnH.Name = "btnH";
		this.btnH.Size = new System.Drawing.Size(32, 32);
		this.btnH.TabIndex = 2;
		this.btnH.Tag = "72";
		//
		//StatusBar1
		//
		this.StatusBar1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.StatusBar1.Location = new System.Drawing.Point(0, 471);
		this.StatusBar1.Name = "StatusBar1";
		this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] { this.StatusBarPanelInfo });
		this.StatusBar1.ShowPanels = true;
		this.StatusBar1.Size = new System.Drawing.Size(700, 20);
		this.StatusBar1.TabIndex = 1;
		//
		//StatusBarPanelInfo
		//
		this.StatusBarPanelInfo.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
		this.StatusBarPanelInfo.Width = 500;
		//
		//frmCookBook
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BackColor = System.Drawing.Color.AliceBlue;
		this.ClientSize = new System.Drawing.Size(700, 491);
		this.Controls.Add(this.StatusBar1);
		this.Controls.Add(this.CustomPanelMain);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmCookBook";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Periodic Chart Of The Elements";
		this.CustomPanelMain.ResumeLayout(false);
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.GroupBoxMultielementLamps.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.StatusBarPanelInfo).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region "Private Variables"
	private int mintElementID = 0;
		#End Region
	private bool mblnAvoidProcessing = false;

	#Region "Properties"
	public int ElementID {
		//'this is used to set and get a element ID
		get { return mintElementID; }
		set { mintElementID = Value; }
	}
	#End Region

	#Region "Form Events"

	private void  // ERROR: Handles clauses are not supported in C#
frmCookBook_Load(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmCookBook_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To Load cook-book 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		DataTable DtCookBook;
		int intCtrlCount;
		ToolTip ToolTip1;
		DataTable dtToolTipCookBook;
		string strToolTip;
		try {
			if (gstructSettings.AppMode == EnumAppMode.FullVersion_201) {
				//'check for 201
				btnIgnite.Enabled = false;
				btnExtinguish.Enabled = false;
			}

			btnCancel.BringToFront();
			//---get cook book data
			DtCookBook = gobjDataAccess.GetCookBookData();
			//---set element names to combobox.
			if (!DtCookBook == null) {
				cmbSelectElement.DataSource = DtCookBook;
				cmbSelectElement.ValueMember = DtCookBook.Columns(ConstColumnElementID).ColumnName;
				cmbSelectElement.DisplayMember = DtCookBook.Columns(ConstColumnElementName).ColumnName;
				//'show the value from DtCookBook  object to screen 
			}
			AddHandlers();
			//'for adding a event to a control

			//---add handlers for mouse hover to display tooltip
			for (intCtrlCount = 0; intCtrlCount <= this.CustomPanelMain.Controls.Count - 1; intCtrlCount++) {
				if (this.CustomPanelMain.Controls(intCtrlCount) is NETXP.Controls.XPButton) {
					if (this.CustomPanelMain.Controls(intCtrlCount).Tag != null) {
						this.CustomPanelMain.Controls(intCtrlCount).MouseHover += SubGetWavelength;
						this.CustomPanelMain.Controls(intCtrlCount).MouseLeave += SubSetBlank;
					}
				}
			}

			//---add tool tips for all elements
			for (intCtrlCount = 0; intCtrlCount <= this.CustomPanelMain.Controls.Count - 1; intCtrlCount++) {
				if (this.CustomPanelMain.Controls(intCtrlCount) is NETXP.Controls.XPButton) {
					if (this.CustomPanelMain.Controls(intCtrlCount).Tag != null) {
						((NETXP.Controls.XPButton)this.CustomPanelMain.Controls(intCtrlCount)).ImageAlign = ContentAlignment.MiddleCenter;
						if (((NETXP.Controls.XPButton)this.CustomPanelMain.Controls(intCtrlCount)).Tag > 0 & ((NETXP.Controls.XPButton)this.CustomPanelMain.Controls(intCtrlCount)).Tag < 110) {
							ToolTip1 = new ToolTip();
							dtToolTipCookBook = gobjClsAAS203.funcGetElement_AtomicNo(((NETXP.Controls.XPButton)this.CustomPanelMain.Controls(intCtrlCount)).Tag);
							if (dtToolTipCookBook.Rows(0).Item(4) == 0) {
								strToolTip = "Element:" + dtToolTipCookBook.Rows(0).Item(2) + "(" + dtToolTipCookBook.Rows(0).Item(1) + ")" + " Atomic No.:" + dtToolTipCookBook.Rows(0).Item(3) + " Flame Type: AA Flame ";
								//& dtToolTipCookBook.Rows(0).Item(3)
							} else if (dtToolTipCookBook.Rows(0).Item(4) == -1) {
								strToolTip = "Element:" + dtToolTipCookBook.Rows(0).Item(2) + "(" + dtToolTipCookBook.Rows(0).Item(1) + ")" + " Atomic No.:" + dtToolTipCookBook.Rows(0).Item(3) + " Flame Type: NA Flame ";
								//& dtToolTipCookBook.Rows(0).Item(3)
							} else {
								strToolTip = "Element:" + dtToolTipCookBook.Rows(0).Item(2) + "(" + dtToolTipCookBook.Rows(0).Item(1) + ")" + " Atomic No.:" + dtToolTipCookBook.Rows(0).Item(3);
								//& " Flame Type: NA Flame " '& dtToolTipCookBook.Rows(0).Item(3)
							}
							ToolTip1.SetToolTip(this.CustomPanelMain.Controls(intCtrlCount), strToolTip);
						}
					}
				}
			}
			btnBlank.ImageAlign = ContentAlignment.MiddleCenter;
			ToolTip1.SetToolTip(btnBlank, "Element: Blank Atomic No.: 106");
			btnCuZn.ImageAlign = ContentAlignment.MiddleCenter;
			ToolTip1.SetToolTip(btnCuZn, "Element: Cu-Zn Flame Type: AA Flame");
			btnCaMg.ImageAlign = ContentAlignment.MiddleCenter;
			ToolTip1.SetToolTip(btnCaMg, "Element: Ca-Mg Flame Type: NA/AA Flame");
			btnNaK.ImageAlign = ContentAlignment.MiddleCenter;
			ToolTip1.SetToolTip(btnNaK, "Element: Na-K Flame Type: AA Flame");
			btnCrCoCuFeMnNi.ImageAlign = ContentAlignment.MiddleCenter;
			ToolTip1.SetToolTip(btnCrCoCuFeMnNi, "Element: Cr-Co-Cu-Fe-Mn-Mi Flame Type: AA Flame");
		//-------------------------------------------------------------


		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

	#Region "Private Functions"

	private void AddHandlers()
	{
		//=====================================================================
		// Procedure Name        : AddHandlers
		// Parameters Passed     : None
		// Returns               : None
		// Purpose               : To Add event handlers
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		int intCtrlCount;
		try {
			//---add handlers for all elements
			for (intCtrlCount = 0; intCtrlCount <= this.CustomPanelMain.Controls.Count - 1; intCtrlCount++) {
				if (this.CustomPanelMain.Controls(intCtrlCount) is NETXP.Controls.XPButton) {
					if (this.CustomPanelMain.Controls(intCtrlCount).Tag != null) {
						this.CustomPanelMain.Controls(intCtrlCount).Click += SubGetElement;
					}
				}
			}
			for (intCtrlCount = 0; intCtrlCount <= this.GroupBoxMultielementLamps.Controls.Count - 1; intCtrlCount++) {
				if (this.GroupBoxMultielementLamps.Controls(intCtrlCount) is NETXP.Controls.XPButton) {
					if (this.GroupBoxMultielementLamps.Controls(intCtrlCount).Tag != null) {
						this.GroupBoxMultielementLamps.Controls(intCtrlCount).Click += SubGetElement;
					}
				}
			}
			btnCancel.Click += btnCancel_Click;
			btnDelete.Click += btnDelete_Click;
			btnR.Click += btnR_Click;
			//'this will add a handler to cancel button click.
			cmbSelectElement.SelectedIndexChanged += cmbSelectElement_SelectedIndexChanged;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void btnCancel_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnCancel_Click
		// Parameters Passed     : sender,EventArgs
		// Returns               : None
		// Purpose               : To close the control
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			//---to close the form
			this.Close();
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void SubSetBlank(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : SubSetBlank
		// Parameters Passed     : sender,EventArgs
		// Returns               : None
		// Purpose               : set blank message for progress bar
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//note:
		//'---to set blank message for progress bar
		string strBlank = "";
		ShowProgressBar(strBlank);
	}

	private void SubGetWavelength(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : SubGetWavelength
		// Parameters Passed     : sender,EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : To display wavelengths on progress bar
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saurabh S
		// Created               : 06.08.07
		// Revisions             : 
		//=====================================================================
		DataTable DtCookBook;
		DataTable DtElementWavelengths;
		clsPrintDocument objclsPrintDocument;
		int intCount;
		string strWv = "";
		string strElement;
		try {
			//---get element id
			ElementID = (int)((NETXP.Controls.XPButton)sender).Tag;

			//--- get wavelengths of that element
			DtElementWavelengths = gobjDataAccess.GetElementWavelengths(ElementID);

			DtCookBook = gobjDataAccess.GetCookBookData(ElementID);
			strElement = DtCookBook.Rows(0).Item(1) + DtCookBook.Rows(0).Item(2) + " : (" + DtCookBook.Rows(0).Item(7) + ")";
			if (!IsNothing(DtElementWavelengths)) {
				for (intCount = 0; intCount <= DtElementWavelengths.Rows.Count - 1; intCount++) {
					strWv = strWv + ", " + DtElementWavelengths.Rows(intCount).Item(2);
				}
			} else {
				strWv = " - Not used in Atomic Absorption";
			}
			//---display it on progress bar
			ShowProgressBar(strElement + strWv);
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void SubGetElement(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : SubGetElement
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the selected element id to property
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		DataTable DtCookBook;
		DataTable DtElementWavelengths;
		clsPrintDocument objclsPrintDocument;
		try {
			ElementID = (int)((NETXP.Controls.XPButton)sender).Tag;
			//get a element ID as per button tag on a cook book.
			if (gblnCookBookReport == true) {
				//---for cook book report print
				if (funcCookBookPrint() == true) {
					//---for printing a cookbokk report.
				}
			//Saurabh 28 May 2007
			} else if (ElementID > 70) {
				//' 18.04.11 for version 5.0
				if (ElementID == 104) {
					this.DialogResult = DialogResult.OK;
				} else {
					return;
				}
			//' 18.04.11


			//'element id cond
			//'Exit Sub  'commented on 18.04.11 for version 5.0
			//Saurabh 28 May 2007
			} else {
				this.DialogResult = DialogResult.OK;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private bool funcCookBookPrint()
	{
		//=====================================================================
		// Procedure Name        : funcCookBookPrint
		// Parameters Passed     : None
		// Returns               : BOOL True if success
		// Purpose               : To print the report of selected Element characteristics
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================

		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		DataTable objDtImagesList = new DataTable();
		ArrayList arrGraphControlsList = new ArrayList();
		clsReportingMode.structReportFormat objstructReportFormatIn = new clsReportingMode.structReportFormat();
		//Dim strPageHeader As String = ""    '" Test Page Header "
		clsPrintDocument.struHeaderString strPageHeader = new clsPrintDocument.struHeaderString();
		// = ""    '" Test Page Header "
		string strPageText = " Test Page Text ";
		ArrayList objarrMoreTabularData = new ArrayList();
		DataTable DtCookBook;
		DataTable DtElementWavelengths;

		try {
			//--- Set print report object
			//--- "ElementID" holds the Element ID 
			strPageHeader.TextString = "";
			strPageHeader.TextFormat = new clsReportHeaderFormat();
			strPageHeader.TextFormat.Alignment = ContentAlignment.MiddleCenter;
			//--- get the Element details info. from CookBook 
			DtCookBook = gobjDataAccess.GetCookBookData(ElementID);
			//---- Get the Element Wavelengths detals into data table
			DtElementWavelengths = gobjDataAccess.GetElementWavelengths(ElementID);
			if ((IsNothing(DtElementWavelengths))) {
				objclsPrintDocument = null;
				return false;
			}
			//--- Set print report object parameters
			objstructReportFormatIn.PageBottomMargin = 0.5;
			objstructReportFormatIn.PageLeftMargin = 0.5;
			objstructReportFormatIn.PageTopMargin = 0.5;
			//--- Set the report details (data tables, array list) to print report object
			objclsPrintDocument = funcSetPrintDocument(objstructReportFormatIn, strPageHeader, strPageText, arrGraphControlsList, objarrMoreTabularData, objDtImagesList, DtCookBook, DtElementWavelengths, clsPrintDocument.enumReportType.CookBook);
			//---- Show report on print preview
			if (!IsNothing(objclsPrintDocument) == true) {
				if (objclsPrintDocument.PrintPreview() == true) {
					objclsPrintDocument.Dispose();
					objclsPrintDocument = null;
				}
			}
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			return false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private clsPrintDocument funcSetPrintDocument(clsReportingMode.structReportFormat objstructReportFormatIn, clsPrintDocument.struHeaderString strPageHeaderIn, string strPageTextIn, ArrayList arrGraphControlsListIn, ArrayList arrDtTablesListIn, DataTable objDtImagesListIn, DataTable DtCookBook, DataTable DtElementWavelengths, clsPrintDocument.enumReportType intReportTypeIn)
	{
		//=====================================================================
		// Procedure Name        : funcSetPrintDocument
		// Parameters Passed     : objstructReportFormatIn,strPageHeaderIn,strPageTextIn,
		//                         arrGraphControlsListIn,objDtImagesListIn,DtCookBook,DtElementWavelengths
		//                         intReportTypeIn as enumReportType
		// Returns               : clsPrintDocument as print object
		// Purpose               : To set the clsPrintDocument object
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Monday, January 31, 2005
		// Revisions             : 1
		//=====================================================================
		int intCount;
		DataTable objDtTable2In;
		clsPrintDocument objclsPrintDocument = new clsPrintDocument();
		System.Drawing.Font FontStyles = this.DefaultFont;
		DataTable objDtElements;

		try {
			//objstructReportFormatIn.IsDisplayCompanyLogo = gobjNewMethod.ReportParameters.IsLogo
			//objstructReportFormatIn.IsDisplayReportDate = gobjNewMethod.ReportParameters.IsDate
			//objstructReportFormatIn.IsDisplayReportFooter = gobjNewMethod.ReportParameters.IsReportFooter
			//
			//objstructReportFormatIn.IsDisplayReport = gobjNewMethod.ReportParameters.IsReportFooter
			////----- commented by Sachin Dokhale as per Requirement
			//objstructReportFormatIn.IsDisplaySecondReportTitle = True
			//objstructReportFormatIn.IsDisplaySubsequentPageHeader = True

			objstructReportFormatIn.IsDisplayReportTitle = false;
			objstructReportFormatIn.IsDisplayReportHeader = false;
			objstructReportFormatIn.IsDisplayCompanyLogo = false;
			objstructReportFormatIn.LogoAlignment = Left;
			objstructReportFormatIn.LogoFileName = Application.StartupPath + "\\" + "CHEMITO.BMP";
			//"D:\ALDYS\AAS 203 Borland Windows SW\win203.5\BMP\BMP\CHEMITO.BMP"

			//'objstructReportFormatIn.PageBottomMargin = gobjNewMethod.ReportParameters.BottomMargin   '0.5
			//'objstructReportFormatIn.PageLeftMargin = gobjNewMethod.ReportParameters.LeftMargin    '0.32
			//'objstructReportFormatIn.PageTopMargin = gobjNewMethod.ReportParameters.TopMargin     '1
			//'gobjNewMethod.ReportParameters.


			objclsPrintDocument.ReportFormat = objstructReportFormatIn;
			objclsPrintDocument.PageHeader = strPageHeaderIn;

			//objclsPrintDocument.PageHeader = gobjNewMethod.ReportParameters.ReportHeader
			// = gobjNewMethod.ReportParameters.ReportFooter 

			objclsPrintDocument.PageText = strPageTextIn;
			objclsPrintDocument.DisplayFont = this.DefaultFont;
			objclsPrintDocument.TableHeaderFont = FontStyles;
			objclsPrintDocument.ReportImageList = objDtImagesListIn;
			objclsPrintDocument.ReportType = intReportTypeIn;
			objclsPrintDocument.ReportLayoutType = clsPrintDocument.enumReportLayoutType.Portrate;
			objclsPrintDocument.PageSetting = gobjPageSetting;
			objclsPrintDocument.SetTableColoumnFormat = false;
			//'---Set Property ReportDataTables

			//---Set Property ReportGraphControls
			if (IsNothing(arrGraphControlsListIn) == false) {
				objclsPrintDocument.ReportGraphControls = new ArrayList();
				for (intCount = 0; intCount <= arrGraphControlsListIn.Count - 1; intCount++) {
					if (IsNothing(arrGraphControlsListIn.Item(intCount)) == false) {
						objclsPrintDocument.ReportGraphControls.Add(arrGraphControlsListIn.Item(intCount));
					}
				}
			}

			if (!DtCookBook == null) {
				objclsPrintDocument.ElamentInfo = new ArrayList();
				objclsPrintDocument.ElamentInfo.Add(DtCookBook);
			}

			////----- Set Caption for Coloumn Header
			DtElementWavelengths.Columns.Item("WV").Caption = "Wavelength";
			DtElementWavelengths.Columns.Item("SLIT").Caption = "Spectral Bandpass";
			DtElementWavelengths.Columns.Item("WORK_RANGE").Caption = "Optimium Working Range";
			////----- Remove index field from table
			DtElementWavelengths.Columns.Remove("ELE_ID");
			////-----


			if (!DtElementWavelengths == null) {
				objclsPrintDocument.ElamentInfo.Add(DtElementWavelengths);

			}

			//---Set Property ReportDataTables
			objclsPrintDocument.ReportDataTables = new ArrayList();
			if (!DtElementWavelengths == null) {
				objDtElements = new DataTable();
				DataRow dtRow;
				DataColumn DtCol01 = new DataColumn("Col01", typeof(string));
				DataColumn DtCol02 = new DataColumn("Col02", typeof(string));
				DataColumn DtCol03 = new DataColumn("Col03", typeof(string));
				objDtElements.Columns.Add(DtCol01);
				objDtElements.Columns.Item(0).Caption = "Wavelength (nm)";

				objDtElements.Columns.Add(DtCol02);
				objDtElements.Columns.Item(1).Caption = "Spectral Bandpass(nm)";


				objDtElements.Columns.Add(DtCol03);
				objDtElements.Columns.Item(2).Caption = "Optimium Working Range(ppm)";
				int intRowCount;
				intRowCount = 0;

				while (intRowCount < DtElementWavelengths.Rows.Count) {
					dtRow = objDtElements.NewRow();

					dtRow(0) = (string)Format(DtElementWavelengths.Rows(intRowCount).Item(1), "#0.000");
					//CStr(gobjMethodCollection.item(mintSelectedMethodID).InstrumentConditions(0).ElementName)     '  ""
					dtRow(1) = (string)Format(DtElementWavelengths.Rows(intRowCount).Item(2), "#0.0");
					dtRow(2) = (string)DtElementWavelengths.Rows(intRowCount).Item(3);
					objDtElements.Rows.Add(dtRow);
					intRowCount += 1;
				}

				objclsPrintDocument.ReportDataTables.Add(objDtElements);

			}


			return objclsPrintDocument;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return null;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			if (!IsNothing(objclsPrintDocument) == true) {
				objclsPrintDocument.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
btnSelect_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnSelect_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : as Handles btnSelect.Click
		// Purpose               : To select the selected element 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		DataTable DtCookBook;
		DataTable DtElementWavelengths;
		clsPrintDocument objclsPrintDocument;

		try {
			if (gblnCookBookReport == true) {
				//---for cook book report
				if (funcCookBookPrint() == true) {
				}
			//Saurabh 28 May 2007
			} else if (ElementID > 70) {
				return;
			//Saurabh 28 May 2007
			} else {
				this.DialogResult = DialogResult.OK;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void cmbSelectElement_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : cmbSelectElement_SelectedIndexChanged
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To set the selected element to property
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		//---to set selected element id to property
		ElementID = cmbSelectElement.SelectedValue;
	}

	private void  // ERROR: Handles clauses are not supported in C#
btnIgnite_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnIgnite_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To auto ignite the flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			if (!IsNothing(gobjMain)) {
				//---for alt-I auto ignition
				gobjMain.AutoIgnition();
			}

			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			mblnAvoidProcessing = false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
btnExtinguish_Click(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnExtinguish_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To extinguish the flame
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			//---to extinguish the flame
			gobjMain.Extinguish();

			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//objWait.Dispose()
			//---------------------------------------------------------
		}

	}

	private void  // ERROR: Handles clauses are not supported in C#
btnN2OIgnite_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnN2OIgnite_Click
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To N2O auto ignition
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : 
		// Created               : 05.10.06
		// Revisions             : 
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			gobjMain.N2OAutoIgnition();
			//--- call a function for N2O ignition.
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void btnDelete_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnDelete_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Dec-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			gobjMain.funcAltDelete();
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			mblnAvoidProcessing = false;
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	private void btnR_Click(System.Object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : btnR_Click
		// Parameters Passed     : Object, EventArgs
		// Returns               : None
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : 18-Dec-2007 03:15 pm
		// Revisions             : 0
		//=====================================================================
		try {
			if (mblnAvoidProcessing == true) {
				return;
			}
			mblnAvoidProcessing = true;
			gobjMain.funcAltR();
			mblnAvoidProcessing = false;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public void ShowProgressBar(string message)
	{
		//=====================================================================
		// Procedure Name        : ShowProgressBar
		// Parameters Passed     : message
		// Returns               : None
		// Purpose               : to show the progress bar
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Deepak Bhati
		// Created               : Saturday, January 22, 2005
		// Revisions             : 
		//=====================================================================
		try {
			//--- show a status on progressbar

			//StatusBarPanelInfo.Text = message
			if (gblnShowThreadOnfrmMDIStatusBar) {
				StatusBarPanelInfo.Text = StatusBarPanelInfo.Text + " " + message;
			} else {
				StatusBarPanelInfo.Text = message;
				Application.DoEvents();
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

}
