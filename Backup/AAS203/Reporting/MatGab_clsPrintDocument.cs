 // ERROR: Not supported in C#: OptionDeclaration
using System.Reflection;
using System.Drawing.Printing;
using System.Drawing.Printing.PrintDocument;
using System.Collections;
using System.Math;
using AAS203.Common;

public class clsPrintDocument : System.Drawing.Printing.PrintDocument
{
	//*********************************************************************
	// File Header        
	// File Name 		: clsPrintDocument.vb
	// Author			: Mangesh Shardul
	// Date/Time			: 18-Feb-2005 8:00 pm
	// Description		: To print the report 
	//**********************************************************************


	#Region " Component Designer generated code "

	public clsPrintDocument()
	{
		base.New();

		//This call is required by the Component Designer.
		InitializeComponent();
		//Add any initialization after the InitializeComponent() call
		////----- Set default initialise the of Report
		mobjstructReportFormat.PageBottomMargin = 0.5;
		mobjstructReportFormat.PageLeftMargin = 0.32;
		mobjstructReportFormat.PageTopMargin = 1.0;
		////-----

	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(clsPrintDocument));
		this.ToolbarImageList = new System.Windows.Forms.ImageList(this.components);
		this.DefaultPageSettings = m_PageSetting;
		////----- Added by Sachin Dokhale 
		////----- Set printer type as color or normal
		this.DefaultPageSettings.Color = PrinterType;
		// Set Default is Normal = Black & White

		////-----
		//
		//
		//ToolbarImageList
		//
		this.ToolbarImageList.ImageSize = new System.Drawing.Size(16, 16);
		this.ToolbarImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ToolbarImageList.ImageStream");
		this.ToolbarImageList.TransparentColor = System.Drawing.Color.Transparent;

	}

	#End Region

	#Region " Enums, Constants, ... "

	public enum enumReportLayoutType
	{
		Portrate = 1,
		Landscape = 2
	}

	public enum enumReportType
	{

		Others = 0,
		CookBook = 1,
		DataFile = 2,
		StadardGraph = 3,
		SampleGraph = 4,
		PrintPeak_Valley = 5,
		UVSpectrum = 6,
		EnergySpectrum = 7,
		Histograph = 8,
		RepeatResults = 9,
		D2Peak = 10,
		TimescanGraph = 11
		//QCColorDifferenceNumerical = 2
		//QCColorDifferenceInterpretation = 3
		//QCColorDifferencePassFail = 4
		//QCColorDifferenceSpaceDiagram = 5
		//QCColorDifferenceMasterReport = 6

		//QCStrengthNumerical = 7
		//QCStrengthVisual = 8
		//QCStrengthInterpretation = 9
		//QCStrengthPassFail = 10
		//QCStrengthSpaceDiagram = 11
		//QCStrengthMasterReport = 12

		//QCTriStimulusResults = 13
		//QCTriStimulusCIEPlot = 14

		//QCIndices = 15
		//QCScales = 16
		//QCMetamerism = 17

		//QCColorOnScreen = 18
		//QCColorOnObject = 19

		//QCContrastRatio = 20

		//ColorAttributes = 21
		//RecipeDetails = 22
		//Shade555SortResults = 23

		//EditShade = 24
		//EditStandards = 25
		//EditColorants = 26
		//'//----- Added by Sachin Dokhale on 18.03.06
		//EditSubstrate = 31
		//'//-----
		//InstrumentRepeatability = 27

		//BatchCorrection = 28
		//'//----- Added by Sachinn Dokhle on 30.09.05
		//EditPigment = 29
		//'//-----
		//BatchCorrection_2Const = 30
		////----- Last integer is 31

	}


	public const float lineSpacing = 0.1;
	private const int ConstPageSettingOutofRange = 211;
	//Private Const CONST_GraphHeight = 350
	//Private Const CONST_GraphWidth = 650
	private int CONST_GraphHeight = 350;

	private int CONST_GraphWidth = 625;
	public struct structCookBook
	{
		int ElamentID;
		string ElamenttName;
		string ElamentAbrivation;
		string ElamentATWT;
		string StandardSolution;
		string SolutionTech;
		string InstumentLamp;
		string InstumentFuel;
		string InstumentSupport;
		double InstumentFlame;
		string AbsNote;
		bool IsFlame;
		int FlameWavelength;
		int FlameBandWidth;
		string FlameFuel;
		string FlameSupport;
		string FlameNote;

		string Interference;
	}

	public struct structCookBookDetals
	{
		long ElamentID;
		int AbsWavelength;
		int AbsSpectrulBand;
		string AbsWorkingRange;
	}

	public struct struHeaderString
	{
		string TextString;
		clsReportHeaderFormat TextFormat;
	}


	#End Region

	#Region " Class Variables "

	private SolidBrush mobjReportBrush = new SolidBrush(Color.Black);
	private SolidBrush mobjReportBrushBlack = new SolidBrush(Color.Black);
	private SolidBrush mobjReportBrushRed = new SolidBrush(Color.Red);
	private SolidBrush mobjReportBrushBlue = new SolidBrush(Color.Blue);
	int mintNextPageCurrentRow;
	private ActiveReport2 mobjARPortrateReport;
	//Private mobjARLandScapeReport As ARrptTablePropertiesLandScape
	private System.IO.StringReader rptPageTextReader;
	private int npp;
	private int NoOfPagesPreviewed;
	private int CurRow;
	private int CurCol;
	private int CurLine;
	private int NextFirstCol;

	private int NoOfRowsPerPage;

	private clsReportingMode.structReportFormat mobjstructReportFormat;
	private Font printFont;
	private StringFormat ColoumnFormat;
	private bool setColoumnFormat = true;
		//("Arial", 10, FontStyle.Bold)
	private Font headerFont;
	private string mstrPageHeader;

	private string mstrPageFooter;
	private struHeaderString m_strPageHeader;
	private struHeaderString m_strReportFooter;
	private struHeaderString m_strSubPageHeader1;
	private struHeaderString m_strSubPageHeader2;
	private bool m_PrinterType;

	private string mstrPageText;

	private ArrayList marrGraphControlsList;
	private DataView mobjDvReportDataView;

	private DataTable mobjDtReportDataTable;

	private ArrayList mobjRptDataTblList;

	private ArrayList mobjRptDtTextList;

	private DataTable mobjDtImageList;
	private int mintPageCount = 0;
	private int mintReportTablesCount = 0;
	private int mintReportTextTableCount = 0;

	private int privReportTablesCount = 0;
	private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

	private PrintPreviewControl printPreviewControl = new PrintPreviewControl();

	private enumReportType mintReportType;

	private enumReportLayoutType mintReportLayoutType;

	private bool mblnIsBeginPrint = false;
	private ToolBar objReportViewerToolBar;
	private ImageList AddedButtonsImageList;

	private ArrayList AddedButtons;
	internal System.Windows.Forms.ImageList ToolbarImageList;

	private System.ComponentModel.IContainer components;
	private int mintImageCounter;
	private int mintReportGraphsCount;
	private int mintCurrentImageRow = 0;
	public int mintCurrentGraph = 0;
	int mintPageFooterYPosotion = 0;

	private bool blnPageSettingMessage = false;

	private int mintTotalHeightOfPageText;
	private ArrayList mElamentInfo;
	private ArrayList mRepeatDatafile;
	//Private mDtElamentDetails As DataTable


	private DataTable objDtCookBookInfoRpt;

	private DataTable objDtCookBookDetailRpt;
	private bool blnFinishElamentInfo;
	private bool blnFinishFlameEmission;
	private bool blnFinishFlameEmissionNotes;
	private bool blnFinishInterference;
	private bool blnFinishStdSolutionTech;
	private bool blnFinishWorkingConditionFixed;

	private bool blnFinishWorkingConditionVariable;

	private DataTable objDtDatafileRpt;
	private DataTable objDtDatafileDetailRpt;
	////----- for Repeat Result
	private int mMasterIdx;
	////-----
		#End Region
	private bool blnEscapeHeader;

	#Region " Public Properties "

	public double marginLeft;
	public double marginTop;
	public double marginBottom;
	private PageSettings m_PageSetting = new PageSettings();
	private AAS203Library.Method.clsReportParameters mobjReportParameter;
	public clsReportingMode.structReportFormat ReportFormat {
		get { return mobjstructReportFormat; }
		set { mobjstructReportFormat = Value; }
	}

	public AAS203Library.Method.clsReportParameters DataFileReportParameter {
		get { return mobjReportParameter; }
		set { mobjReportParameter = Value; }
	}

	public Font DisplayFont {
		get { return printFont; }
		set { printFont = Value; }
	}

	public Font TableHeaderFont {
		get { return headerFont; }
		set { headerFont = Value; }
	}

	public bool SetTableColoumnFormat {
		get { return setColoumnFormat; }
		set { setColoumnFormat = Value; }
	}

	//Public Property PageHeader() As String
	//    Get
	//        Return mstrPageHeader
	//    End Get
	//    Set(ByVal Value As String)
	//        mstrPageHeader = Value
	//    End Set
	//End Property

	public struHeaderString PageHeader {
		get { return m_strPageHeader; }
		set { m_strPageHeader = Value; }
	}
	public struHeaderString PageSubHeader1 {
		get { return m_strSubPageHeader1; }
		set { m_strSubPageHeader1 = Value; }
	}
	public struHeaderString PageSubHeader2 {
		get { return m_strSubPageHeader2; }
		set { m_strSubPageHeader2 = Value; }
	}
	public struHeaderString ReportFooter {
		get { return m_strReportFooter; }
		set { m_strReportFooter = Value; }
	}
	////---- Set iss printer type as Normal or Color
	public bool PrinterType {
		get { return m_PrinterType; }
		set {
			m_PrinterType = Value;
			if (!(this.DefaultPageSettings == null)) {
				this.DefaultPageSettings.Color = m_PrinterType;
			}
		}
	}

	public string PageText {
		get { return mstrPageText; }
		set { mstrPageText = Value; }
	}

	public ArrayList ReportGraphControls {
		get { return marrGraphControlsList; }
		set { marrGraphControlsList = Value; }
	}

	public ArrayList ReportDataTables {
		get { return mobjRptDataTblList; }
		set { mobjRptDataTblList = Value; }
	}

	public ArrayList ReportTextList {
		get { return mobjRptDtTextList; }
		set { mobjRptDtTextList = Value; }
	}

	public DataTable ReportImageList {
		get { return mobjDtImageList; }
		set { mobjDtImageList = Value; }
	}

	public enumReportType ReportType {
		get { return mintReportType; }
		set { mintReportType = Value; }
	}

	public enumReportLayoutType ReportLayoutType {
		get { return mintReportLayoutType; }

		set { mintReportLayoutType = Value; }
	}

	public ArrayList ElamentInfo {
		get { ElamentInfo = mElamentInfo; }
		set { mElamentInfo = Value; }
	}

	public ArrayList RepeatDatafile {
		get { RepeatDatafile = mRepeatDatafile; }
		set { mRepeatDatafile = Value; }
	}

	public System.Drawing.Printing.PageSettings PageSetting {
		get { PageSetting = m_PageSetting; }
		set {
			m_PageSetting = Value;
			this.DefaultPageSettings = m_PageSetting;
			this.DefaultPageSettings.Color = PrinterType;
			this.PrinterSettings = this.PageSetting.PrinterSettings;
		}
	}

	//Public Property ElamentDetails() As DataTable
	//    Get
	//        ElamentDetails = mDtElamentDetails
	//    End Get
	//    Set(ByVal Value As DataTable)
	//        mDtElamentDetails = Value
	//    End Set
	//End Property

	#End Region

	#Region " Public Functions "

	public bool PrintPreview()
	{
		CWaitCursor objWait = new CWaitCursor();
		try {
			mblnIsBeginPrint = true;

			subSetActiveReportProperties();

			if (!(mintReportType == enumReportType.CookBook)) {
				rptPageTextReader = new System.IO.StringReader(mstrPageText);
			} else {
				if (IsNothing(this.ElamentInfo) == false) {
					objDtCookBookInfoRpt = ((DataTable)this.ElamentInfo.Item(0)).Copy;
					objDtCookBookDetailRpt = ((DataTable)this.ElamentInfo.Item(1)).Copy;
				}
			}

			subGetToolBarButtonClick();

			printPreviewDialog.Document = this;
			printPreviewDialog.PrintPreviewControl.Document = this;
			printPreviewDialog.PrintPreviewControl.Zoom = 1;

			printPreviewDialog.FormBorderStyle = FormBorderStyle.Fixed3D;
			printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
			printPreviewDialog.WindowState = FormWindowState.Maximized;

			////-----
			mintCurrentGraph = 0;
			mintCurrentImageRow = 0;
			mintImageCounter = 0;
			mintNextPageCurrentRow = 0;
			mintPageFooterYPosotion = 0;
			mintReportGraphsCount = 0;
			CurRow = 0;
			CurCol = 0;
			blnPageSettingMessage = false;
			mMasterIdx = 0;
			blnEscapeHeader = false;
			////-----
			////-----
			if (mintReportType == enumReportType.CookBook) {
				blnFinishFlameEmission = false;
				blnFinishElamentInfo = false;
				blnFinishFlameEmissionNotes = false;
				blnFinishInterference = false;
				blnFinishStdSolutionTech = false;
				blnFinishWorkingConditionFixed = false;
				blnFinishWorkingConditionVariable = false;
				//blnPageSettingMessage =
			}
			////-----

			if (printPreviewDialog.ShowDialog() == (DialogResult.Cancel | DialogResult.None)) {
				printPreviewDialog.Close();
			}
			Application.DoEvents();

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			printPreviewDialog.Close();
			printPreviewDialog.Dispose();
			if (!objWait == null) {
				objWait.Dispose();
			}
			objWait = null;
			//---------------------------------------------------------
		}

	}

	public bool PrintToPrinter()
	{
		string StrName;
		CWaitCursor objWait = new CWaitCursor();
		try {
			mblnIsBeginPrint = true;
			subSetActiveReportProperties();

			rptPageTextReader = new System.IO.StringReader(mstrPageText);

			PrintDialog objprintDialog = new PrintDialog();
			objprintDialog.Document = this;
			objprintDialog.PrinterSettings = this.PrinterSettings;
			objprintDialog.AllowPrintToFile = false;
			objprintDialog.AllowSelection = false;
			objprintDialog.AllowSomePages = false;
			objprintDialog.ShowHelp = true;
			objprintDialog.ShowNetwork = true;
			////
			//mintCurrentGraph = 0
			//mintCurrentImageRow = 0
			//mintImageCounter = 0
			//mintNextPageCurrentRow = 0
			//mintPageFooterYPosotion = 0
			//mintReportGraphsCount = 0
			//CurRow = 0
			//CurCol = 0
			//mintPageCount = 0
			//'//----- Set the initialy PageTest height to 0
			//mintTotalHeightOfPageText = 0
			//blnPageSettingMessage = False
			//mMasterIdx = 0
			//'//-----
			//If mintReportType = enumReportType.CookBook Then
			//    blnFinishFlameEmission = False
			//    blnFinishElamentInfo = False
			//    blnFinishFlameEmissionNotes = False
			//    blnFinishInterference = False
			//    blnFinishStdSolutionTech = False
			//    blnFinishWorkingConditionFixed = False
			//    blnFinishWorkingConditionVariable = False
			//    'blnPageSettingMessage =
			//End If
			////-----
			////
			if (objprintDialog.ShowDialog() == DialogResult.OK) {
				int printCopy = 0;
				//For printCopy = 1 To objprintDialog.PrinterSettings.Copies  '---changed by Deepak on 30.08.09
				objWait = new CWaitCursor();
				mblnIsBeginPrint = true;
				mintCurrentGraph = 0;
				mintCurrentImageRow = 0;
				mintImageCounter = 0;
				mintNextPageCurrentRow = 0;
				mintPageFooterYPosotion = 0;
				mintReportGraphsCount = 0;
				CurRow = 0;
				CurCol = 0;
				mintPageCount = 0;
				////----- Set the initialy PageTest height to 0
				mintTotalHeightOfPageText = 0;
				blnPageSettingMessage = false;
				mMasterIdx = 0;
				////-----
				blnEscapeHeader = false;
				if (mintReportType == enumReportType.CookBook) {
					blnFinishFlameEmission = false;
					blnFinishElamentInfo = false;
					blnFinishFlameEmissionNotes = false;
					blnFinishInterference = false;
					blnFinishStdSolutionTech = false;
					blnFinishWorkingConditionFixed = false;
					blnFinishWorkingConditionVariable = false;
					//blnPageSettingMessage =
				}
				this.Print();
				Application.DoEvents();
			//Next
			//Me.funcExportData()
			} else {
				mblnIsBeginPrint = false;
			}
			Application.DoEvents();
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

	public bool SendExportData()
	{
		try {
			mblnIsBeginPrint = true;
			subSetActiveReportProperties();

			rptPageTextReader = new System.IO.StringReader(mstrPageText);

			PrintDialog objprintDialog = new PrintDialog();
			objprintDialog.Document = this;
			objprintDialog.PrinterSettings = this.PrinterSettings;
			objprintDialog.AllowPrintToFile = true;
			objprintDialog.AllowSelection = true;
			objprintDialog.AllowSomePages = true;
			objprintDialog.ShowHelp = true;
			objprintDialog.ShowNetwork = true;
			////
			mintCurrentGraph = 0;
			mintCurrentImageRow = 0;
			mintImageCounter = 0;
			mintNextPageCurrentRow = 0;
			mintPageFooterYPosotion = 0;
			mintReportGraphsCount = 0;
			CurRow = 0;
			CurCol = 0;
			mintPageCount = 0;
			////----- Set the initialy PageTest height to 0
			mintTotalHeightOfPageText = 0;
			blnPageSettingMessage = false;
			mMasterIdx = 0;
			////-----
			if (mintReportType == enumReportType.CookBook) {
				blnFinishFlameEmission = false;
				blnFinishElamentInfo = false;
				blnFinishFlameEmissionNotes = false;
				blnFinishInterference = false;
				blnFinishStdSolutionTech = false;
				blnFinishWorkingConditionFixed = false;
				blnFinishWorkingConditionVariable = false;
				//blnPageSettingMessage =
			}
			////-----
			////
			//If objprintDialog.ShowDialog() = DialogResult.OK Then
			this.ExportData();

			//Else
			//mblnIsBeginPrint = False
			//End If
			Application.DoEvents();
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

	private bool subGetToolBarButtonClick()
	{
		//=====================================================================
		// Procedure Name        : GetToolBarButtonClick
		// Parameters Passed     : None
		// Returns               : True or false
		// Purpose               : To reset the Toolbar of PrintPreviewDialog
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Sunday, February 06, 2005
		// Revisions             : 1
		//=====================================================================
		Windows.Forms.Control control;
		Windows.Forms.ToolBar.ToolBarButtonCollection objToolBarButtonCollection;

		try {
			foreach ( control in printPreviewDialog.Controls) {
				if (control is ToolBar) {
					objReportViewerToolBar = (ToolBar)control;
					objToolBarButtonCollection = objReportViewerToolBar.Buttons;
				}
			}
			//AddedButtonsImageList = objReportViewerToolBar.ImageList

			//AddedButtonsImageList.Images.Add(Me.ToolbarImageList.Images(0))   '(Image.FromFile(Application.StartupPath & "\Resources\ExportData.bmp"))
			//AddedButtonsImageList.Images.Add(Me.ToolbarImageList.Images(1))   '(Image.FromFile(Application.StartupPath & "\Resources\SendMail.bmp"))

			//Dim btnExportData As New ToolBarButton
			//btnExportData.ToolTipText = "Exports Data"
			//btnExportData.Tag = 100
			//btnExportData.ImageIndex = 7
			//Dim btnMailData As New ToolBarButton
			//btnMailData.ToolTipText = "Sends Data via eMail"
			//btnMailData.Tag = 101
			//btnMailData.ImageIndex = 8

			//Dim btns(1) As ToolBarButton
			//btns(0) = btnExportData
			//btns(1) = btnMailData

			//Call subAddToolBarButtons(btns)

			objReportViewerToolBar.ButtonClick += subToolBarButtonClick;

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

	private void subToolBarButtonClick(object sender, ToolBarButtonClickEventArgs e)
	{
		try {
			switch (e.Button.ToolTipText) {
				case "Print":

					PrintToPrinter();
				//Call funcExportData()
				case "Zoom":

					printPreviewDialog.PrintPreviewControl.AutoZoom = true;
				case "Sends Data via eMail":
				//'Me.eMailData()

				case "Exports Data":
				//Me.ExportData()

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

	public void subAddToolBarButtons(System.Windows.Forms.ToolBarButton[] Buttons)
	{
		ImageList imgList;
		int i;
		int intInitialImages;

		try {
			imgList = new ImageList();
			imgList = objReportViewerToolBar.ImageList;
			intInitialImages = imgList.Images.Count;

			AddedButtons = new ArrayList();
			for (i = 0; i <= AddedButtonsImageList.Images.Count - 1; i++) {
				imgList.Images.Add(AddedButtonsImageList.Images.Item(i));
			}

			int initw = 0;
			for (i = 0; i <= Buttons.GetLength(0) - 1; i++) {
				AddedButtons.Add(Buttons(i));
				if (Buttons(i).ImageIndex >= 0) {
					Buttons(i).ImageIndex += intInitialImages;
				}
				objReportViewerToolBar.Buttons.Add(Buttons(i));
				initw += objReportViewerToolBar.Buttons(objReportViewerToolBar.Buttons.Count - 1).Rectangle.Width;
			}
			System.Drawing.Size s = printPreviewDialog.MinimumSize;
			s.Width += initw;
			printPreviewDialog.MinimumSize = s;
			Button b = funcGetCloseButton();
			b.Left += initw;
		//If gstructSettings.DemoMode = 2 Then
		//Buttons(0).Enabled = False
		//End If

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

	//Public Function funcSetPrintDocument(ByVal objstructReportFormatIn As clsReportingMode.structReportFormat, _
	//              ByVal objDtmElamentInfo As DataTable, _
	//              ByVal objDtElamentDetails As DataTable, _
	//              ByVal intReportTypeIn As clsPrintDocument.enumReportType) As clsPrintDocument
	//    '=====================================================================
	//    ' Procedure Name        : funcSetPrintDocument
	//    ' Parameters Passed     : As above
	//    ' Returns               : True or false
	//    ' Purpose               : To set the clsPrintDocument object
	//    ' Description           : 
	//    ' Assumptions           : 
	//    ' Dependencies          : 
	//    ' Author                : Mangesh Shardul At Machine SOFT1
	//    ' Created               : Monday, January 31, 2005
	//    ' Revisions             : 1
	//    '=====================================================================
	//    Dim intCount As Integer
	//    Dim objDtTable2In As DataTable
	//    Dim objclsPrintDocument As New clsPrintDocument

	//    Dim FontStyles As System.Drawing.Font '= Me.DefaultFont
	//    Dim ReportHeaderFont As Font
	//    Try
	//        objstructReportFormatIn.IsDisplayCompanyLogo = True
	//        objstructReportFormatIn.IsDisplayReportDate = True
	//        objstructReportFormatIn.IsDisplayReportFooter = True
	//        objstructReportFormatIn.IsDisplayReportTitle = True
	//        objstructReportFormatIn.IsDisplaySecondReportTitle = True
	//        objstructReportFormatIn.IsDisplaySubsequentPageHeader = True
	//        objstructReportFormatIn.LogoAlignment = 1
	//        objstructReportFormatIn.PageBottomMargin = 0.5
	//        objstructReportFormatIn.PageLeftMargin = 0.32
	//        objstructReportFormatIn.PageTopMargin = 1
	//        objstructReportFormatIn.LogoFileName = "D:\ALDYS\AAS 203 Borland Windows SW\win203.5\BMP\BMP\CHEMITO.BMP"

	//        objclsPrintDocument.ReportFormat = objstructReportFormatIn
	//        objclsPrintDocument.PageHeader = strPageHeaderIn
	//        objclsPrintDocument.PageText = strPageTextIn
	//        objclsPrintDocument.DisplayFont = ReportHeaderFont
	//        objclsPrintDocument.TableHeaderFont = FontStyles
	//        objclsPrintDocument.ReportImageList = objDtImagesListIn
	//        objclsPrintDocument.ReportType = intReportTypeIn
	//        objclsPrintDocument.ReportLayoutType = clsPrintDocument.enumReportLayoutType.Portrate

	//        '---Set Property ReportDataTables
	//        If IsNothing(arrDtTablesListIn) = False Then
	//            objclsPrintDocument.ReportDataTables = New ArrayList

	//            'For intCount = 0 To arrDtTablesListIn.Count - 1
	//            '    objDtTable2In = arrDtTablesListIn.Item(intCount)
	//            '    If IsNothing(objDtTable2In) = False Then
	//            '        objclsPrintDocument.ReportDataTables.Add(objDtTable2In)
	//            '    End If
	//            'Next intCount
	//        End If

	//        '---Set Property ReportGraphControls
	//        If IsNothing(arrGraphControlsListIn) = False Then
	//            objclsPrintDocument.ReportGraphControls = New ArrayList
	//            For intCount = 0 To arrGraphControlsListIn.Count - 1
	//                If IsNothing(arrGraphControlsListIn.Item(intCount)) = False Then
	//                    objclsPrintDocument.ReportGraphControls.Add(arrGraphControlsListIn.Item(intCount))
	//                End If
	//            Next intCount
	//        End If

	//        funcGetCookBookStruct(objDtmElamentInfo, objDtElamentDetails)
	//        Return objclsPrintDocument

	//    Catch ex As Exception
	//        '---------------------------------------------------------
	//        'Error Handling and logging
	//        gobjErrorHandler.ErrorDescription = ex.Message
	//        gobjErrorHandler.ErrorMessage = ex.Message
	//        gobjErrorHandler.WriteErrorLog(ex)
	//        Return Nothing
	//        '---------------------------------------------------------
	//    Finally
	//        '---------------------------------------------------------
	//        'Writing Execution log
	//        If CONST_CREATE_EXECUTION_LOG = 1 Then
	//            gobjErrorHandler.WriteExecutionLog()
	//        End If
	//        If Not IsNothing(objclsPrintDocument) = True Then
	//            objclsPrintDocument.Dispose()
	//        End If
	//        '---------------------------------------------------------
	//    End Try

	//End Function

	private Button funcGetCloseButton()
	{
		FieldInfo objFieldInfo;
		System.Windows.Forms.Button objButton;

		try {
			objFieldInfo = typeof(System.Windows.Forms.PrintPreviewDialog).GetField("closeButton", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

			objButton = (System.Windows.Forms.Button)objFieldInfo.GetValue(printPreviewDialog);

			return objButton;

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

	private void subSetActiveReportProperties()
	{
		//=====================================================================
		// Procedure Name 	: SetActiveReportProperties
		// Author			: Mangesh Shardul
		// Date/Time			: 28-Feb-2005 04:45 pm
		// Description		: 
		//=====================================================================
		try {
			mobjARPortrateReport = new ActiveReport2();

			//mobjARPortrateReport.PageSettings.PaperKind = Printing.PaperKind.A4
			//mobjARPortrateReport.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
			//mobjARPortrateReport.PageSettings.PaperSource = Printing.PaperSourceKind.Custom

			//'//----- Added by Sachin Dokhale 
			//mobjARPortrateReport.PageSettings.Margins.Left = CSng(mobjstructReportFormat.PageLeftMargin * 100)
			//mobjARPortrateReport.PageSettings.Margins.Bottom = CSng(mobjstructReportFormat.PageBottomMargin * 100)
			//mobjARPortrateReport.PageSettings.Margins.Right = 50
			//mobjARPortrateReport.PageSettings.Margins.Top = CSng(mobjstructReportFormat.PageTopMargin * 100)
			//'//-----

			////----- Added by Sachin Dokhale on 27.01.07

			mobjARPortrateReport.PageSettings.PaperKind = PageSetting.PaperSize.Kind;
			//  .PaperKind.A4
			//DataDynamics.ActiveReports.Document.PageOrientation.Portrait.
			DataDynamics.ActiveReports.Document.PageOrientation objPageOrientation;
			if (PageSetting.Landscape == true) {
				objPageOrientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
			} else {
				objPageOrientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
			}
			mobjARPortrateReport.PageSettings.Orientation = objPageOrientation;

			mobjARPortrateReport.PageSettings.PaperSource = PageSetting.PaperSource.Kind;
			//Printing.PaperSourceKind.Custom

			mobjARPortrateReport.PageSettings.Margins.Left = PageSetting.Margins.Left;
			//CSng(mobjstructReportFormat.PageLeftMargin * 100)
			mobjARPortrateReport.PageSettings.Margins.Bottom = PageSetting.Margins.Bottom;
			//CSng(mobjstructReportFormat.PageBottomMargin * 100)
			mobjARPortrateReport.PageSettings.Margins.Right = PageSetting.Margins.Right;
			// 50
			mobjARPortrateReport.PageSettings.Margins.Top = PageSetting.Margins.Top;
			//CSng(mobjstructReportFormat.PageTopMargin * 100)
			////--- Check for color printing setting
			PrinterType = gstructSettings.blnSelectColorPrinter;

		////-----
		//mobjARLandScapeReport = New ARrptTablePropertiesLandScape
		//mobjARLandScapeReport.PageSettings.PaperKind = Printing.PaperKind.A4
		//mobjARLandScapeReport.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
		//mobjARLandScapeReport.PageSettings.PaperSource = Printing.PaperSourceKind.Custom

		////----- Added by Sachin Dokhale 
		//mobjARLandScapeReport.PageSettings.Margins.Left = CSng(mobjstructReportFormat.PageLeftMargin * 100)
		//mobjARLandScapeReport.PageSettings.Margins.Bottom = CSng(mobjstructReportFormat.PageBottomMargin * 100)
		//mobjARLandScapeReport.PageSettings.Margins.Right = 50
		//mobjARLandScapeReport.PageSettings.Margins.Top = CSng(mobjstructReportFormat.PageTopMargin * 100)
		////-----
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

	#Region " Private Functions "

	protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs e)
	{
		try {
			if (mblnIsBeginPrint == true) {
				e.Cancel = false;
			} else {
				e.Cancel = true;
			}

			base.OnBeginPrint(e);
			mintPageCount = 0;
			NextFirstCol = 0;
			npp = 0;
			CurRow = 0;
			CurCol = 0;
			mintReportTablesCount = 0;
			mintReportTextTableCount = 0;
			mintImageCounter = 0;
			mintCurrentImageRow = 0;
			mintReportGraphsCount = 0;

			printFont = this.DisplayFont;
			headerFont = this.TableHeaderFont;
		//headerFont.Bold = Me.TableHeaderFont.Bold
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

	protected override void OnEndPrint(System.Drawing.Printing.PrintEventArgs e)
	{
		mblnIsBeginPrint = false;
	}

	protected override void OnQueryPageSettings(System.Drawing.Printing.QueryPageSettingsEventArgs e)
	{
		DataDynamics.ActiveReports.ActiveReport objARLayoutReport;

		try {
			//e.PageSettings.Landscape = False
			//mintReportLayoutType = enumReportLayoutType.Portrate

			//Select Case mintReportLayoutType
			//    Case enumReportLayoutType.Portrate
			//        objARLayoutReport = mobjARPortrateReport

			//    Case enumReportLayoutType.Landscape
			//        'objARLayoutReport = mobjARLandScapeReport
			//End Select
			//e.PageSettings.Landscape = False
			if (e.PageSettings.Landscape) {
				mintReportLayoutType = enumReportLayoutType.Portrate;
			} else {
				mintReportLayoutType = enumReportLayoutType.Portrate;
			}

			switch (mintReportLayoutType) {
				case enumReportLayoutType.Portrate:

					objARLayoutReport = mobjARPortrateReport;
				case enumReportLayoutType.Landscape:
					//mobjARLandScapeReport
					objARLayoutReport = mobjARPortrateReport;
			}


			e.PageSettings.Margins.Left = (int)objARLayoutReport.PageSettings.Margins.Left;
			e.PageSettings.Margins.Right = (int)objARLayoutReport.PageSettings.Margins.Right;
			e.PageSettings.Margins.Top = (int)objARLayoutReport.PageSettings.Margins.Top;
			e.PageSettings.Margins.Bottom = (int)objARLayoutReport.PageSettings.Margins.Bottom;

			//Dim intCount As Integer
			//For intCount = 0 To e.PageSettings.PrinterSettings.PaperSizes.Count - 1
			//    If e.PageSettings.PrinterSettings.PaperSizes.Item(intCount).Kind = PaperKind.A4 Then
			//        e.PageSettings.PaperSize = e.PageSettings.PrinterSettings.PaperSizes.Item(intCount)
			//        Exit For
			//    End If

			//Next intCount
			//e.PageSettings.PaperSize = e.PageSettings.PrinterSettings.PaperSizes.Item(intCount)
			e.PageSettings.PrinterSettings = PageSetting.PrinterSettings();
			//objARLayoutReport.Document.Printer.PrinterSettings


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

	protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
	{
		float yPosition = 0;
		float sngPageHeaderYPosition;

		float leftMargin = e.MarginBounds.Left;
		float topMargin = e.MarginBounds.Top;

		float BottomMargin = e.MarginBounds.Bottom;

		try {
			mintPageCount += 1;
			////----- Set the initialy PageTest height to 0
			mintTotalHeightOfPageText = 0;
			////-----
			base.OnPrintPage(e);

			//---1.Draw the Report Logo Image
			// Call funcDrawReportLogoImage(e.Graphics, leftMargin, topMargin)

			//If Not (mintReportType = enumReportType.CookBook) Then


			//---2.Draw the Report Header
			funcDrawReportHeader(e.Graphics, leftMargin, topMargin, sngPageHeaderYPosition, mintReportLayoutType);

			//---3.Draw the Page Header
			sngPageHeaderYPosition = funcDrawPageHeader(e.Graphics, leftMargin, topMargin, sngPageHeaderYPosition, mintReportLayoutType);
			//End If

			//---Draw Page Footer
			funcDrawPageFooter(e.Graphics, leftMargin, BottomMargin, mintReportLayoutType);

			//---2.Draw the Report Footer
			funcDrawReportFooter(e.Graphics, leftMargin, BottomMargin, mintReportLayoutType);


			e.HasMorePages = false;
			yPosition = sngPageHeaderYPosition;
			//+ lineSpacing + (4 * printFont.GetHeight(e.Graphics))


			//---4.Draw the Page Text for Cook Book
			if (mintReportType == enumReportType.CookBook) {
				funcDrawPageText_CookBook(e, yPosition, leftMargin, topMargin, BottomMargin, mintReportLayoutType);
				yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
				mobjReportBrush.Dispose();
				return;
			} else if (mintReportType == enumReportType.DataFile) {
				funcDrawTextList(e, yPosition, leftMargin);

				if (e.HasMorePages == false) {
					yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
					funcDrawGridTables(e, yPosition, leftMargin);
				}

				yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
				mobjReportBrush.Dispose();
				return;
			} else if (mintReportType == enumReportType.StadardGraph) {
				//funcDrawTextList(e, yPosition, leftMargin)
				//yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
				funcDrawTextList(e, yPosition, leftMargin);

				if (e.HasMorePages == false) {
					funcDrawAllGraphs(e, yPosition, leftMargin);
				}

				if (e.HasMorePages == false) {
					yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
					funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType);
				}
				if (e.HasMorePages == false) {
					yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
					funcDrawGridTables(e, yPosition, leftMargin);
				}
				yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
				mobjReportBrush.Dispose();
				return;


			} else if (mintReportType == enumReportType.PrintPeak_Valley) {

				//If e.HasMorePages = False Then
				//    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
				//    Call funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType)
				//    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
				//End If

				funcDrawTextList(e, yPosition, leftMargin);

				if (e.HasMorePages == false) {
					funcDrawAllGraphs(e, yPosition, leftMargin);
				}

				if (e.HasMorePages == false) {
					yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
					funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType);
				}
				//If e.HasMorePages = False Then
				//    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
				//    Call funcDrawGridTables(e, yPosition, leftMargin)
				//End If
				if (e.HasMorePages == false) {
					yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
					funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType);
					yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
				}
				yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
				mobjReportBrush.Dispose();


			} else if (mintReportType == enumReportType.UVSpectrum | mintReportType == enumReportType.EnergySpectrum | mintReportType == enumReportType.Histograph | mintReportType == enumReportType.D2Peak | mintReportType == enumReportType.TimescanGraph) {
				//If e.HasMorePages = False Then
				//    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
				//    Call funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType)
				//    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
				//End If

				funcDrawTextList(e, yPosition, leftMargin);

				if (e.HasMorePages == false) {
					funcDrawAllGraphs(e, yPosition, leftMargin);
				}


				//If e.HasMorePages = False Then
				//    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
				//    Call funcDrawGridTables(e, yPosition, leftMargin)
				//End If
				if (e.HasMorePages == false) {
					yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
					funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType);
					yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
				}
				yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
				mobjReportBrush.Dispose();
				return;
			} else if (mintReportType == enumReportType.RepeatResults) {
				//funcDrawTextList(e, yPosition, leftMargin)
				// funcDrawTextList(e, yPosition, leftMargin)

				funcDrawRepeatDataText(e, yPosition, leftMargin);
				//If e.HasMorePages = False Then
				//    yPosition += lineSpacing + printFont.GetHeight(e.Graphics)
				//    Call funcDrawGridTables(e, yPosition, leftMargin)
				//End If

				yPosition += lineSpacing + printFont.GetHeight(e.Graphics);
				mobjReportBrush.Dispose();
				return;

			} else {
				funcDrawPageText(e, leftMargin, yPosition, mintReportLayoutType);
			}


			// e.HasMorePages = True
			//---DataGrid Printing
			yPosition += lineSpacing + printFont.GetHeight(e.Graphics);

			//---5.Draw the Grid Tables from DataTable
			if (e.HasMorePages == false) {
				funcDrawGridTables(e, yPosition, leftMargin);
			}

			////----- Modified by Sachin Dokhale
			//---6.Graph Printing
			if (e.HasMorePages == false) {
				//Call funcDrawAllGraphs(e, yPosition, leftMargin)
			}
			////-----

			////----- Modified by Sachin Dokhale
			//---7.Images Printing
			////----- Modified by Sachin Dokhale on 8.1.06
			//If mintReportType = enumReportType.Shade555SortResults Then

			//    Call funcDrawAllImages(e, yPosition, leftMargin)
			//Else
			//    '//-----
			//    If e.HasMorePages = False Then
			//        If funcDrawAllImages(e, yPosition, leftMargin) = True Then
			//            'e.HasMorePages = intIsPageReapate
			//        End If
			//    End If
			//End If
			////-----

			//If mintCurrentImageRow <> 0 Or mintCurrentGraph <> 0 Then
			//    e.HasMorePages = True
			//End If

			//---8.Release resources used by Solid Brush object
			mobjReportBrush.Dispose();

		//Catch ex As Exception
		//    MessageBox.Show(ex.Message.ToString())
		//End Try
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

	private bool funcDrawReportLogoImage(ref Graphics G, float sngLeftMarginIn, float sngTopMarginIn)
	{
		//Draw the Report Logo Image
		Drawing.RectangleF rectReportLogo;
		Image imgReportLogoImage;
		DataDynamics.ActiveReports.ActiveReport objARLayoutReport;

		try {
			if (mintReportLayoutType == enumReportLayoutType.Portrate) {
				objARLayoutReport = mobjARPortrateReport;
			} else if (mintReportLayoutType == enumReportLayoutType.Landscape) {
				//objARLayoutReport = mobjARLandScapeReport
			}
			if (mobjstructReportFormat.IsDisplayCompanyLogo == true) {
				rectReportLogo = ((DataDynamics.ActiveReports.Picture)objARLayoutReport.Sections("ReportHeader").Controls("pictLogo")).GetBounds;
				//---All distances In Active Reports are in Inches
				//---And 1 inch. = 96 Pixels
				rectReportLogo.X = rectReportLogo.X * 96 + sngLeftMarginIn;
				rectReportLogo.Y = rectReportLogo.Y * 96 + sngTopMarginIn;

				rectReportLogo.Height = rectReportLogo.Height * 96;
				rectReportLogo.Width = rectReportLogo.Width * 96;

				if (System.IO.File.Exists(mobjstructReportFormat.LogoFileName) == true) {
					imgReportLogoImage = Image.FromFile(mobjstructReportFormat.LogoFileName);
					G.DrawImage(imgReportLogoImage, rectReportLogo);
				} else {
					//'imgReportLogoImage = mobjstructReportFormat.DefaultLogoImage
				}
			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawReportHeader(ref Graphics G, float sngLeftMarginIn, float sngTopMarginIn, ref float sngReportHeaderLineY, enumReportLayoutType intReportLayoutType)
	{
		Drawing.RectangleF rectReportHeader;
		Drawing.RectangleF rectReportHeader2;
		Drawing.RectangleF rectReportHeader3;
		Drawing.RectangleF rectReportHeader4;
		Font ReportHeaderFont;
		Font ReportHeaderFont2;
		Font ReportHeaderFont3;
		Font ReportHeaderFont4;

		float ReportHeaderLineX1 = 0.0;
		float ReportHeaderLineY1 = 0.0;
		float ReportHeaderLineX2 = 0.0;
		float ReportHeaderLineY2 = 0.0;
		string strReportHeader;
		string strReportHeader2;
		string strReportHeader3;
		string strReportHeader4;
		string strInstrumentName;
		//Dim sngReportHeaderLineY As Single

		DataDynamics.ActiveReports.ActiveReport objARLayoutReport;
		try {
			switch (intReportLayoutType) {
				case enumReportLayoutType.Portrate:
					objARLayoutReport = mobjARPortrateReport;
				case enumReportLayoutType.Landscape:
				//objARLayoutReport = mobjARLandScapeReport
			}
			sngReportHeaderLineY = sngTopMarginIn;
			if (mobjstructReportFormat.IsDisplayReportHeader == false) {
				return true;
			}

			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader")).Font;

			rectReportHeader2 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader2")).GetBounds;
			ReportHeaderFont2 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader2")).Font;

			rectReportHeader3 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader3")).GetBounds;
			ReportHeaderFont3 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader3")).Font;

			rectReportHeader4 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader4")).GetBounds;
			ReportHeaderFont4 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader4")).Font;


			rectReportHeader.X = rectReportHeader.X * 96 + sngLeftMarginIn;
			rectReportHeader.Y = rectReportHeader.Y * 96 + sngTopMarginIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;

			rectReportHeader2.X = rectReportHeader2.X * 96 + sngLeftMarginIn;
			rectReportHeader2.Y = rectReportHeader2.Y * 96 + sngTopMarginIn;
			rectReportHeader2.Height = rectReportHeader2.Height * 96;
			rectReportHeader2.Width = rectReportHeader2.Width * 96;

			rectReportHeader3.X = rectReportHeader3.X * 96 + sngLeftMarginIn;
			rectReportHeader3.Y = rectReportHeader3.Y * 96 + sngTopMarginIn;
			rectReportHeader3.Height = rectReportHeader3.Height * 96;
			rectReportHeader3.Width = rectReportHeader3.Width * 96;

			rectReportHeader4.X = rectReportHeader4.X * 96 + sngLeftMarginIn;
			rectReportHeader4.Y = rectReportHeader4.Y * 96 + sngTopMarginIn;
			rectReportHeader4.Height = rectReportHeader4.Height * 96;
			rectReportHeader4.Width = rectReportHeader4.Width * 96;

			//strInstrumentName = "AAS 203"
			//strInstrumentName = m_strSubPageHeader2.TextString

			//strReportHeader = "Chemito Technologies Pvt. Ltd." & vbCrLf & "Satpur MIDC" & vbCrLf & "Nasik"
			strReportHeader = m_strPageHeader.TextString;

			//strReportHeader2 = "AAS 203"
			strReportHeader2 = m_strSubPageHeader2.TextString;

			//strReportHeader3 = "Instrument : " & strInstrumentName & vbCrLf & _
			//"Analyst Name : " & " "
			strReportHeader3 = m_strSubPageHeader2.TextString;

			if (mobjstructReportFormat.IsDisplayReportDate == true) {
				strReportHeader4 = "Date : " + Now.Date.ToLongDateString + vbCrLf + "Time : " + Format(Now(), "hh:mm tt");
			} else {
				strReportHeader4 = "";
			}

			Drawing.Brush objBrush;
			objBrush = new Pen(mobjReportBrush.Color).Brush;
			//Dim HeaderStringFormat As New StringFormat
			//HeaderStringFormat.Alignment = d
			switch (m_strPageHeader.TextFormat.Alignment) {
				case ContentAlignment.BottomCenter:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.TopCenter:
					rectReportHeader.X = (int)Fix((rectReportHeader.X + rectReportHeader.Width) / 2) - 100;
				case ContentAlignment.BottomLeft:
				case ContentAlignment.MiddleLeft:
				case ContentAlignment.TopLeft:
					//CSng(Fix(rectReportHeader.X))
					rectReportHeader.X = (float)Fix(sngLeftMarginIn);
				case ContentAlignment.BottomRight:
				case ContentAlignment.MiddleRight:
				case ContentAlignment.TopRight:
					rectReportHeader.X = (float)(this.PageSetting.PaperSize.Width * 100) - (rectReportHeader.Width + 10);

				default:
			}
			if (!strReportHeader == "") {
				objBrush = new Pen(mobjReportBrush.Color).Brush;
				G.DrawString(strReportHeader, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
				sngReportHeaderLineY = rectReportHeader.Y + rectReportHeader.Height;
			}
			if (!strReportHeader2 == "") {
				objBrush = new Pen(mobjReportBrush.Color).Brush;
				G.DrawString(strReportHeader2, ReportHeaderFont2, objBrush, rectReportHeader2, new StringFormat());
				sngReportHeaderLineY = rectReportHeader2.Y + rectReportHeader2.Height;
			}
			if (!strReportHeader3 == "") {
				objBrush = new Pen(mobjReportBrush.Color).Brush;
				G.DrawString(strReportHeader3, ReportHeaderFont3, objBrush, rectReportHeader3, new StringFormat());
				sngReportHeaderLineY = rectReportHeader3.Y + rectReportHeader3.Height;
			}
			if (!strReportHeader4 == "") {
				objBrush = new Pen(mobjReportBrush.Color).Brush;
				G.DrawString(strReportHeader4, ReportHeaderFont4, objBrush, rectReportHeader4, new StringFormat());
				sngReportHeaderLineY = rectReportHeader4.Y + rectReportHeader4.Height;
			}

			ReportHeaderLineX1 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("ReportHeader").Controls("ReportHeaderLine")).X1 * 96 + sngLeftMarginIn;
			//ReportHeaderLineY1 = CType(objARLayoutReport.Sections("ReportHeader").Controls("ReportHeaderLine"), DataDynamics.ActiveReports.Line).Y1 * 96 + sngTopMarginIn
			ReportHeaderLineX2 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("ReportHeader").Controls("ReportHeaderLine")).X2 * 96 + sngLeftMarginIn;
			//ReportHeaderLineY2 = CType(objARLayoutReport.Sections("ReportHeader").Controls("ReportHeaderLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngTopMarginIn
			ReportHeaderLineY1 = sngReportHeaderLineY;
			ReportHeaderLineY2 = sngReportHeaderLineY;

			G.DrawLine(new Pen(objBrush, 2.5), ReportHeaderLineX1, ReportHeaderLineY1, ReportHeaderLineX2, ReportHeaderLineY2);


			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawReportFooter(ref Graphics G, float sngLeftMarginIn, float sngTopMarginIn, enumReportLayoutType intReportLayoutType)
	{
		Drawing.RectangleF rectReportFooter;
		Drawing.RectangleF rectReportHeader2;
		Drawing.RectangleF rectReportHeader3;
		Drawing.RectangleF rectReportHeader4;
		Font ReportFooterFont;
		Font ReportHeaderFont2;
		Font ReportHeaderFont3;
		Font ReportHeaderFont4;

		float ReportFooterLineX1 = 0.0;
		float ReportFooterLineY1 = 0.0;
		float ReportFooterLineX2 = 0.0;
		float ReportFooterLineY2 = 0.0;
		string strReportFooter;
		Drawing.Brush objBrush;


		DataDynamics.ActiveReports.ActiveReport objARLayoutReport;
		try {
			switch (intReportLayoutType) {
				case enumReportLayoutType.Portrate:
					objARLayoutReport = mobjARPortrateReport;
				case enumReportLayoutType.Landscape:
				//objARLayoutReport = mobjARLandScapeReport
			}

			if (mobjstructReportFormat.IsDisplayReportFooter == false) {
				return true;
			} else {

			}



			//rectReportHeader2 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader2"), DataDynamics.ActiveReports.Label).GetBounds
			//ReportHeaderFont2 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader2"), DataDynamics.ActiveReports.Label).Font

			//rectReportHeader3 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader3"), DataDynamics.ActiveReports.Label).GetBounds
			//ReportHeaderFont3 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader3"), DataDynamics.ActiveReports.Label).Font

			//rectReportHeader4 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader4"), DataDynamics.ActiveReports.Label).GetBounds
			//ReportHeaderFont4 = CType(objARLayoutReport.Sections("ReportHeader").Controls("lblReportHeader4"), DataDynamics.ActiveReports.Label).Font

			ReportFooterLineX1 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine")).X1 * 96 + sngLeftMarginIn;
			ReportFooterLineY1 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine")).Y1 * 96 + sngTopMarginIn;
			//ReportFooterLineY1 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).Y1 * 96 + sngTopMarginIn
			ReportFooterLineX2 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine")).X2 * 96 + sngLeftMarginIn;
			ReportFooterLineY2 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine")).Y2 * 96 + sngTopMarginIn;
			//ReportFooterLineY2 = CType(objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngTopMarginIn

			objBrush = new Pen(mobjReportBrush.Color).Brush;
			G.DrawLine(new Pen(objBrush, 2.5), ReportFooterLineX1, ReportFooterLineY1, ReportFooterLineX2, ReportFooterLineY2);

			rectReportFooter = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("ReportFooter").Controls("lblReportFooter")).GetBounds;
			ReportFooterFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("ReportFooter").Controls("lblReportFooter")).Font;

			rectReportFooter.Y = ReportFooterLineY2 + 6;
			rectReportFooter.X = rectReportFooter.X * 96 + sngLeftMarginIn;
			//rectReportFooter.Y = ReportFooterLineY2 * 96 + sngBottomMarginIn
			rectReportFooter.Height = rectReportFooter.Height * 96;
			rectReportFooter.Width = rectReportFooter.Width * 96;

			//strReportHeader = "Chemito Technologies Pvt. Ltd." & vbCrLf & "Satpur MIDC" & vbCrLf & "Nasik"
			if (!(m_strReportFooter.TextString == null)) {
				strReportFooter = m_strReportFooter.TextString;

				//strReportHeader2 = "AAS 203"


				//strReportHeader3 = "Instrument : " & strInstrumentName & vbCrLf & _
				//"Analyst Name : " & " "

				//If mobjstructReportFormat.IsDisplayReportDate = True Then
				//    strReportHeader4 = "Date : " & Now.Date.ToLongDateString & vbCrLf & _
				//        "Time : " & Format(Now(), "hh:mm tt")
				//Else
				//    strReportHeader4 = ""
				//End If


				//Dim HeaderStringFormat As New StringFormat
				//HeaderStringFormat.Alignment = d
				switch (m_strReportFooter.TextFormat.Alignment) {
					case ContentAlignment.BottomCenter:
					case ContentAlignment.MiddleCenter:
					case ContentAlignment.TopCenter:
						rectReportFooter.X = (int)Fix((rectReportFooter.X + rectReportFooter.Width) / 2) - 100;
					case ContentAlignment.BottomLeft:
					case ContentAlignment.MiddleLeft:
					case ContentAlignment.TopLeft:
						rectReportFooter.X = (float)Fix(rectReportFooter.X);
					case ContentAlignment.BottomRight:
					case ContentAlignment.MiddleRight:
					case ContentAlignment.TopRight:
						rectReportFooter.X = (float)(this.PageSetting.PaperSize.Width * 100) - (rectReportFooter.Width + 10);
				}
				objBrush = new Pen(mobjReportBrush.Color).Brush;
				G.DrawString(strReportFooter, ReportFooterFont, objBrush, rectReportFooter, new StringFormat());
			}
			if (ReportFooterLineY1 > 0) {
				mintPageFooterYPosotion = (int)ReportFooterLineY1;
			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawReportHeader2(ref Graphics G, float sngLeftMarginIn, float sngTopMarginIn, enumReportLayoutType intReportLayoutType)
	{
		Drawing.RectangleF rectReportHeader;
		Drawing.RectangleF rectReportHeader2;
		Drawing.RectangleF rectReportHeader3;
		Drawing.RectangleF rectReportHeader4;
		Font ReportHeaderFont;
		Font ReportHeaderFont2;
		Font ReportHeaderFont3;
		Font ReportHeaderFont4;

		float ReportHeaderLineX1 = 0.0;
		float ReportHeaderLineY1 = 0.0;
		float ReportHeaderLineX2 = 0.0;
		float ReportHeaderLineY2 = 0.0;
		string strReportHeader;
		string strReportHeader2;
		string strReportHeader3;
		string strReportHeader4;
		string strInstrumentName;

		DataDynamics.ActiveReports.ActiveReport objARLayoutReport;
		try {
			switch (intReportLayoutType) {
				case enumReportLayoutType.Portrate:
					objARLayoutReport = mobjARPortrateReport;
				case enumReportLayoutType.Landscape:
				//objARLayoutReport = mobjARLandScapeReport
			}

			rectReportHeader = ((DataDynamics.ActiveReports.TextBox)objARLayoutReport.Sections("Detail").Controls("TextBox1")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.TextBox)objARLayoutReport.Sections("Detail").Controls("TextBox1")).Font;

			rectReportHeader2 = ((DataDynamics.ActiveReports.TextBox)objARLayoutReport.Sections("Detail").Controls("TextBox2")).GetBounds;
			ReportHeaderFont2 = ((DataDynamics.ActiveReports.TextBox)objARLayoutReport.Sections("Detail").Controls("TextBox2")).Font;

			rectReportHeader3 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
			ReportHeaderFont3 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;

			rectReportHeader.X = rectReportHeader.X * 96 + sngLeftMarginIn;
			rectReportHeader.Y = rectReportHeader.Y * 96 + sngTopMarginIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;

			rectReportHeader2.X = rectReportHeader2.X * 96 + sngLeftMarginIn;
			rectReportHeader2.Y = rectReportHeader2.Y * 96 + sngTopMarginIn;
			rectReportHeader2.Height = rectReportHeader2.Height * 96;
			rectReportHeader2.Width = rectReportHeader2.Width * 96;

			rectReportHeader3.X = rectReportHeader3.X * 96 + sngLeftMarginIn;
			rectReportHeader3.Y = rectReportHeader3.Y * 96 + sngTopMarginIn;
			rectReportHeader3.Height = rectReportHeader3.Height * 96;
			rectReportHeader3.Width = rectReportHeader3.Width * 96;

			strReportHeader = "adadadadad";
			strReportHeader2 = "adsadada";
			strReportHeader3 = "dgdgdgdgdgdg";

			Drawing.Brush objBrush;
			objBrush = new Pen(mobjReportBrush.Color).Brush;

			G.DrawString(strReportHeader, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
			objBrush = new Pen(mobjReportBrush.Color).Brush;
			G.DrawString(strReportHeader2, ReportHeaderFont2, objBrush, rectReportHeader2, new StringFormat());
			objBrush = new Pen(mobjReportBrush.Color).Brush;
			G.DrawString(strReportHeader3, ReportHeaderFont3, objBrush, rectReportHeader3, new StringFormat());

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private float funcDrawPageHeader(ref Graphics G, float sngLeftMarginIn, float sngTopMarginIn, ref float sngReportHeaderLineY, enumReportLayoutType intReportLayoutType)
	{
		//Draw the Page Header
		Drawing.RectangleF rectPageHeader;
		Font PageHeaderFont;
		float sectionHeightReportHeader = 0.0;

		Drawing.Brush objBrush;
		objBrush = new Pen(mobjReportBrush.Color).Brush;

		DataDynamics.ActiveReports.ActiveReport objARLayoutReport;
		try {
			switch (intReportLayoutType) {
				case enumReportLayoutType.Portrate:
					objARLayoutReport = mobjARPortrateReport;
				case enumReportLayoutType.Landscape:
				//objARLayoutReport = mobjARLandScapeReport
			}
			if (mobjstructReportFormat.IsDisplayReportHeader == false) {
				return 50;
			}
			//---if section changes then add previous sections Height to the Y-Position.
			//sectionHeightReportHeader = objARLayoutReport.Sections("ReportHeader").Height * 96
			sectionHeightReportHeader = objARLayoutReport.Sections("PageHeader").Height * 96;

			//Draw the Page Header
			rectPageHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("PageHeader").Controls("lblPageHeader")).GetBounds;
			PageHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("PageHeader").Controls("lblPageHeader")).Font;

			rectPageHeader.X = rectPageHeader.X * 96 + sngLeftMarginIn;
			rectPageHeader.Y = sectionHeightReportHeader + sngTopMarginIn;
			//rectPageHeader.Y * 96 *
			rectPageHeader.Height = rectPageHeader.Height * 96;
			//* sectionHeightReportHeader
			rectPageHeader.Width = rectPageHeader.Width * 96;

			//If Not mstrPageHeader = "" Then
			if (!mstrPageHeader == "") {
				G.DrawString(mstrPageHeader, PageHeaderFont, objBrush, rectPageHeader, new StringFormat());
				//Return rectPageHeader.Bottom
				return rectPageHeader.Bottom;

			} else {
				return sngReportHeaderLineY;
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return 0.0;
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

	private bool funcDrawPageFooter(ref Graphics G, float sngLeftMarginIn, float sngBottomMarginIn, enumReportLayoutType intReportLayoutTypeIn)
	{
		Drawing.RectangleF rectPageFooter;
		Font PageFooterFont;
		Drawing.RectangleF rectPageNo;
		Font PageNoFont;
		float PageFooterLineX1 = 0.0;
		float PageFooterLineY1 = 0.0;
		float PageFooterLineX2 = 0.0;
		float PageFooterLineY2 = 0.0;
		string strPageFooter = "";
		string strPageNo = "";
		Drawing.Brush objBrush;

		objBrush = new Pen(mobjReportBrush.Color).Brush;


		try {
			DataDynamics.ActiveReports.ActiveReport objARLayoutReport;
			switch (intReportLayoutTypeIn) {
				case enumReportLayoutType.Portrate:
					objARLayoutReport = mobjARPortrateReport;
				case enumReportLayoutType.Landscape:
				//objARLayoutReport = mobjARLandScapeReport
			}
			if (mobjstructReportFormat.IsDisplayReportFooter == true) {
				PageFooterLineX1 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine")).X1 * 96 + sngLeftMarginIn;
				PageFooterLineY1 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine")).Y1 * 96 + sngBottomMarginIn;
				//ReportFooterLineY2 = CType(objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngTopMarginIn
				PageFooterLineX2 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine")).X2 * 96 + sngLeftMarginIn;
				PageFooterLineY2 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine")).Y2 * 96 + sngBottomMarginIn;
			//G.DrawLine(New Pen(objBrush, 2.5), PageFooterLineX1, PageFooterLineY1, PageFooterLineX2, PageFooterLineY2)
			} else {
				PageFooterLineX1 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine")).X1 * 96 + sngLeftMarginIn;
				PageFooterLineY1 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine")).Y1 * 96 + sngBottomMarginIn;
				//ReportFooterLineY2 = CType(objARLayoutReport.Sections("ReportFooter").Controls("ReportFooterLine"), DataDynamics.ActiveReports.Line).Y2 * 96 + sngTopMarginIn
				PageFooterLineX2 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine")).X2 * 96 + sngLeftMarginIn;
				PageFooterLineY2 = ((DataDynamics.ActiveReports.Line)objARLayoutReport.Sections("PageFooter").Controls("PageFooterLine")).Y2 * 96 + sngBottomMarginIn;
				G.DrawLine(new Pen(objBrush, 2.5), PageFooterLineX1, PageFooterLineY1, PageFooterLineX2, PageFooterLineY2);
			}

			rectPageFooter = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("PageFooter").Controls("lblPageFooter")).GetBounds;
			PageFooterFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("PageFooter").Controls("lblPageFooter")).Font;

			rectPageFooter.X = rectPageFooter.X * 96 + sngLeftMarginIn;
			rectPageFooter.Y = PageFooterLineY2 + 6;

			rectPageFooter.Height = rectPageFooter.Height * 96;
			rectPageFooter.Width = rectPageFooter.Width * 96;



			//strPageFooter = Now.ToLongDateString
			//G.DrawString(strPageFooter, PageFooterFont, objBrush, rectPageFooter, New StringFormat)

			rectPageNo = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("PageFooter").Controls("lblPageNo")).GetBounds;
			PageNoFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("PageFooter").Controls("lblPageNo")).Font;

			////----- Add Page footer as Company Name Instrument Type and Ver info 
			string strInstInfos;
			string strAppVersion;
			strAppVersion = Application.ProductVersion;
			//'get a application product version to string variable.
			strAppVersion = Mid(strAppVersion, 1, 4);
			//strInstInfos = "Thermo " & gstrTitleInstrumentType & "S/W Ver. " & strAppVersion ' commented by : dinesh wagh on 20.3.2009
			strInstInfos = "Thermo Scientific " + gstrTitleInstrumentType + Space(1) + "S/W Ver. " + strAppVersion;
			// added by : dinesh wggh on 20.3.2009

			//rectPageNo.X = rectPageNo.X * 96 + sngLeftMarginIn
			rectPageNo.X = m_PageSetting.Bounds.Width - ((PageNoFont.SizeInPoints * strInstInfos.Length));
			rectPageNo.Y = rectPageFooter.Y - 30;
			rectPageNo.Height = rectPageNo.Height * 96 - 1;
			//rectPageNo.Width = rectPageNo.Width * 96 - 1
			rectPageNo.Width = (PageNoFont.SizeInPoints * strInstInfos.Length);



			G.DrawString(strInstInfos, PageNoFont, objBrush, rectPageNo, new StringFormat());
			//rectPageFooter.Y += rectPageNo.Height
			////-----
			rectPageNo = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("PageFooter").Controls("lblPageNo")).GetBounds;
			rectPageNo.X = rectPageNo.X * 96 + sngLeftMarginIn;
			rectPageNo.Y = rectPageFooter.Y;
			rectPageNo.Height = rectPageNo.Height * 96 - 1;
			rectPageNo.Width = rectPageNo.Width * 96 - 1;

			strPageNo = " Page No. " + mintPageCount.ToString;

			G.DrawString(strPageNo, PageNoFont, objBrush, rectPageNo, new StringFormat());

			////----- Added by Sachin Dokhale on 28.09.05
			mintPageFooterYPosotion = (int)PageFooterLineY1;
			////-----
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawPageText(ref PrintPageEventArgs EV, float sngXPositionIn, ref float sngYPositionIn, int intReportLayoutType)
	{
		string line = null;
		int intCount;
		int linesPerPage;
		Drawing.Brush objBrush;
		bool SetStringBold;
		static bool intIsPageReapate;


		try {
			objBrush = new Pen(mobjReportBrush.Color).Brush;
			// Work out the number of lines per page, using the MarginBounds.
			linesPerPage = (int)EV.MarginBounds.Height / printFont.GetHeight(EV.Graphics);
			//Iterate over the string using the StringReader, printing each line.
			//If (rptPageTextReader.ReadLine()) = True Then
			line = rptPageTextReader.ReadLine();
			//End If
			if (line == "False") {
				line = "";
			}

			Font prnFont = new Font(printFont.Name, printFont.Size, FontStyle.Bold);

			while (intCount < linesPerPage & (null != line)) {
				// calculate the next line position based on 
				// the height of the font according to the printing device
				//'yPosition = topMargin + (count * printFont.GetHeight(EV.Graphics))
				sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));

				////----- Added by Sachin Dokhale on 12.04.06 
				////----- Page text Height count only for if Text line is one  else Page text Height is 0
				////-----  'mintTotalHeightOfPageText' variable use in 'funcDrawShadeCardImages' function
				if (intCount == 0) {
					mintTotalHeightOfPageText = (int)printFont.GetHeight(EV.Graphics);
				} else {
					mintTotalHeightOfPageText = 0;
				}
				////-----

				if (sngYPositionIn >= mintPageFooterYPosotion) {
					if (intIsPageReapate == true) {
						if (blnPageSettingMessage == false) {
							//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
							Application.DoEvents();
							//cWait = New CWaitCursor
						}

						EV.HasMorePages = false;
						EV.Cancel = true;
						return;
					}

					EV.HasMorePages = true;
					intIsPageReapate = true;
					return;
				}

				// draw the next line in the rich edit control


				//EV.Graphics.DrawString(line, printFont, objBrush, sngXPositionIn, sngYPositionIn, New StringFormat)
				string StartString;
				string LastString;


				if (Len(Trim(line)) > 0) {
					StartString = line.Substring(0, 2);

					//StartString = New StartString(Filter(line, "<#", True, CompareMethod.Text))
					if (StartString == "<#") {
						SetStringBold = true;
						line = line.Substring(2, line.Length - 2);
					}

					if (SetStringBold == true) {
						EV.Graphics.DrawString(line, prnFont, objBrush, sngXPositionIn, sngYPositionIn, new StringFormat());
					} else {
						EV.Graphics.DrawString(line, printFont, objBrush, sngXPositionIn, sngYPositionIn, new StringFormat());
					}
				}
				intCount += 1;
				line = rptPageTextReader.ReadLine();
				intIsPageReapate = false;
			}

			if (sngYPositionIn >= mintPageFooterYPosotion) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//Application.DoEvents()
						//cWait = New CWaitCursor
					}

					EV.HasMorePages = false;
					EV.Cancel = true;
					return;
				}

				EV.HasMorePages = true;
				intIsPageReapate = true;
				return;
			}

			intIsPageReapate = true;
			if (!mstrPageText == "") {
				sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));

			}

			// If there are more lines, print another page.
			if (!(line == null)) {
				EV.HasMorePages = true;
			} else {
				EV.HasMorePages = false;
			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawPageText_CookBook(ref PrintPageEventArgs EV, ref float sngYPositionIn, float sngLeftMarginIn, float sngTopMarginIn, float sngBottomMarginIn, int intReportLayoutType)
	{
		string line = null;
		int intCount;
		int linesPerPage;
		Drawing.Brush objBrush;
		bool SetStringBold;
		float sngXPositionIn;
		static bool intIsPageReapate;

		try {
			//Dim objDtExpRptTable As DataTable


			if ((mintReportType == enumReportType.CookBook)) {
				rptPageTextReader = new System.IO.StringReader(mstrPageText);
			}

			objBrush = new Pen(mobjReportBrush.Color).Brush;
			// Work out the number of lines per page, using the MarginBounds.
			linesPerPage = (int)EV.MarginBounds.Height / printFont.GetHeight(EV.Graphics);
			//Iterate over the string using the StringReader, printing each line.
			//If (rptPageTextReader.ReadLine()) = True Then
			line = rptPageTextReader.ReadLine();
			//End If
			if (line == "False") {
				line = "";
			}

			Font prnFont = new Font(printFont.Name, printFont.Size, FontStyle.Bold);

			//While intCount < linesPerPage And (Nothing <> line)
			// calculate the next line position based on 
			// the height of the font according to the printing device
			//'yPosition = topMargin + (count * printFont.GetHeight(EV.Graphics))
			sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));

			////----- Added by Sachin Dokhale on 12.04.06 
			////----- Page text Height count only for if Text line is one  else Page text Height is 0
			////-----  'mintTotalHeightOfPageText' variable use in 'funcDrawShadeCardImages' function
			//If intCount = 0 Then
			mintTotalHeightOfPageText = (int)printFont.GetHeight(EV.Graphics);
			//Else
			//mintTotalHeightOfPageText = 0
			//End If
			////-----

			if (sngYPositionIn >= mintPageFooterYPosotion) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						Application.DoEvents();
						//cWait = New CWaitCursor
					}

					EV.HasMorePages = false;
					//EV.Cancel = True
					return;
				}

				EV.HasMorePages = true;
				intIsPageReapate = true;
				return;
			}

			// draw the next line in the rich edit control


			//EV.Graphics.DrawString(line, printFont, objBrush, sngXPositionIn, sngYPositionIn, New StringFormat)
			string StartString;
			string LastString;

			intCount += 1;

			//line = rptPageTextReader.ReadLine()

			intIsPageReapate = false;
			if (blnFinishElamentInfo == false) {
				if (funcElamentInfo(EV, sngXPositionIn, sngYPositionIn) == false) {
					EV.Cancel = true;
					return;
				}
			}
			if (blnFinishStdSolutionTech == false) {
				if (funcStdSolutionTech(EV, sngXPositionIn, sngYPositionIn) == false) {
					EV.Cancel = true;
					return;
				}
			}
			if (blnFinishWorkingConditionFixed == false) {
				if (funcWorkingConditionFixed(EV, sngXPositionIn, sngYPositionIn) == false) {
					EV.Cancel = true;
					return;
				}
			}
			if (blnFinishWorkingConditionVariable == false) {
				if (funcWorkingConditionVariable(EV, sngXPositionIn, sngYPositionIn, sngLeftMarginIn) == false) {
					EV.Cancel = true;
					return;
				}
			}
			if (blnFinishFlameEmission == false | blnFinishFlameEmissionNotes == false) {
				if (funcFlameEmission(EV, sngXPositionIn, sngYPositionIn) == false) {
					EV.Cancel = true;
					return;
				}
			}
			if (EV.HasMorePages) {
				intIsPageReapate = true;
				return;
			}
			if (blnFinishInterference == false) {
				if (funcInterference(EV, sngXPositionIn, sngYPositionIn) == false) {
					EV.Cancel = true;
					return;
				}
			}
			if (blnFinishInterference == true & intIsPageReapate == false) {
				EV.HasMorePages = false;
				//EV.Cancel = True
				return;
			}


			if (sngYPositionIn >= mintPageFooterYPosotion) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//Application.DoEvents()
						//cWait = New CWaitCursor
					}

					EV.HasMorePages = false;
					//EV.Cancel = True
					return;
				}

				EV.HasMorePages = true;
				intIsPageReapate = true;
				return;
			}

			intIsPageReapate = true;
			//If Not mstrPageText = "" Then
			//    sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
			//End If

			// If there are more lines, print another page.
			//If Not (line Is Nothing) Then
			//    EV.HasMorePages = True
			//Else
			//    EV.HasMorePages = False
			//End If
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawPageText_DataFile(ref PrintPageEventArgs EV, ref float sngYPositionIn, float sngLeftMarginIn, float sngTopMarginIn, float sngBottomMarginIn, int intReportLayoutType)
	{
		string line = null;
		int intCount;
		int linesPerPage;
		Drawing.Brush objBrush;
		bool SetStringBold;
		float sngXPositionIn;
		static bool intIsPageReapate;

		try {
			//Dim objDtExpRptTable As DataTable


			if ((mintReportType == enumReportType.DataFile)) {
				rptPageTextReader = new System.IO.StringReader(mstrPageText);
			}

			objBrush = new Pen(mobjReportBrush.Color).Brush;
			// Work out the number of lines per page, using the MarginBounds.
			linesPerPage = (int)EV.MarginBounds.Height / printFont.GetHeight(EV.Graphics);
			//Iterate over the string using the StringReader, printing each line.
			//If (rptPageTextReader.ReadLine()) = True Then
			line = rptPageTextReader.ReadLine();
			//End If
			if (line == "False") {
				line = "";
			}

			Font prnFont = new Font(printFont.Name, printFont.Size, FontStyle.Bold);

			//While intCount < linesPerPage And (Nothing <> line)
			// calculate the next line position based on 
			// the height of the font according to the printing device
			//'yPosition = topMargin + (count * printFont.GetHeight(EV.Graphics))
			sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));

			////----- Added by Sachin Dokhale on 12.04.06 
			////----- Page text Height count only for if Text line is one  else Page text Height is 0
			////-----  'mintTotalHeightOfPageText' variable use in 'funcDrawShadeCardImages' function
			//If intCount = 0 Then
			mintTotalHeightOfPageText = (int)printFont.GetHeight(EV.Graphics);
			//Else
			//mintTotalHeightOfPageText = 0
			//End If
			////-----

			if (sngYPositionIn >= mintPageFooterYPosotion) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						Application.DoEvents();
						//cWait = New CWaitCursor
					}

					EV.HasMorePages = false;
					EV.Cancel = true;
					return;
				}

				EV.HasMorePages = true;
				intIsPageReapate = true;
				return;
			}

			// draw the next line in the rich edit control


			//EV.Graphics.DrawString(line, printFont, objBrush, sngXPositionIn, sngYPositionIn, New StringFormat)
			string StartString;
			string LastString;

			intCount += 1;

			//line = rptPageTextReader.ReadLine()

			intIsPageReapate = false;
			if (blnFinishElamentInfo == false) {
				//If funcDatafileElamentInfo(EV, sngXPositionIn, sngYPositionIn) = False Then
				//    EV.Cancel = True
				//    Exit Function
				//End If
			}

			//If blnFinishStdSolutionTech = False Then
			//    If funcStdSolutionTech(EV, sngXPositionIn, sngYPositionIn) = False Then
			//        EV.Cancel = True
			//        Exit Function
			//    End If
			//End If
			//If blnFinishWorkingConditionFixed = False Then
			//    If funcWorkingConditionFixed(EV, sngXPositionIn, sngYPositionIn) = False Then
			//        EV.Cancel = True
			//        Exit Function
			//    End If
			//End If
			//If blnFinishWorkingConditionVariable = False Then
			//    If funcWorkingConditionVariable(EV, sngXPositionIn, sngYPositionIn, sngLeftMarginIn) = False Then
			//        EV.Cancel = True
			//        Exit Function
			//    End If
			//End If
			//If blnFinishFlameEmission = False Or blnFinishFlameEmissionNotes = False Then
			//    If funcFlameEmission(EV, sngXPositionIn, sngYPositionIn) = False Then
			//        EV.Cancel = True
			//        Exit Function
			//    End If
			//End If

			if (EV.HasMorePages) {
				intIsPageReapate = true;
				return;
			}
			if (blnFinishInterference == false) {
				if (funcInterference(EV, sngXPositionIn, sngYPositionIn) == false) {
					EV.Cancel = true;
					return;
				}
			}
			if (blnFinishInterference == true & intIsPageReapate == false) {
				EV.HasMorePages = false;
				EV.Cancel = true;
				return;
			}


			if (sngYPositionIn >= mintPageFooterYPosotion) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//Application.DoEvents()
						//cWait = New CWaitCursor
					}

					EV.HasMorePages = false;
					EV.Cancel = true;
					return;
				}

				EV.HasMorePages = true;
				intIsPageReapate = true;
				return;
			}

			intIsPageReapate = true;
			//If Not mstrPageText = "" Then
			//    sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics))
			//End If

			// If there are more lines, print another page.
			//If Not (line Is Nothing) Then
			//    EV.HasMorePages = True
			//Else
			//    EV.HasMorePages = False
			//End If
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawPageText2(ref PrintPageEventArgs EV, float sngXPositionIn, ref float sngYPositionIn, int intReportLayoutType)
	{
		string line = null;
		int intCount;
		int linesPerPage;
		Drawing.Brush objBrush;
		bool SetStringBold;
		static bool intIsPageReapate;
		Drawing.RectangleF rectReportHeader;
		Drawing.RectangleF rectReportHeader2;
		Drawing.RectangleF rectReportHeader3;
		Drawing.RectangleF rectReportHeader4;
		Drawing.RectangleF rectReportHeader5;
		Drawing.RectangleF rectReportHeader6;
		Drawing.RectangleF rectReportHeader7;
		Drawing.RectangleF rectReportHeader8;
		Drawing.RectangleF rectReportHeader9;
		Drawing.RectangleF rectReportHeader10;
		Drawing.RectangleF rectReportHeader11;
		Drawing.RectangleF rectReportHeader12;
		Drawing.RectangleF rectReportHeader13;
		Drawing.RectangleF rectReportHeader14;
		Drawing.RectangleF rectReportHeader15;
		Drawing.RectangleF rectReportHeader16;
		Drawing.RectangleF rectReportHeader17;
		Drawing.RectangleF rectReportHeader18;
		Drawing.RectangleF rectReportHeader19;
		Drawing.RectangleF rectReportHeader20;
		Drawing.RectangleF rectReportHeader21;
		Drawing.RectangleF rectReportHeader22;
		Drawing.RectangleF rectReportHeader23;
		Drawing.RectangleF rectReportHeader24;
		Drawing.RectangleF rectReportHeader25;
		Drawing.RectangleF rectReportHeader26;
		Drawing.RectangleF rectReportHeader27;
		Drawing.RectangleF rectReportHeader28;
		Drawing.RectangleF rectReportHeader29;
		Drawing.RectangleF rectReportHeader30;
		Drawing.RectangleF rectReportHeader31;
		Drawing.RectangleF rectReportHeader32;
		Drawing.RectangleF rectReportHeader33;
		Drawing.RectangleF rectReportHeader34;
		Drawing.RectangleF rectReportHeader35;
		Drawing.RectangleF rectReportHeader36;
		Drawing.RectangleF rectReportHeader37;

		Font ReportHeaderFont;
		Font ReportHeaderFont2;
		Font ReportHeaderFont3;
		Font ReportHeaderFont4;
		Font ReportHeaderFont5;
		Font ReportHeaderFont6;
		Font ReportHeaderFont7;
		Font ReportHeaderFont8;
		Font ReportHeaderFont9;
		Font ReportHeaderFont10;
		Font ReportHeaderFont11;
		Font ReportHeaderFont12;
		Font ReportHeaderFont13;
		Font ReportHeaderFont14;
		Font ReportHeaderFont15;
		Font ReportHeaderFont16;
		Font ReportHeaderFont17;
		Font ReportHeaderFont18;
		Font ReportHeaderFont19;
		Font ReportHeaderFont20;
		Font ReportHeaderFont21;
		Font ReportHeaderFont22;
		Font ReportHeaderFont23;
		Font ReportHeaderFont24;
		Font ReportHeaderFont25;
		Font ReportHeaderFont26;
		Font ReportHeaderFont27;
		Font ReportHeaderFont28;
		Font ReportHeaderFont29;
		Font ReportHeaderFont30;
		Font ReportHeaderFont31;
		Font ReportHeaderFont32;
		Font ReportHeaderFont33;
		Font ReportHeaderFont34;
		Font ReportHeaderFont35;
		Font ReportHeaderFont36;
		Font ReportHeaderFont37;

		float ReportHeaderLineX1 = 0.0;
		float ReportHeaderLineY1 = 0.0;
		float ReportHeaderLineX2 = 0.0;
		float ReportHeaderLineY2 = 0.0;
		string strReportHeader;
		string strReportHeader2;
		string strReportHeader3;
		string strReportHeader4;
		string strReportHeader5;
		string strReportHeader6;
		string strReportHeader7;
		string strReportHeader8;
		string strReportHeader9;
		string strReportHeader10;
		string strReportHeader11;
		string strReportHeader12;
		string strReportHeader13;
		string strReportHeader14;
		string strReportHeader15;
		string strReportHeader16;
		string strReportHeader17;
		string strReportHeader18;
		string strReportHeader19;
		string strReportHeader20;
		string strReportHeader21;
		string strReportHeader22;
		string strReportHeader23;
		string strReportHeader24;
		string strReportHeader25;
		string strReportHeader26;
		string strReportHeader27;
		string strReportHeader28;
		string strReportHeader29;
		string strReportHeader30;
		string strReportHeader31;
		string strReportHeader32;
		string strReportHeader33;
		string strReportHeader34;
		string strReportHeader35;
		string strReportHeader36;
		string strReportHeader37;


		string strInstrumentName;

		DataDynamics.ActiveReports.ActiveReport objARLayoutReport;

		try {
			switch (intReportLayoutType) {
				case enumReportLayoutType.Portrate:
					objARLayoutReport = mobjARPortrateReport;
				case enumReportLayoutType.Landscape:
				//objARLayoutReport = mobjARLandScapeReport
			}

			objBrush = new Pen(mobjReportBrush.Color).Brush;
			// Work out the number of lines per page, using the MarginBounds.
			linesPerPage = (int)EV.MarginBounds.Height / printFont.GetHeight(EV.Graphics);
			1:
			//Iterate over the string using the StringReader, printing each line.
			line = rptPageTextReader.ReadLine();
			if (line == "False") {
				line = "";
			}

			Font prnFont = new Font(printFont.Name, printFont.Size, FontStyle.Bold);

			while (intCount < linesPerPage & (null != line)) {
				// calculate the next line position based on 
				// the height of the font according to the printing device
				sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));

				if (intCount == 0) {
					mintTotalHeightOfPageText = (int)printFont.GetHeight(EV.Graphics);
				} else {
					mintTotalHeightOfPageText = 0;
				}

				if (sngYPositionIn >= mintPageFooterYPosotion) {
					if (intIsPageReapate == true) {
						if (blnPageSettingMessage == false) {
							//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						}

						EV.HasMorePages = false;
						EV.Cancel = true;
						return;
					}

					EV.HasMorePages = true;
					intIsPageReapate = true;
					return;
				}


				if (Len(Trim(line)) > 0) {
					rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblElement")).GetBounds;
					ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblElement")).Font;

					rectReportHeader2 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblAtWt")).GetBounds;
					ReportHeaderFont2 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblAtWt")).Font;

					rectReportHeader3 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader1")).GetBounds;
					ReportHeaderFont3 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader1")).Font;

					rectReportHeader4 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
					ReportHeaderFont4 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

					rectReportHeader5 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
					ReportHeaderFont5 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;

					rectReportHeader6 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader3")).GetBounds;
					ReportHeaderFont6 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader3")).Font;

					rectReportHeader7 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label3")).GetBounds;
					ReportHeaderFont7 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label3")).Font;

					rectReportHeader8 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader4")).GetBounds;
					ReportHeaderFont8 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader4")).Font;

					rectReportHeader9 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader5")).GetBounds;
					ReportHeaderFont9 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader5")).Font;

					rectReportHeader10 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblLampCurr")).GetBounds;
					ReportHeaderFont10 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblLampCurr")).Font;

					rectReportHeader11 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblLampCurrVal")).GetBounds;
					ReportHeaderFont11 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblLampCurrVal")).Font;

					rectReportHeader12 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFuel")).GetBounds;
					ReportHeaderFont12 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFuel")).Font;

					rectReportHeader13 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFuelVal")).GetBounds;
					ReportHeaderFont13 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFuelVal")).Font;

					rectReportHeader14 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblSupport")).GetBounds;
					ReportHeaderFont14 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblSupport")).Font;

					rectReportHeader15 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblSupportVal")).GetBounds;
					ReportHeaderFont15 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblSupportVal")).Font;

					rectReportHeader16 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFlameSto")).GetBounds;
					ReportHeaderFont16 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFlameSto")).Font;

					rectReportHeader17 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFlameStoVal")).GetBounds;
					ReportHeaderFont17 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFlameStoVal")).Font;

					rectReportHeader18 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader6")).GetBounds;
					ReportHeaderFont18 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader6")).Font;

					rectReportHeader19 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label4")).GetBounds;
					ReportHeaderFont19 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label4")).Font;

					rectReportHeader20 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblWorking")).GetBounds;
					ReportHeaderFont20 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblWorking")).Font;

					rectReportHeader21 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblWorking1")).GetBounds;
					ReportHeaderFont21 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblWorking1")).Font;

					rectReportHeader22 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblWavelength")).GetBounds;
					ReportHeaderFont22 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblWavelength")).Font;

					rectReportHeader23 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblSpectral")).GetBounds;
					ReportHeaderFont23 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblSpectral")).Font;

					rectReportHeader24 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblOptimumWorkingRange")).GetBounds;
					ReportHeaderFont24 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblOptimumWorkingRange")).Font;

					rectReportHeader25 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblNote")).GetBounds;
					ReportHeaderFont25 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblNote")).Font;

					rectReportHeader26 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblNoteVal")).GetBounds;
					ReportHeaderFont26 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblNoteVal")).Font;

					rectReportHeader27 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFlame")).GetBounds;
					ReportHeaderFont27 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFlame")).Font;

					rectReportHeader28 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblWavelength1")).GetBounds;
					ReportHeaderFont28 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblWavelength1")).Font;

					rectReportHeader29 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblWavelength1Val")).GetBounds;
					ReportHeaderFont29 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblWavelength1Val")).Font;

					rectReportHeader30 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblBandwidth")).GetBounds;
					ReportHeaderFont30 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblBandwidth")).Font;

					rectReportHeader31 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblBandwidthVal")).GetBounds;
					ReportHeaderFont31 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblBandwidthVal")).Font;

					rectReportHeader32 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFuel1")).GetBounds;
					ReportHeaderFont32 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFuel1")).Font;

					rectReportHeader33 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFuel1Val")).GetBounds;
					ReportHeaderFont33 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblFuel1Val")).Font;

					rectReportHeader34 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblSupport1")).GetBounds;
					ReportHeaderFont34 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblSupport1")).Font;

					rectReportHeader35 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblSupport1Val")).GetBounds;
					ReportHeaderFont35 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblSupport1Val")).Font;

					rectReportHeader36 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblNote1")).GetBounds;
					ReportHeaderFont36 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblNote1")).Font;

					rectReportHeader37 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblNote1Val")).GetBounds;
					ReportHeaderFont37 = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblNote1Val")).Font;

					rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn;
					rectReportHeader.Y = rectReportHeader.Y * 96 + sngYPositionIn;
					rectReportHeader.Height = rectReportHeader.Height * 96;
					rectReportHeader.Width = rectReportHeader.Width * 96;

					rectReportHeader2.X = rectReportHeader2.X * 96 + sngXPositionIn;
					rectReportHeader2.Y = rectReportHeader2.Y * 96 + sngYPositionIn;
					rectReportHeader2.Height = rectReportHeader2.Height * 96;
					rectReportHeader2.Width = rectReportHeader2.Width * 96;

					rectReportHeader3.X = rectReportHeader3.X * 96 + sngXPositionIn;
					rectReportHeader3.Y = rectReportHeader3.Y * 96 + sngYPositionIn;
					rectReportHeader3.Height = rectReportHeader3.Height * 96;
					rectReportHeader3.Width = rectReportHeader3.Width * 96;

					rectReportHeader4.X = rectReportHeader4.X * 96 + sngXPositionIn;
					rectReportHeader4.Y = rectReportHeader4.Y * 96 + sngYPositionIn;
					rectReportHeader4.Height = rectReportHeader4.Height * 96;
					rectReportHeader4.Width = rectReportHeader4.Width * 96;

					rectReportHeader5.X = rectReportHeader5.X * 96 + sngXPositionIn;
					rectReportHeader5.Y = rectReportHeader5.Y * 96 + sngYPositionIn;
					rectReportHeader5.Height = rectReportHeader5.Height * 96;
					rectReportHeader5.Width = rectReportHeader5.Width * 96;

					rectReportHeader6.X = rectReportHeader6.X * 96 + sngXPositionIn;
					rectReportHeader6.Y = rectReportHeader6.Y * 96 + sngYPositionIn;
					rectReportHeader6.Height = rectReportHeader6.Height * 96;
					rectReportHeader6.Width = rectReportHeader6.Width * 96;

					rectReportHeader7.X = rectReportHeader7.X * 96 + sngXPositionIn;
					rectReportHeader7.Y = rectReportHeader7.Y * 96 + sngYPositionIn;
					rectReportHeader7.Height = rectReportHeader7.Height * 96;
					rectReportHeader7.Width = rectReportHeader7.Width * 96;


					rectReportHeader8.X = rectReportHeader8.X * 96 + sngXPositionIn;
					rectReportHeader8.Y = rectReportHeader8.Y * 96 + sngYPositionIn;
					rectReportHeader8.Height = rectReportHeader8.Height * 96;
					rectReportHeader8.Width = rectReportHeader8.Width * 96;

					rectReportHeader9.X = rectReportHeader9.X * 96 + sngXPositionIn;
					rectReportHeader9.Y = rectReportHeader9.Y * 96 + sngYPositionIn;
					rectReportHeader9.Height = rectReportHeader9.Height * 96;
					rectReportHeader9.Width = rectReportHeader9.Width * 96;

					rectReportHeader10.X = rectReportHeader10.X * 96 + sngXPositionIn;
					rectReportHeader10.Y = rectReportHeader10.Y * 96 + sngYPositionIn;
					rectReportHeader10.Height = rectReportHeader10.Height * 96;
					rectReportHeader10.Width = rectReportHeader10.Width * 96;

					rectReportHeader11.X = rectReportHeader11.X * 96 + sngXPositionIn;
					rectReportHeader11.Y = rectReportHeader11.Y * 96 + sngYPositionIn;
					rectReportHeader11.Height = rectReportHeader11.Height * 96;
					rectReportHeader11.Width = rectReportHeader11.Width * 96;

					rectReportHeader12.X = rectReportHeader12.X * 96 + sngXPositionIn;
					rectReportHeader12.Y = rectReportHeader12.Y * 96 + sngYPositionIn;
					rectReportHeader12.Height = rectReportHeader12.Height * 96;
					rectReportHeader12.Width = rectReportHeader12.Width * 96;

					rectReportHeader13.X = rectReportHeader13.X * 96 + sngXPositionIn;
					rectReportHeader13.Y = rectReportHeader13.Y * 96 + sngYPositionIn;
					rectReportHeader13.Height = rectReportHeader13.Height * 96;
					rectReportHeader13.Width = rectReportHeader13.Width * 96;

					rectReportHeader14.X = rectReportHeader14.X * 96 + sngXPositionIn;
					rectReportHeader14.Y = rectReportHeader14.Y * 96 + sngYPositionIn;
					rectReportHeader14.Height = rectReportHeader14.Height * 96;
					rectReportHeader14.Width = rectReportHeader14.Width * 96;

					rectReportHeader15.X = rectReportHeader15.X * 96 + sngXPositionIn;
					rectReportHeader15.Y = rectReportHeader15.Y * 96 + sngYPositionIn;
					rectReportHeader15.Height = rectReportHeader15.Height * 96;
					rectReportHeader15.Width = rectReportHeader15.Width * 96;

					rectReportHeader16.X = rectReportHeader16.X * 96 + sngXPositionIn;
					rectReportHeader16.Y = rectReportHeader16.Y * 96 + sngYPositionIn;
					rectReportHeader16.Height = rectReportHeader16.Height * 96;
					rectReportHeader16.Width = rectReportHeader16.Width * 96;

					rectReportHeader17.X = rectReportHeader17.X * 96 + sngXPositionIn;
					rectReportHeader17.Y = rectReportHeader17.Y * 96 + sngYPositionIn;
					rectReportHeader17.Height = rectReportHeader17.Height * 96;
					rectReportHeader17.Width = rectReportHeader17.Width * 96;

					rectReportHeader18.X = rectReportHeader18.X * 96 + sngXPositionIn;
					rectReportHeader18.Y = rectReportHeader18.Y * 96 + sngYPositionIn;
					rectReportHeader18.Height = rectReportHeader18.Height * 96;
					rectReportHeader18.Width = rectReportHeader18.Width * 96;

					rectReportHeader19.X = rectReportHeader19.X * 96 + sngXPositionIn;
					rectReportHeader19.Y = rectReportHeader19.Y * 96 + sngYPositionIn;
					rectReportHeader19.Height = rectReportHeader19.Height * 96;
					rectReportHeader19.Width = rectReportHeader19.Width * 96;

					rectReportHeader20.X = rectReportHeader20.X * 96 + sngXPositionIn;
					rectReportHeader20.Y = rectReportHeader20.Y * 96 + sngYPositionIn;
					rectReportHeader20.Height = rectReportHeader20.Height * 96;
					rectReportHeader20.Width = rectReportHeader20.Width * 96;

					rectReportHeader21.X = rectReportHeader21.X * 96 + sngXPositionIn;
					rectReportHeader21.Y = rectReportHeader21.Y * 96 + sngYPositionIn;
					rectReportHeader21.Height = rectReportHeader21.Height * 96;
					rectReportHeader21.Width = rectReportHeader21.Width * 96;

					rectReportHeader22.X = rectReportHeader22.X * 96 + sngXPositionIn;
					rectReportHeader22.Y = rectReportHeader22.Y * 96 + sngYPositionIn;
					rectReportHeader22.Height = rectReportHeader22.Height * 96;
					rectReportHeader22.Width = rectReportHeader22.Width * 96;

					rectReportHeader23.X = rectReportHeader23.X * 96 + sngXPositionIn;
					rectReportHeader23.Y = rectReportHeader23.Y * 96 + sngYPositionIn;
					rectReportHeader23.Height = rectReportHeader23.Height * 96;
					rectReportHeader23.Width = rectReportHeader23.Width * 96;

					rectReportHeader24.X = rectReportHeader24.X * 96 + sngXPositionIn;
					rectReportHeader24.Y = rectReportHeader24.Y * 96 + sngYPositionIn;
					rectReportHeader24.Height = rectReportHeader24.Height * 96;
					rectReportHeader24.Width = rectReportHeader24.Width * 96;

					rectReportHeader25.X = rectReportHeader25.X * 96 + sngXPositionIn;
					rectReportHeader25.Y = rectReportHeader25.Y * 96 + sngYPositionIn;
					rectReportHeader25.Height = rectReportHeader25.Height * 96;
					rectReportHeader25.Width = rectReportHeader25.Width * 96;

					rectReportHeader26.X = rectReportHeader26.X * 96 + sngXPositionIn;
					rectReportHeader26.Y = rectReportHeader26.Y * 96 + sngYPositionIn;
					rectReportHeader26.Height = rectReportHeader26.Height * 96;
					rectReportHeader26.Width = rectReportHeader26.Width * 96;

					rectReportHeader27.X = rectReportHeader27.X * 96 + sngXPositionIn;
					rectReportHeader27.Y = rectReportHeader27.Y * 96 + sngYPositionIn;
					rectReportHeader27.Height = rectReportHeader27.Height * 96;
					rectReportHeader27.Width = rectReportHeader27.Width * 96;

					rectReportHeader28.X = rectReportHeader28.X * 96 + sngXPositionIn;
					rectReportHeader28.Y = rectReportHeader28.Y * 96 + sngYPositionIn;
					rectReportHeader28.Height = rectReportHeader28.Height * 96;
					rectReportHeader28.Width = rectReportHeader28.Width * 96;

					rectReportHeader29.X = rectReportHeader29.X * 96 + sngXPositionIn;
					rectReportHeader29.Y = rectReportHeader29.Y * 96 + sngYPositionIn;
					rectReportHeader29.Height = rectReportHeader29.Height * 96;
					rectReportHeader29.Width = rectReportHeader29.Width * 96;

					rectReportHeader30.X = rectReportHeader30.X * 96 + sngXPositionIn;
					rectReportHeader30.Y = rectReportHeader30.Y * 96 + sngYPositionIn;
					rectReportHeader30.Height = rectReportHeader30.Height * 96;
					rectReportHeader30.Width = rectReportHeader30.Width * 96;

					rectReportHeader31.X = rectReportHeader31.X * 96 + sngXPositionIn;
					rectReportHeader31.Y = rectReportHeader31.Y * 96 + sngYPositionIn;
					rectReportHeader31.Height = rectReportHeader31.Height * 96;
					rectReportHeader31.Width = rectReportHeader31.Width * 96;

					rectReportHeader32.X = rectReportHeader32.X * 96 + sngXPositionIn;
					rectReportHeader32.Y = rectReportHeader32.Y * 96 + sngYPositionIn;
					rectReportHeader32.Height = rectReportHeader32.Height * 96;
					rectReportHeader32.Width = rectReportHeader32.Width * 96;

					rectReportHeader33.X = rectReportHeader33.X * 96 + sngXPositionIn;
					rectReportHeader33.Y = rectReportHeader33.Y * 96 + sngYPositionIn;
					rectReportHeader33.Height = rectReportHeader33.Height * 96;
					rectReportHeader33.Width = rectReportHeader33.Width * 96;

					rectReportHeader34.X = rectReportHeader34.X * 96 + sngXPositionIn;
					rectReportHeader34.Y = rectReportHeader34.Y * 96 + sngYPositionIn;
					rectReportHeader34.Height = rectReportHeader34.Height * 96;
					rectReportHeader34.Width = rectReportHeader34.Width * 96;

					rectReportHeader35.X = rectReportHeader35.X * 96 + sngXPositionIn;
					rectReportHeader35.Y = rectReportHeader35.Y * 96 + sngYPositionIn;
					rectReportHeader35.Height = rectReportHeader35.Height * 96;
					rectReportHeader35.Width = rectReportHeader35.Width * 96;

					rectReportHeader36.X = rectReportHeader36.X * 96 + sngXPositionIn;
					rectReportHeader36.Y = rectReportHeader36.Y * 96 + sngYPositionIn;
					rectReportHeader36.Height = rectReportHeader36.Height * 96;
					rectReportHeader36.Width = rectReportHeader36.Width * 96;

					rectReportHeader37.X = rectReportHeader37.X * 96 + sngXPositionIn;
					rectReportHeader37.Y = rectReportHeader37.Y * 96 + sngYPositionIn;
					rectReportHeader37.Height = rectReportHeader37.Height * 96;
					rectReportHeader37.Width = rectReportHeader37.Width * 96;

					strReportHeader = "Ag (Silver)";
					strReportHeader2 = "At.Wt. 120";
					strReportHeader3 = "Preparation Of Standard Solution";
					strReportHeader4 = "Recommended Standard";
					strReportHeader5 = "Silver metal strip or wire 99.99%";
					strReportHeader6 = "Solution Technique";
					strReportHeader7 = "Dissolve 1.000 gram of Silver.....";
					strReportHeader8 = "RECOMEMDED INSTRUMENT";
					strReportHeader9 = "Atomic Absorption";
					strReportHeader10 = "Lamp";
					strReportHeader11 = "4.0";
					strReportHeader12 = "Fuel";
					strReportHeader13 = "Acetylene";
					strReportHeader14 = "Support";
					strReportHeader15 = "Air";
					strReportHeader16 = "Flame";
					strReportHeader17 = "Oxidising";
					strReportHeader18 = "INTERFERENCE";
					strReportHeader19 = "asfgas dfasd fasfaf asfa  adfsdf asdf hdfh asdg hfahd fuhas dfiou dhfuh udfh au iodhf hdf uhdufhj sdhf jks dhfjh dsf dfhu ahf uhd fuhad uifh";
					strReportHeader20 = "Working";
					strReportHeader21 = "Working";
					strReportHeader22 = "Wavelength";
					strReportHeader23 = "Spectral";
					strReportHeader24 = "Optimum Working Range";
					strReportHeader25 = "Note :";
					strReportHeader26 = "At.Wt. 120";
					strReportHeader27 = "Flame";
					strReportHeader28 = "Wavelength";
					strReportHeader29 = "422.70 nm";
					strReportHeader30 = "Bandwidth";
					strReportHeader31 = "0.2 nm";
					strReportHeader32 = "Fuel";
					strReportHeader33 = "Acetylene";
					strReportHeader34 = "Support";
					strReportHeader35 = "Nitrous Oxide";
					strReportHeader36 = "Note :";
					strReportHeader37 = "At.Wt. 120";


					objBrush = new Pen(mobjReportBrushBlack.Color).Brush;
					EV.Graphics.DrawString(strReportHeader, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
					objBrush = new Pen(mobjReportBrushBlack.Color).Brush;
					EV.Graphics.DrawString(strReportHeader2, ReportHeaderFont2, objBrush, rectReportHeader2, new StringFormat());
					objBrush = new Pen(mobjReportBrushRed.Color).Brush;
					EV.Graphics.DrawString(strReportHeader3, ReportHeaderFont3, objBrush, rectReportHeader3, new StringFormat());
					objBrush = new Pen(mobjReportBrushBlue.Color).Brush;
					EV.Graphics.DrawString(strReportHeader4, ReportHeaderFont4, objBrush, rectReportHeader4, new StringFormat());
					objBrush = new Pen(mobjReportBrushBlack.Color).Brush;
					EV.Graphics.DrawString(strReportHeader5, ReportHeaderFont5, objBrush, rectReportHeader5, new StringFormat());
					objBrush = new Pen(mobjReportBrushBlue.Color).Brush;
					EV.Graphics.DrawString(strReportHeader6, ReportHeaderFont6, objBrush, rectReportHeader6, new StringFormat());
					objBrush = new Pen(mobjReportBrushBlack.Color).Brush;
					EV.Graphics.DrawString(strReportHeader7, ReportHeaderFont7, objBrush, rectReportHeader7, new StringFormat());
					objBrush = new Pen(mobjReportBrushRed.Color).Brush;
					EV.Graphics.DrawString(strReportHeader8, ReportHeaderFont8, objBrush, rectReportHeader8, new StringFormat());
					objBrush = new Pen(mobjReportBrushBlue.Color).Brush;
					EV.Graphics.DrawString(strReportHeader9, ReportHeaderFont9, objBrush, rectReportHeader9, new StringFormat());
					EV.Graphics.DrawString(strReportHeader10, ReportHeaderFont10, objBrush, rectReportHeader10, new StringFormat());
					objBrush = new Pen(mobjReportBrushBlack.Color).Brush;
					EV.Graphics.DrawString(strReportHeader11, ReportHeaderFont11, objBrush, rectReportHeader11, new StringFormat());
					EV.Graphics.DrawString(strReportHeader13, ReportHeaderFont13, objBrush, rectReportHeader13, new StringFormat());
					EV.Graphics.DrawString(strReportHeader15, ReportHeaderFont15, objBrush, rectReportHeader15, new StringFormat());
					EV.Graphics.DrawString(strReportHeader17, ReportHeaderFont17, objBrush, rectReportHeader17, new StringFormat());
					EV.Graphics.DrawString(strReportHeader19, ReportHeaderFont19, objBrush, rectReportHeader19, new StringFormat());
					objBrush = new Pen(mobjReportBrushBlue.Color).Brush;
					EV.Graphics.DrawString(strReportHeader12, ReportHeaderFont12, objBrush, rectReportHeader12, new StringFormat());
					EV.Graphics.DrawString(strReportHeader14, ReportHeaderFont14, objBrush, rectReportHeader14, new StringFormat());
					EV.Graphics.DrawString(strReportHeader16, ReportHeaderFont16, objBrush, rectReportHeader16, new StringFormat());
					objBrush = new Pen(mobjReportBrushRed.Color).Brush;
					EV.Graphics.DrawString(strReportHeader18, ReportHeaderFont18, objBrush, rectReportHeader18, new StringFormat());
					objBrush = new Pen(mobjReportBrushBlack.Color).Brush;
					EV.Graphics.DrawString(strReportHeader20, ReportHeaderFont20, objBrush, rectReportHeader20, new StringFormat());
					EV.Graphics.DrawString(strReportHeader21, ReportHeaderFont21, objBrush, rectReportHeader21, new StringFormat());
					EV.Graphics.DrawString(strReportHeader22, ReportHeaderFont22, objBrush, rectReportHeader22, new StringFormat());
					EV.Graphics.DrawString(strReportHeader23, ReportHeaderFont23, objBrush, rectReportHeader23, new StringFormat());
					EV.Graphics.DrawString(strReportHeader24, ReportHeaderFont24, objBrush, rectReportHeader24, new StringFormat());
					EV.Graphics.DrawString(strReportHeader25, ReportHeaderFont25, objBrush, rectReportHeader25, new StringFormat());
					EV.Graphics.DrawString(strReportHeader26, ReportHeaderFont26, objBrush, rectReportHeader26, new StringFormat());
					EV.Graphics.DrawString(strReportHeader27, ReportHeaderFont27, objBrush, rectReportHeader27, new StringFormat());
					EV.Graphics.DrawString(strReportHeader28, ReportHeaderFont28, objBrush, rectReportHeader28, new StringFormat());
					EV.Graphics.DrawString(strReportHeader29, ReportHeaderFont29, objBrush, rectReportHeader29, new StringFormat());
					EV.Graphics.DrawString(strReportHeader30, ReportHeaderFont30, objBrush, rectReportHeader30, new StringFormat());
					EV.Graphics.DrawString(strReportHeader31, ReportHeaderFont31, objBrush, rectReportHeader31, new StringFormat());
					EV.Graphics.DrawString(strReportHeader32, ReportHeaderFont32, objBrush, rectReportHeader32, new StringFormat());
					EV.Graphics.DrawString(strReportHeader33, ReportHeaderFont33, objBrush, rectReportHeader33, new StringFormat());
					EV.Graphics.DrawString(strReportHeader34, ReportHeaderFont34, objBrush, rectReportHeader34, new StringFormat());
					EV.Graphics.DrawString(strReportHeader35, ReportHeaderFont35, objBrush, rectReportHeader35, new StringFormat());
					EV.Graphics.DrawString(strReportHeader36, ReportHeaderFont36, objBrush, rectReportHeader36, new StringFormat());
					EV.Graphics.DrawString(strReportHeader37, ReportHeaderFont37, objBrush, rectReportHeader37, new StringFormat());

				}
				intCount += 1;
				line = rptPageTextReader.ReadLine();
				intIsPageReapate = false;
			}

			if (sngYPositionIn >= mintPageFooterYPosotion) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
					}

					EV.HasMorePages = false;
					EV.Cancel = true;
					return;
				}

				EV.HasMorePages = true;
				intIsPageReapate = true;
				return;
			}

			intIsPageReapate = true;
			if (!mstrPageText == "") {
				sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));
			}

			// If there are more lines, print on another page.
			if (!(line == null)) {
				EV.HasMorePages = true;
			} else {
				EV.HasMorePages = false;
			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawGridTables(ref PrintPageEventArgs EV, ref float sngYPositionIn, float sngLeftMarginIn)
	{
		RectangleF rectGridData;
		bool blnIsNextPage;
		float sngHeightPosition;
		float sngHeightOfTableData;
		float msngHeightOfHeader;
		Drawing.Color clrMangeta;
		Drawing.Color FontColor;
		SolidBrush hfBrush = new SolidBrush(Color.Black);
		Font objPrint_Font;
		objPrint_Font = printFont;

		try {
			rectGridData.X += sngLeftMarginIn;
			rectGridData.Y += sngYPositionIn;
			////----- Added & Modified by Sachin Dokhale on 28.09.05
			rectGridData.Height = EV.MarginBounds.Height - sngYPositionIn;
			//- mintPageFooterYPosotion

			rectGridData.Width = EV.MarginBounds.Width;

			if (IsNothing(this.mobjRptDataTblList) == true) {
				EV.HasMorePages = false;
				return;
			}
			////-----
			if (gstructSettings.blnSelectColorPrinter == false) {
				FontColor = clrMangeta.Black;
			} else {
				FontColor = clrMangeta.Magenta;
			}
			hfBrush.Color = FontColor;
			while (mintReportTablesCount < this.mobjRptDataTblList.Count) {
				printFont = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("lblHeader")).Font;
				//EV.Graphics.DrawString(CType(Me.mobjRptDataTblList.Item(mintReportTablesCount), DataTable).TableName, printFont, New Pen(Color.Black).Brush, rectGridData.X, rectGridData.Y)
				EV.Graphics.DrawString(((DataTable)this.mobjRptDataTblList.Item(mintReportTablesCount)).TableName, printFont, hfBrush, rectGridData.X, rectGridData.Y);
				rectGridData.Y += EV.Graphics.MeasureString(((DataTable)this.mobjRptDataTblList.Item(mintReportTablesCount)).TableName, printFont).Height;

				DataGridPrintPage(EV, rectGridData, (DataTable)this.mobjRptDataTblList.Item(mintReportTablesCount), mintReportType, blnIsNextPage, sngHeightPosition);

				////----- Added & Modified by Sachin Dokhale on 28.09.05
				//---Increment GridRect Location 
				sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, (DataTable)this.mobjRptDataTblList.Item(mintReportTablesCount), printFont, msngHeightOfHeader);

				//rectGridData.Y += sngHeightOfTableData + lineSpacing + printFont.GetHeight(EV.Graphics)
				rectGridData.Y += sngHeightPosition + lineSpacing + printFont.GetHeight(EV.Graphics);
				sngYPositionIn = rectGridData.Y;

				//If EV.HasMorePages = False Then
				if (blnIsNextPage == false & NextFirstCol > 0) {
					if (!mintReportTablesCount == this.mobjRptDataTblList.Count) {
						sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, (DataTable)this.mobjRptDataTblList.Item(mintReportTablesCount), printFont, msngHeightOfHeader);
						rectGridData.Y += 2 * (lineSpacing + printFont.GetHeight(EV.Graphics));

						if ((mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics))) {
							//---Continue printing on same page
							EV.HasMorePages = false;


						} else {
							//---go to the new page

							EV.HasMorePages = true;
							return true;
							return;
						}
					}

				} else if (blnIsNextPage == false) {
					////-----
					mintReportTablesCount += 1;
					NextFirstCol = 0;
					npp = 0;
					CurRow = 0;
					CurCol = 0;
					EV.HasMorePages = false;
					if (!mintReportTablesCount == this.mobjRptDataTblList.Count) {
						sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, (DataTable)this.mobjRptDataTblList.Item(mintReportTablesCount), printFont, msngHeightOfHeader);
						rectGridData.Y += 2 * (lineSpacing + printFont.GetHeight(EV.Graphics));

						if ((mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics))) {
							//---Continue printing on same page
							EV.HasMorePages = false;
							if (blnPageSettingMessage == true) {
								EV.Cancel = true;
							}

						} else {
							//---go to the new page

							EV.HasMorePages = true;

							return true;
							return;
						}
					} else {
						if (blnPageSettingMessage == true) {
							EV.Cancel = true;
						}
					}

				} else {
					////----- Added & Modified by Sachin Dokhale on 28.09.05
					EV.HasMorePages = blnIsNextPage;
					if (blnPageSettingMessage == true) {
						EV.Cancel = true;
					}
					return true;
					////-----
				}
			}
			mintReportTablesCount = 0;
			mintReportTextTableCount = -1;
			EV.HasMorePages = false;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//--------------------------------------------------------
			printFont = objPrint_Font;
		}
	}


	private bool funcDrawTextList(ref PrintPageEventArgs EV, ref float sngYPositionIn, float sngLeftMarginIn)
	{
		RectangleF rectGridData;
		bool blnIsNextPage;
		float sngHeightPosition;
		float sngHeightOfTableData;
		float msngHeightOfHeader;

		try {
			rectGridData.X += sngLeftMarginIn;
			rectGridData.Y += sngYPositionIn;
			////----- Added & Modified by Sachin Dokhale on 28.09.05
			rectGridData.Height = EV.MarginBounds.Height - sngYPositionIn;
			//- mintPageFooterYPosotion

			rectGridData.Width = EV.MarginBounds.Width;

			if (IsNothing(this.mobjRptDataTblList) == true | (mintReportTextTableCount == -1)) {
				EV.HasMorePages = false;
				return;
			}
			////-----


			while (mintReportTextTableCount < this.mobjRptDtTextList.Count) {
				//EV.Graphics.DrawString(CType(Me.mobjRptDtTextList.Item(mintReportTablesCount), DataTable).TableName, printFont, New Pen(Color.Black).Brush, rectGridData.X, rectGridData.Y)
				//rectGridData.Y += EV.Graphics.MeasureString(CType(Me.mobjRptDtTextList.Item(mintReportTablesCount), DataTable).TableName, printFont).Height
				TextListPrintPage(EV, rectGridData, (DataTable)this.mobjRptDtTextList.Item(mintReportTextTableCount), mintReportType, blnIsNextPage, sngHeightPosition);

				////----- Added & Modified by Sachin Dokhale on 28.09.05
				//---Increment GridRect Location 

				sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, (DataTable)this.mobjRptDtTextList.Item(mintReportTextTableCount), printFont, msngHeightOfHeader);

				//rectGridData.Y += sngHeightOfTableData + lineSpacing + printFont.GetHeight(EV.Graphics)
				rectGridData.Y += sngHeightPosition;
				//+ lineSpacing + printFont.GetHeight(EV.Graphics)
				sngYPositionIn = rectGridData.Y;

				//If EV.HasMorePages = False Then
				if (blnIsNextPage == false & NextFirstCol > 0) {
					if (!mintReportTextTableCount == this.mobjRptDtTextList.Count) {
						sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, (DataTable)this.mobjRptDtTextList.Item(mintReportTextTableCount), printFont, msngHeightOfHeader);
						rectGridData.Y += 1 * (lineSpacing + printFont.GetHeight(EV.Graphics));

						if ((mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics))) {
							//---Continue printing on same page
							EV.HasMorePages = false;
						} else {
							//---go to the new page

							EV.HasMorePages = true;
							return true;
							return;
						}
					}
				} else if (blnIsNextPage == false) {
					////-----
					mintReportTextTableCount += 1;
					NextFirstCol = 0;
					npp = 0;
					CurRow = 0;
					CurCol = 0;
					EV.HasMorePages = false;
					if (!mintReportTextTableCount == this.mobjRptDtTextList.Count) {
						sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, (DataTable)this.mobjRptDtTextList.Item(mintReportTextTableCount), printFont, msngHeightOfHeader);
						rectGridData.Y += 1 * (lineSpacing + printFont.GetHeight(EV.Graphics));

						if ((mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics))) {
							//---Continue printing on same page
							EV.HasMorePages = false;
							if (blnPageSettingMessage == true) {
								EV.Cancel = true;
							}

						} else {
							//---go to the new page

							EV.HasMorePages = true;

							return true;
							return;
						}
					} else {
						if (blnPageSettingMessage == true) {
							EV.Cancel = true;
						}
					}

				} else {
					////----- Added & Modified by Sachin Dokhale on 28.09.05
					EV.HasMorePages = blnIsNextPage;
					if (blnPageSettingMessage == true) {
						EV.Cancel = true;
					}
					return true;
					return;
					////-----
				}
			}
			mintReportTablesCount = 0;
			mintReportTextTableCount = -1;
			EV.HasMorePages = false;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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
	//If mintReportType = enumReportType.RepeatResults Then

	//end if
	private bool funcDrawRepeatDataText(ref PrintPageEventArgs EV, ref float sngYPositionIn, float sngLeftMarginIn)
	{
		RectangleF rectGridData;
		bool blnIsNextPage;
		float sngHeightPosition;
		float sngHeightOfTableData;
		float msngHeightOfHeader;

		try {
			rectGridData.X += sngLeftMarginIn;
			rectGridData.Y += sngYPositionIn;
			////----- Added & Modified by Sachin Dokhale on 28.09.05
			rectGridData.Height = EV.MarginBounds.Height - sngYPositionIn;
			//- mintPageFooterYPosotion

			rectGridData.Width = EV.MarginBounds.Width;

			if (IsNothing(this.mobjRptDataTblList) == true | (mintReportTextTableCount == -1)) {
				EV.HasMorePages = false;
				return;
			}
			////-----

			//Do While mintReportTextTableCount < Me.mobjRptDtTextList.Count

			//EV.Graphics.DrawString(CType(Me.mobjRptDtTextList.Item(mintReportTablesCount), DataTable).TableName, printFont, New Pen(Color.Black).Brush, rectGridData.X, rectGridData.Y)
			//rectGridData.Y += EV.Graphics.MeasureString(CType(Me.mobjRptDtTextList.Item(mintReportTablesCount), DataTable).TableName, printFont).Height
			////--- Print head only for 1 page for Repeat Result Ref. by CS on 29.05.08
			if (blnEscapeHeader == false) {
				subDatafileInitInfo(EV, rectGridData, (DataTable)RepeatDatafile.Item(2), enumReportType.RepeatResults, sngYPositionIn);
				blnEscapeHeader = true;
			}
			////---
			rectGridData.Y = sngYPositionIn;
			DataFileTextListPrintPage(EV, rectGridData, (DataTable)RepeatDatafile.Item(0), (DataTable)RepeatDatafile.Item(1), mintReportType, blnIsNextPage, sngHeightPosition);

			////----- Added & Modified by Sachin Dokhale on 28.09.05
			//---Increment GridRect Location 

			sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, (DataTable)this.RepeatDatafile.Item(mintReportTextTableCount), printFont, msngHeightOfHeader);

			//rectGridData.Y += sngHeightOfTableData + lineSpacing + printFont.GetHeight(EV.Graphics)
			rectGridData.Y += sngHeightPosition;
			//+ lineSpacing + printFont.GetHeight(EV.Graphics)
			sngYPositionIn = rectGridData.Y;

			//If EV.HasMorePages = False Then
			if (blnIsNextPage == false & NextFirstCol > 0) {
				if (!mintReportTextTableCount == this.RepeatDatafile.Count) {
					sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, (DataTable)this.RepeatDatafile.Item(mintReportTextTableCount), printFont, msngHeightOfHeader);
					rectGridData.Y += 1 * (lineSpacing + printFont.GetHeight(EV.Graphics));

					if ((mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics))) {
						//---Continue printing on same page
						EV.HasMorePages = false;
					} else {
						//---go to the new page

						EV.HasMorePages = true;
						return true;
					}
				}
			} else if (blnIsNextPage == false) {
				////-----
				mintReportTextTableCount += 1;
				NextFirstCol = 0;
				npp = 0;
				CurRow = 0;
				CurCol = 0;
				EV.HasMorePages = false;
				if (!mintReportTextTableCount == ((DataTable)this.RepeatDatafile.Item(1)).Rows.Count) {
					sngHeightOfTableData = funcGetDataTableHeight(EV.Graphics, (DataTable)this.RepeatDatafile.Item(mintReportTextTableCount), printFont, msngHeightOfHeader);
					rectGridData.Y += 1 * (lineSpacing + printFont.GetHeight(EV.Graphics));

					if ((mintPageFooterYPosotion - rectGridData.Y) > (msngHeightOfHeader + lineSpacing + printFont.GetHeight(EV.Graphics))) {
						//---Continue printing on same page
						EV.HasMorePages = false;
						if (blnPageSettingMessage == true) {
							EV.Cancel = true;
						}

					} else {
						//---go to the new page

						//EV.HasMorePages = True

						return true;
					}
				} else {
					if (blnPageSettingMessage == true) {
						EV.Cancel = true;
					}
				}

			} else {
				////----- Added & Modified by Sachin Dokhale on 28.09.05
				EV.HasMorePages = blnIsNextPage;
				if (blnPageSettingMessage == true) {
					EV.Cancel = true;
				}
				return true;
				////-----
			}
			//Loop
			mintReportTablesCount = 0;
			mintReportTextTableCount = -1;
			EV.HasMorePages = false;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawAllImages(ref PrintPageEventArgs EV, ref float sngYPositionIn, float sngLeftMarginIn)
	{
		Bitmap objBitmapImage;
		RectangleF rectImage;
		float sngHeightOfImage;
		float sngWidthOfImage;
		int intRectImageYPosition;

		try {
			//If mintReportType = enumReportType.Shade555SortResults Then
			//    sngLeftMarginIn = 400
			//    '//----- Commited by Sachin Dokhale on 8.1.06
			//    'sngYPositionIn = 220.5
			//    '//----- Added by Sachin Dokhale 
			//    sngYPositionIn = funcDrawPageHeader(EV.Graphics, EV.MarginBounds.Left, EV.MarginBounds.Top, mintReportLayoutType)
			//    '//-----
			//End If

			rectImage.X = sngLeftMarginIn;
			rectImage.Y = sngYPositionIn;
			rectImage.Y += 2 * (lineSpacing + printFont.GetHeight(EV.Graphics));
			rectImage.Height = (EV.MarginBounds.Height - sngYPositionIn);
			// + (lineSpacing + printFont.GetHeight(EV.Graphics))
			//rectImage.Height = 4 * (lineSpacing + printFont.GetHeight(EV.Graphics))



			////----- Added by Sachin Dokhale on 28.09.05
			if (rectImage.Height > 0) {
				intRectImageYPosition = (int)rectImage.Y + rectImage.Height;
			} else {
				intRectImageYPosition = (int)rectImage.Y + (int)Math.Abs(rectImage.Height);
				//(rectImage.Y)
			}
			////-----
			rectImage.Width = EV.MarginBounds.Width;
			//rectImage.Y -= lineSpacing + printFont.GetHeight(EV.Graphics)

			if (IsNothing(this.mobjDtImageList) == true) {
				return;
			}
			////----- Added by Sachin Dokhale on 28.09.05
			//If intrectImageYPosition >= mintPageFooterYPosotion Then
			//    EV.HasMorePages = True
			//    Exit Function
			//End If
			////-----

			switch (mintReportType) {
				//Case enumReportType.EditShade
				//    If funcDrawShadeCardImages(EV, rectImage, 4) = False Then
				//        Return False
				//    End If

				//Case enumReportType.QCStrengthVisual
				//    If funcDrawShadeCardImages(EV, rectImage, 3) = False Then
				//        Return False
				//    End If

				//Case enumReportType.QCColorOnObject
				//    If funcDrawShadeCardImages(EV, rectImage, 1) = False Then
				//        Return False
				//    End If

				//Case enumReportType.QCMetamerism
				//    If funcDrawShadeCardImages(EV, rectImage, 3) = False Then
				//        Return False
				//    End If

				//Case enumReportType.EditColorants, enumReportType.EditPigment, enumReportType.EditSubstrate
				//    If funcDrawShadeCardImages(EV, rectImage, mobjDtImageList.Rows.Count) = False Then
				//        Return False
				//    End If

				//Case enumReportType.BatchCorrection
				//    If funcDrawShadeCardImages(EV, rectImage, 3) = False Then
				//        Return False
				//    End If

				default:
					if (funcDrawShadeCardImages(EV, rectImage, 2) == false) {
						return false;

					}
			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawShadeCardImages(ref PrintPageEventArgs EV, RectangleF rectAllImagesGrid, int intNoOfColumnsPerPage)
	{
		//=====================================================================
		// Procedure Name        : funcDrawShadeCardImages
		// Parameters Passed     : PrintPageEventArgs, rectangleF
		// Returns               : True or False
		// Purpose               : To draw the images on report in rows and columns
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul 
		// Created               : Friday 01 April 2005 10:45 am
		// Revisions             : 2
		//=====================================================================
		Bitmap objBitmapImage;
		RectangleF rectImage;
		float sngHeightOfImage;
		float sngWidthOfImage;
		float sngLeftMargin;
		float sngYPosition;
		int intRowCounter;
		int nrperpage;
		float sngEachImageHeight;
		string strImageCaption;
		float sngEachImageCaptionHeight;
		DataTable objDtImagesPerPage;
		DataRow objDrNewRow;
		int intTotalFreeSpaceHeightForAllImagesGrid;
		static bool intIsPageReapate;
		try {
			if (IsNothing(this.mobjDtImageList) == true) {
				return true;
				return;
			}
			////----- Add By Sachin Dokhale 
			////----- Exit when Current Count and total ImageList Count is Save
			////----- means all Image is Printed 
			if ((mintCurrentImageRow >= mobjDtImageList.Rows.Count)) {
				return true;
				return;
			}
			////-----
			//intNoOfColumnsPerPage = 3

			sngLeftMargin = rectAllImagesGrid.X;
			sngYPosition = rectAllImagesGrid.Y;
			//'rectAllImagesGrid.Height -= 14

			//---Work out the number of pages
			sngEachImageHeight = ((Bitmap)mobjDtImageList.Rows(0).Item("Image")).Height;
			strImageCaption = (string)mobjDtImageList.Rows(0).Item("ImageCaption");
			sngEachImageCaptionHeight = (float)1.2 * (EV.Graphics.MeasureString(strImageCaption, printFont).Height);

			//nrperpage = CInt((rectAllImagesGrid.Height)) \ CInt((sngEachImageHeight + sngEachImageCaptionHeight))
			////----- Added by Sachin Dokhale on 11.04.06
			////----- Adjestate to the TextHeight

			intTotalFreeSpaceHeightForAllImagesGrid = (int)rectAllImagesGrid.Height - mintTotalHeightOfPageText;
			nrperpage = intTotalFreeSpaceHeightForAllImagesGrid / (int)sngEachImageHeight + sngEachImageCaptionHeight;
			mintTotalHeightOfPageText = 0;
			////-----

			if (nrperpage > 1) {
				nrperpage -= 1;
			} else if (nrperpage == 2) {
				nrperpage = 2;
			} else if (nrperpage == 1) {
				nrperpage = 1;
			} else if (nrperpage == 0) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//Application.DoEvents()
						//cWait = New CWaitCursor
						blnPageSettingMessage = true;
					}
					EV.HasMorePages = false;
					EV.Cancel = true;
					return true;
					return;
				}
				nrperpage = 0;
				intIsPageReapate = true;
				EV.HasMorePages = true;
				return true;
			}
			if (nrperpage > 14) {
				nrperpage = 14;
			}
			////----- Commented by Sachin Dokhale on 12.04.06
			//If nrperpage > 13 Then
			//    nrperpage = 13
			//End If
			////-----

			//---Work out no. of pages considering no. of columns in each page
			nrperpage = nrperpage * intNoOfColumnsPerPage;

			objDtImagesPerPage = new DataTable();
			objDtImagesPerPage = mobjDtImageList.Clone;

			for (intRowCounter = mintCurrentImageRow; intRowCounter <= nrperpage + mintCurrentImageRow - 1; intRowCounter++) {
				if (intRowCounter >= mobjDtImageList.Rows.Count) {
					break; // TODO: might not be correct. Was : Exit For
				}
				objDrNewRow = mobjDtImageList.DefaultView.Item(intRowCounter).Row;
				objDtImagesPerPage.ImportRow(objDrNewRow);
			}

			mintCurrentImageRow = intRowCounter;

			if (this.ArrangeImagesInGrid(objDtImagesPerPage, EV.Graphics, intNoOfColumnsPerPage, sngLeftMargin, sngYPosition) == true) {
				//If we have more Images then print another page
				if ((mintCurrentImageRow < mobjDtImageList.Rows.Count)) {
					EV.HasMorePages = true;
					intIsPageReapate = true;
				} else {
					////----- Commented by Sachin Dikhale on 7.1.06
					////----- Not required to ev.HasMorePages = False
					//If mintReportType = enumReportType.Shade555SortResults Then
					//    'EV.HasMorePages = False
					//    'mintCurrentImageRow = 0
					//    intIsPageReapate = False
					//Else
					//    'EV.HasMorePages = False
					//    'mintCurrentImageRow = 0
					//    intIsPageReapate = False
					//End If

				}
			} else {
				intIsPageReapate = false;
			}
			// intIsPageReapate = False
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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


	private void DataGridPrintPage(ref System.Drawing.Printing.PrintPageEventArgs ev, Drawing.RectangleF rectGrid, DataTable objDtReportDataTableIn, enumReportType intReportTypeIn, ref bool IsNextPage, ref float YPosition)
	{
		NextFirstCol = 0;
		npp += 1;

		mobjDvReportDataView = objDtReportDataTableIn.DefaultView;

		float lpp = 0;
		float yPos = 0;
		int count = 0;
		float leftMargin = rectGrid.Left;
		float topMargin = rectGrid.Top;
		string line;
		int rowHeight;
		int headerHeight;
		int i;
		int j;
		int w;
		int l;
		Pen divPen = new Pen(Color.Black);
		//mobjReportDataGrid.GridLineColor)
		Pen hfpen = new Pen(Color.Black);
		//mobjReportDataGrid.HeaderForeColor)
		SolidBrush hbBrush = new SolidBrush(Color.White);
		//mobjReportDataGrid.HeaderBackColor)
		SolidBrush hfBrush = new SolidBrush(Color.Black);
		//mobjReportDataGrid.HeaderForeColor)
		SizeF CellSize;
		static int PrevRowCount;
		static bool blnPrevRow;
		static bool intIsPageReapate;


		try {
			////----- Added & Modified by Sachin Dokhale on 28.09.05
			lpp = rectGrid.Height / printFont.GetHeight(ev.Graphics);
			//rowHeight = 14 'PreferredRowHeight
			rowHeight = (int)printFont.GetHeight(ev.Graphics) + 1;
			headerHeight = 18;
			if (rectGrid.Y >= mintPageFooterYPosotion) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//Application.DoEvents()
						//cWait = New CWaitCursor
						blnPageSettingMessage = true;
					}

					IsNextPage = false;
					break; // TODO: might not be correct. Was : Exit Try
				}
				IsNextPage = true;
				intIsPageReapate = true;
				break; // TODO: might not be correct. Was : Exit Try
			}
			rectGrid.Height = (mintPageFooterYPosotion - 15) - rectGrid.Y;
			if (rectGrid.Height <= rowHeight) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//cWait = New CWaitCursor
						blnPageSettingMessage = true;
					}
					IsNextPage = false;
					break; // TODO: might not be correct. Was : Exit Try
				}
				IsNextPage = true;
				intIsPageReapate = true;
				break; // TODO: might not be correct. Was : Exit Try
			}
			NoOfRowsPerPage = (((int)rectGrid.Height / rowHeight) - (headerHeight / rowHeight) - 1);
			//(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount
			////-----

			l = (int)topMargin;
			w = (int)leftMargin;
			float sngCellHeight = 0.0;
			float MaxCellHeight = 0.0;



			for (j = CurCol; j <= objDtReportDataTableIn.Columns.Count - 1; j++) {
				CellSize = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j);
				CellSize.Height += 10;
				float sngColumnWidth = CellSize.Width;

				if (w + sngColumnWidth >= rectGrid.Right & j != CurCol) {
					NextFirstCol = j;
					break; // TODO: might not be correct. Was : Exit For
				}
				if (sngColumnWidth == 0)
					goto continuefor;

				//Dim r As New Rectangle(w, l, CInt(sngColumnWidth + 1), headerHeight)
				Rectangle r = new Rectangle(new Point(w, l), CellSize.ToSize);

				Drawing.RectangleF rf = new Drawing.RectangleF(w, l, r.Width, r.Height);

				//headerFont = CType(mobjARPortrateReport.Sections("GrpHdrStadGraph").Controls("Txt1"), DataDynamics.ActiveReports.Label).Font
				headerFont = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt1")).Font;
				if (objDtReportDataTableIn.Columns(j).Caption == "") {
					ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, headerFont, hfBrush, rf);
				} else {
					PaintHeaderCell(ev.Graphics, objDtReportDataTableIn.Columns(j).Caption, headerFont, hfBrush, r, 1, 1);
				}


				ev.Graphics.DrawLine(divPen, r.X, r.Y, r.Right, r.Y);


				//'ev.Graphics.DrawLine(divPen, r.X, r.Bottom + 5, r.Right, r.Y + r.Height + 5) 'commented on 27.3.2009
				ev.Graphics.DrawLine(divPen, r.X, r.Bottom + 20, r.Right, r.Y + r.Height + 20);
				// code added on : 27.3.2009

				w += (int)sngColumnWidth;

				//'headerHeight = r.Height + 5 'commented on 27.3.2009
				headerHeight = r.Height + 20;
				continuefor:
				// code added on 27.3.2009

			}
			//l += r.Height 'CellSize.ToSize.Height   'headerHeight
			l += headerHeight;
			NoOfRowsPerPage = (((int)rectGrid.Height / rowHeight) - (headerHeight / rowHeight) - 1);
			//(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount
			//aa = CurRow
			printFont = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable1")).Font;
			for (i = CurRow; i <= NoOfRowsPerPage + CurRow - 1; i++) {
				if (i >= mobjDvReportDataView.Count)
					break; // TODO: might not be correct. Was : Exit For
				w = (int)leftMargin;

				for (j = CurCol; j <= objDtReportDataTableIn.Columns.Count - 1; j++) {
					if (IsNothing(ColoumnFormat)) {
						ColoumnFormat = new StringFormat();
					}
					float sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width;

					if (w + sngColumnWidth >= rectGrid.Right & j != CurCol)
						break; // TODO: might not be correct. Was : Exit For
					if (sngColumnWidth == 0)
						goto continuefor2;

					//Dim r As New Rectangle(w, l, CInt(sngColumnWidth + 0.75), rowHeight)


					if (IsNumeric(mobjDvReportDataView.Item(i).Item(j).ToString())) {
						Rectangle r = new Rectangle(w, l, (int)sngColumnWidth - 10, rowHeight);
						Drawing.RectangleF rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);

						if (SetTableColoumnFormat == true) {
							if (j == 0) {
								//ColoumnFormat.Alignment = StringAlignment.Near
								ColoumnFormat.Alignment = StringAlignment.Center;
							} else {
								//ColoumnFormat.Alignment = StringAlignment.Far
								ColoumnFormat.Alignment = StringAlignment.Center;
							}
						}
						ev.Graphics.DrawString(mobjDvReportDataView.Item(i).Item(j).ToString(), printFont, Drawing.Brushes.Black, rf, ColoumnFormat);

					} else {
						Rectangle r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
						Drawing.RectangleF rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);
						if (SetTableColoumnFormat == true) {
							if (j == 0) {
								//ColoumnFormat.Alignment = StringAlignment.Near
								ColoumnFormat.Alignment = StringAlignment.Center;
							} else {
								//ColoumnFormat.Alignment = StringAlignment.Near
								ColoumnFormat.Alignment = StringAlignment.Center;
							}
						}
						ev.Graphics.DrawString(mobjDvReportDataView.Item(i).Item(j).ToString(), printFont, Drawing.Brushes.Black, rf, ColoumnFormat);
					}
					//ev.Graphics.DrawString(mobjDvReportDataView.Item(i).Item(j).ToString(), printFont, Drawing.Brushes.Black, rf)

					w += (int)sngColumnWidth;
					continuefor2:
				}

				l += rowHeight;
			}
			CurRow = i;
			PrevRowCount = i;

			float sngXPos = leftMargin;
			int intTotalGridHeight;
			intTotalGridHeight = l - (int)topMargin + 10;

			ev.Graphics.DrawLine(new Pen(Color.Black), leftMargin, topMargin, sngXPos, topMargin + intTotalGridHeight);
			for (j = CurCol; j <= objDtReportDataTableIn.Columns.Count - 1; j++) {
				float sngColumnWidth;

				if (NextFirstCol > 0 & j >= NextFirstCol) {
					break; // TODO: might not be correct. Was : Exit For
				}
				sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width;
				sngXPos += sngColumnWidth;
				ev.Graphics.DrawLine(new Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight);
			}
			ev.Graphics.DrawLine(new Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight);
			ev.Graphics.DrawLine(new Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight);
			ev.Graphics.DrawLine(new Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight);

			////----- Added & Modified by Sachin Dokhale on 28.09.05
			YPosition = (float)intTotalGridHeight;
			////-----
			if (npp >= NoOfPagesPreviewed) {
				//ev.HasMorePages = True
				//IsNextPage = True
				npp -= NoOfPagesPreviewed;
			}
			//If we have more lines then print another page
			if ((CurRow < mobjDvReportDataView.Count)) {
				//ev.HasMorePages = True
				IsNextPage = true;

			} else {
				if (NextFirstCol == 0) {
					//ev.HasMorePages = False
					IsNextPage = false;
				} else {
					CurRow = 0;
					CurCol = NextFirstCol;
					//ev.HasMorePages = True
					//IsNextPage = True
				}
			}
			intIsPageReapate = false;
			divPen.Dispose();
			hfpen.Dispose();
			hbBrush.Dispose();
			hfBrush.Dispose();

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


	private void TextListPrintPage(ref System.Drawing.Printing.PrintPageEventArgs ev, Drawing.RectangleF rectGrid, DataTable objDtReportDataTableIn, enumReportType intReportTypeIn, ref bool IsNextPage, ref float YPosition)
	{
		NextFirstCol = 0;
		npp += 1;

		mobjDvReportDataView = objDtReportDataTableIn.DefaultView;

		float lpp = 0;
		float yPos = 0;
		int count = 0;
		float leftMargin = rectGrid.Left;
		float topMargin = rectGrid.Top;
		string line;
		int rowHeight;
		int headerHeight;
		int i;
		int j;
		int w;
		int l;
		Pen divPen = new Pen(Color.Black);
		//mobjReportDataGrid.GridLineColor)
		Pen hfpen = new Pen(Color.Black);
		//mobjReportDataGrid.HeaderForeColor)
		SolidBrush hbBrush = new SolidBrush(Color.White);
		//mobjReportDataGrid.HeaderBackColor)
		SolidBrush hfBrush = new SolidBrush(Color.Black);
		//mobjReportDataGrid.HeaderForeColor)
		SizeF CellSize;
		float sngColumnWidth;

		static int PrevRowCount;
		static bool blnPrevRow;
		static bool intIsPageReapate;


		try {
			////----- Added & Modified by Sachin Dokhale on 28.09.05
			lpp = rectGrid.Height / printFont.GetHeight(ev.Graphics);
			//rowHeight = 14 'PreferredRowHeight
			rowHeight = (int)printFont.GetHeight(ev.Graphics) + 1;
			headerHeight = 18;
			if (rectGrid.Y >= mintPageFooterYPosotion) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//Application.DoEvents()
						//cWait = New CWaitCursor
						blnPageSettingMessage = true;
					}

					IsNextPage = false;
					break; // TODO: might not be correct. Was : Exit Try
				}
				IsNextPage = true;
				intIsPageReapate = true;
				break; // TODO: might not be correct. Was : Exit Try
			}
			rectGrid.Height = (mintPageFooterYPosotion - 15) - rectGrid.Y;
			if (rectGrid.Height <= rowHeight) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//cWait = New CWaitCursor
						blnPageSettingMessage = true;
					}
					IsNextPage = false;
					break; // TODO: might not be correct. Was : Exit Try
				}
				IsNextPage = true;
				intIsPageReapate = true;
				break; // TODO: might not be correct. Was : Exit Try
			}
			NoOfRowsPerPage = (((int)rectGrid.Height / rowHeight) - (headerHeight / rowHeight) - 1);
			//(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount
			////-----

			l = (int)topMargin;
			w = (int)leftMargin;
			float sngCellHeight = 0.0;
			float MaxCellHeight = 0.0;


			//            For j = CurCol To objDtReportDataTableIn.Columns.Count - 1
			//                CellSize = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j)

			//                sngColumnWidth = CellSize.Width

			//                If w + sngColumnWidth >= rectGrid.Right And j <> CurCol Then
			//                    NextFirstCol = j
			//                    Exit For
			//                End If
			//                If sngColumnWidth = 0 Then GoTo continuefor

			//                'Dim r As New Rectangle(w, l, CInt(sngColumnWidth + 1), headerHeight)
			//                Dim r As New Rectangle(New Point(w, l), CellSize.ToSize)

			//                Dim rf As New Drawing.RectangleF(w, l, r.Width, r.Height)

			//                If objDtReportDataTableIn.Columns(j).Caption = "" Then
			//                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, headerFont, hfBrush, rf)
			//                Else
			//                    Call PaintHeaderCell(ev.Graphics, objDtReportDataTableIn.Columns(j).Caption, _
			//                                                    headerFont, hfBrush, r, 1, 1)
			//                End If


			//                ev.Graphics.DrawLine(divPen, r.X, r.Y, r.Right, r.Y)
			//                ev.Graphics.DrawLine(divPen, r.X, r.Bottom, r.Right, r.Y + r.Height)

			//                w += CInt(sngColumnWidth)

			//                headerHeight = r.Height

			//continuefor:
			//            Next j


			//l += r.Height 'CellSize.ToSize.Height   'headerHeight
			l += headerHeight;
			bool blnIsLeft = false;
			Font ReportHeader1Font;
			Font ReportHeaderFont;
			Font ReportText1Font;
			Font ReportHeader2Font;
			Font ReportText2Font;
			Drawing.RectangleF rectReportHeader;
			Rectangle r;
			Drawing.RectangleF rf;
			SizeF sizStringSize;
			StringFormat newStringFormat = new StringFormat();
			int intLineHeigt;
			Drawing.Color clrMangeta;
			Drawing.Color FontColor;
			NoOfRowsPerPage = (((int)rectGrid.Height / rowHeight) - (headerHeight / rowHeight) - 1);
			//(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount


			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("lblHeader")).Font;
			ReportHeader1Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable1")).Font;
			ReportText1Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt1")).Font;
			ReportHeader2Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable2")).Font;
			ReportText2Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt2")).Font;
			rectReportHeader = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt2")).GetBounds;

			if (PrinterType == false) {
				FontColor = clrMangeta.Black;
			} else {
				FontColor = clrMangeta.Magenta;
			}

			w = (int)leftMargin;

			rowHeight = (int)ReportText1Font.GetHeight(ev.Graphics) + 1;
			//If Not objDtReportDataTableIn.Rows.Item(0).Item(0).ToString = "" Then
			if (!objDtReportDataTableIn.Columns(j).Caption == "") {
				//sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width
				sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width;

				r = new Rectangle(w, l, (int)sngColumnWidth + 50, rowHeight);
				rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);

				hfBrush.Color = FontColor;
				ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeaderFont, hfBrush, rf);
				hfBrush.Color = clrMangeta.Black;

				if (!objDtReportDataTableIn.Rows.Item(0).Item(0).ToString == "") {
					r = new Rectangle(w + 200, l, (int)sngColumnWidth - 3, rowHeight);
					rf = new Drawing.RectangleF(w + 205, l + 2, r.Width, r.Height);

					hfBrush.Color = FontColor;
					ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(0).Item(0).ToString, ReportHeaderFont, hfBrush, rf);
					hfBrush.Color = clrMangeta.Black;
				}
				l += r.Height + 10;
			}
			//rowHeight = CInt(rectReportHeader.Height)

			//aa = CurRow
			//= funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width
			//For i = CurLine To NoOfRowsPerPage + CurLine - 1

			//If i >= mobjDvReportDataView.Count Then Exit For

			j = 1;


			//For j = CurRow To objDtReportDataTableIn.Rows.Count - 1
			//hfBrush.Color = clrMangeta.Magenta
			while (j <= objDtReportDataTableIn.Columns.Count - 1) {
				//    Dim sngColumnWidth As Single = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width

				//   If w + sngColumnWidth >= rectGrid.Right And j <> CurCol Then Exit For
				//  If sngColumnWidth = 0 Then GoTo continuefor2

				//Dim r As New Rectangle(w, l, CInt(sngColumnWidth + 0.75), rowHeight)


				//If IsNumeric(mobjDvReportDataView.Item(i).Item(j).ToString()) Then
				//    Dim r As New Rectangle(w, l, CInt(sngColumnWidth - 10), rowHeight)
				//    Dim rf As New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)


				//    If IsNothing(ColoumnFormat) Then
				//        ColoumnFormat = New StringFormat
				//    End If
				//    If SetTableColoumnFormat = True Then
				//        ColoumnFormat.Alignment = StringAlignment.Far
				//    End If
				//    ev.Graphics.DrawString(mobjDvReportDataView.Item(i).Item(j).ToString(), printFont, Drawing.Brushes.Black, rf, ColoumnFormat)

				//Else
				//    Dim r As New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
				//    Dim rf As New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
				//    If IsNothing(ColoumnFormat) Then
				//        ColoumnFormat = New StringFormat
				//    End If
				//    If SetTableColoumnFormat = True Then
				//        ColoumnFormat.Alignment = StringAlignment.Near
				//    End If
				//    ev.Graphics.DrawString(mobjDvReportDataView.Item(i).Item(j).ToString(), printFont, Drawing.Brushes.Black, rf, ColoumnFormat)
				//End If

				//Dim sngColumnWidth As Single = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width


				if (IsNumeric(mobjDvReportDataView.Item(i).Item(j).ToString())) {
					if (IsNothing(ColoumnFormat)) {
						ColoumnFormat = new StringFormat();
					}
					if (SetTableColoumnFormat == true) {
						ColoumnFormat.Alignment = StringAlignment.Near;
					}
				} else {
					if (IsNothing(ColoumnFormat)) {
						ColoumnFormat = new StringFormat();
					}
					if (SetTableColoumnFormat == true) {
						ColoumnFormat.Alignment = StringAlignment.Near;
					}
				}

				CurRow = 1;
				newStringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
				newStringFormat.Alignment = StringAlignment.Near;


				if (blnIsLeft == false) {

					sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 0).Width;
					sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, (int)sngColumnWidth, newStringFormat);
					rowHeight = (int)sizStringSize.Height;

					r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
					rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);

					ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, hfBrush, rf);
					intLineHeigt = l + r.Height;

					sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 1).Width;
					if (!(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString == "")) {
						sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, (int)sngColumnWidth, newStringFormat);
						rowHeight = (int)sizStringSize.Height;

						r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
						w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt1")).Left * 72;

						rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);

						ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat);
					}
					blnIsLeft = true;
				} else {
					sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 2).Width;
					sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, (int)sngColumnWidth, newStringFormat);
					rowHeight = (int)sizStringSize.Height;

					w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable2")).Left * 72 - 100;
					r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);

					rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);
					blnIsLeft = false;
					ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, hfBrush, rf);
					if (!(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString == "")) {
						sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 3).Width;
						sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, (int)sngColumnWidth, newStringFormat);
						rowHeight = (int)sizStringSize.Height;
						r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
						rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);

						w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt2")).Left * 72 - 300;
						rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);

						ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, Drawing.Brushes.Black, rf, ColoumnFormat);
					}
					//
					w = (int)leftMargin;
					l += r.Height;
				}
				continuefor2:
				j += 1;
			}
			//hfBrush.Color = clrMangeta.Black
			if (intLineHeigt > l) {
				l = intLineHeigt;
			}
			if (blnIsLeft == true) {
				l += r.Height;
			}
			//   l += rowHeight
			//Next

			//CurRow = i
			PrevRowCount = i;

			float sngXPos = leftMargin;
			int intTotalGridHeight;

			//intTotalGridHeight = CInt(rectGrid.Width)
			intTotalGridHeight = l - (int)topMargin + 10;

			ev.Graphics.DrawLine(new Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight);

			for (j = CurCol; j <= objDtReportDataTableIn.Columns.Count - 1; j++) {
				// Dim sngColumnWidth As Single

				if (NextFirstCol > 0 & j >= NextFirstCol) {
					break; // TODO: might not be correct. Was : Exit For
				}
				sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width;
				sngXPos += sngColumnWidth;
				//ev.Graphics.DrawLine(New Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight)
			}

			//ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)
			//ev.Graphics.DrawLine(New Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight)

			sngXPos = (int)rectGrid.Right;
			ev.Graphics.DrawLine(new Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight);

			////----- Added & Modified by Sachin Dokhale on 28.09.05
			YPosition = (float)intTotalGridHeight;
			////-----
			if (npp >= NoOfPagesPreviewed) {
				//ev.HasMorePages = True
				//IsNextPage = True
				npp -= NoOfPagesPreviewed;
			}
			//If we have more lines then print another page
			if ((CurRow < mobjDvReportDataView.Count)) {
				//ev.HasMorePages = True
				IsNextPage = true;

			} else {
				if (NextFirstCol == 0) {
					//ev.HasMorePages = False
					IsNextPage = false;
				} else {
					CurRow = 0;
					CurCol = NextFirstCol;
					//ev.HasMorePages = True
					//IsNextPage = True
				}
			}
			intIsPageReapate = false;
			divPen.Dispose();
			hfpen.Dispose();
			hbBrush.Dispose();
			hfBrush.Dispose();

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


	private void DataFileTextListPrintPage(ref System.Drawing.Printing.PrintPageEventArgs ev, Drawing.RectangleF rectGrid, DataTable objDtReportDataTableIn, DataTable objDtReportDetailsDataTableIn, enumReportType intReportTypeIn, ref bool IsNextPage, ref float YPosition)
	{
		NextFirstCol = 0;
		npp += 1;

		mobjDvReportDataView = objDtReportDataTableIn.DefaultView;

		float lpp = 0;
		float yPos = 0;
		int count = 0;
		float leftMargin = rectGrid.Left;
		float topMargin = rectGrid.Top;
		string line;
		int rowHeight;
		int headerHeight;
		int i;
		int j;
		int w;
		int l;
		Pen divPen = new Pen(Color.Black);
		//mobjReportDataGrid.GridLineColor)
		Pen hfpen = new Pen(Color.Black);
		//mobjReportDataGrid.HeaderForeColor)
		SolidBrush hbBrush = new SolidBrush(Color.White);
		//mobjReportDataGrid.HeaderBackColor)
		SolidBrush hfBrush = new SolidBrush(Color.Black);
		//mobjReportDataGrid.HeaderForeColor)
		SizeF CellSize;
		float sngColumnWidth;

		static int PrevRowCount;
		static bool blnPrevRow;
		static bool intIsPageReapate;


		try {
			////----- Added & Modified by Sachin Dokhale on 28.09.05
			lpp = rectGrid.Height / printFont.GetHeight(ev.Graphics);
			//rowHeight = 14 'PreferredRowHeight
			rowHeight = (int)printFont.GetHeight(ev.Graphics) + 1;
			headerHeight = 18;
			if (rectGrid.Y >= mintPageFooterYPosotion) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//Application.DoEvents()
						//cWait = New CWaitCursor
						blnPageSettingMessage = true;
					}

					IsNextPage = false;
					break; // TODO: might not be correct. Was : Exit Try
				}
				IsNextPage = true;
				intIsPageReapate = true;
				break; // TODO: might not be correct. Was : Exit Try
			}
			rectGrid.Height = (mintPageFooterYPosotion - 15) - rectGrid.Y;
			if (rectGrid.Height <= rowHeight) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//cWait = New CWaitCursor
						blnPageSettingMessage = true;
					}
					IsNextPage = false;
					break; // TODO: might not be correct. Was : Exit Try
				}
				IsNextPage = true;
				intIsPageReapate = true;
				break; // TODO: might not be correct. Was : Exit Try
			}
			//NoOfRowsPerPage = ((CInt(rectGrid.Height) \ rowHeight) - (headerHeight \ rowHeight) - 1)   '(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount
			////-----

			l = (int)topMargin;
			w = (int)leftMargin;
			float sngCellHeight = 0.0;
			float MaxCellHeight = 0.0;

			//l += r.Height 'CellSize.ToSize.Height   'headerHeight

			l += headerHeight;
			bool blnIsLeft = false;
			Font ReportHeader1Font;
			Font ReportHeaderFont;
			Font ReportText1Font;
			Font ReportHeader2Font;
			Font ReportText2Font;
			Drawing.RectangleF rectReportHeader;
			Rectangle r;
			Drawing.RectangleF rf;
			SizeF sizStringSize;
			StringFormat newStringFormat = new StringFormat();
			int intLineHeigt;
			intIsPageReapate = false;
			//NoOfRowsPerPage = ((CInt(rectGrid.Height) \ rowHeight) - (headerHeight \ rowHeight) - 1)   '(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount
			NoOfRowsPerPage = (((int)rectGrid.Height / rowHeight) - (headerHeight / rowHeight) - 1);
			//(CInt(rectGrid.Y) \ rowHeight) '- (headerHeight \ rowHeight) '- PrevRowCount

			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSamp")).Font;
			ReportHeader1Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("StdSampName")).Font;
			ReportText1Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSampName")).Font;
			ReportHeader2Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("Abso")).Font;
			ReportText2Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtAbso")).Font;
			rectReportHeader = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("lblDtlInfo")).GetBounds;

			w = (int)leftMargin;



			rowHeight = (int)ReportText1Font.GetHeight(ev.Graphics) + 1;
			//If Not objDtReportDataTableIn.Columns(j).Caption = "" Then
			//    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width
			//    r = New Rectangle(w, l, CInt(sngColumnWidth + 50), rowHeight)
			//    rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
			//    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeaderFont, hfBrush, rf)
			//    If Not objDtReportDataTableIn.Rows.Item(0).Item(0).ToString = "" Then
			//        r = New Rectangle(w + 200, l, CInt(sngColumnWidth - 3), rowHeight)
			//        rf = New Drawing.RectangleF(w + 205, l + 2, r.Width, r.Height)
			//        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(0).Item(0).ToString, ReportHeaderFont, hfBrush, rf)
			//    End If
			//    l += r.Height + 10
			//End If
			j = 0;
			int MasterIdx = 0;
			int lLimit;
			static int intAddConcLimit = 0;
			//MasterIdx = mMasterIdx
			//objDtReportDataTableIn As DataTable, _
			//objDtReportDetailsDataTableIn As DataTable, _

			lLimit = l;
			for (MasterIdx = mMasterIdx; MasterIdx <= objDtReportDataTableIn.Rows.Count - 1; MasterIdx++) {
				//--- If any probelm in printng during lines of printting change follow eq. in if conditions 
				//If (rectGrid.Height <= (l + ((rowHeight - 5) * 12))) Then

				if ((rectGrid.Height <= ((l - lLimit) + ((rowHeight) * 14) + intAddConcLimit))) {
					if (intIsPageReapate == true) {
						if (blnPageSettingMessage == false) {
							//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
							//cWait = New CWaitCursor
							blnPageSettingMessage = true;
						}
						IsNextPage = false;
						break; // TODO: might not be correct. Was : Exit Try
					}
					mMasterIdx = MasterIdx;
					IsNextPage = true;
					intIsPageReapate = true;
					break; // TODO: might not be correct. Was : Exit Try
				}
				if (IsNothing(ColoumnFormat)) {
					ColoumnFormat = new StringFormat();
				}
				if (SetTableColoumnFormat == true) {
					ColoumnFormat.Alignment = StringAlignment.Near;
				}

				newStringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
				newStringFormat.Alignment = StringAlignment.Near;
				////----- Std Samp #No
				//sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 0).Width
				//sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
				//rowHeight = CInt(sizStringSize.Height)

				//r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
				//rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
				//ev.Graphics.DrawString(objDtReportDataTableIn.Columns(MasterIdx).Caption, ReportHeader1Font, hfBrush, rf)
				//intLineHeigt = l + r.Height
				//l += r.Height
				////----- Std Name
				sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 1).Width;
				if (!(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(2).ToString == "")) {
					sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(2).ToString, ReportText1Font, (int)sngColumnWidth, newStringFormat);
					rowHeight = (int)sizStringSize.Height;
					w = (int)leftMargin;
					r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
					w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSamp")).Left * 72;

					rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);
					ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(2).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat);
				}
				l += r.Height;
				////----- Name
				sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 2).Width;


				bool blnIsStd;
				blnIsStd = objDtReportDataTableIn.Rows.Item(MasterIdx).Item(6);

				// code added by :dinesh wagh on 27.3.2009
				// code start
				if (blnIsStd == true) {
					sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(3).Caption, ReportHeader1Font, (int)sngColumnWidth, newStringFormat);
				} else {
					sizStringSize = ev.Graphics.MeasureString("Name :", ReportHeader1Font, (int)sngColumnWidth, newStringFormat);
				}
				// code ends

				//sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(3).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat) ' code commented by : dinesh wagh on 27.3.2009


				rowHeight = (int)sizStringSize.Height;
				w = (int)leftMargin;
				w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("StdSampName")).Left * 72;
				r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);

				rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);
				// code added by: dinesh wagh on 27.3.2009
				//rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height) ' code commented by : dinesh wagh on 27.3.2009


				//ev.Graphics.DrawString(objDtReportDataTableIn.Columns(3).Caption, ReportHeader1Font, hfBrush, rf) ' code commented by : dinesh wagh on 27.3.2009

				// code added by : dinesh wagh on 27.3.2009
				// code start
				if (blnIsStd == true) {
					ev.Graphics.DrawString(objDtReportDataTableIn.Columns(3).Caption, ReportHeader1Font, hfBrush, rf);
				} else {
					ev.Graphics.DrawString("Name :", ReportHeader1Font, hfBrush, rf);
				}
				//code ends

				intLineHeigt = l + r.Height;

				if (!(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(3).ToString == "")) {
					sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(3).ToString, ReportText1Font, (int)sngColumnWidth, newStringFormat);
					rowHeight = (int)sizStringSize.Height;

					r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
					w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSampName")).Left * 72;

					rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);
					ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(3).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat);
				}
				l += r.Height;
				////----- Abs
				w = (int)leftMargin;
				sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width;
				sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(4).Caption, ReportHeader1Font, (int)sngColumnWidth, newStringFormat);
				rowHeight = (int)sizStringSize.Height;

				r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);

				rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);
				// code added by : dinesh wagh on 27.3.2009
				//rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height) ' code commented by : dinesh wagh on 27.3.2009

				ev.Graphics.DrawString(objDtReportDataTableIn.Columns(4).Caption, ReportHeader1Font, hfBrush, rf);
				intLineHeigt = l + r.Height;

				if (!(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(4).ToString == "")) {
					sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(4).ToString, ReportText1Font, (int)sngColumnWidth, newStringFormat);
					rowHeight = (int)sizStringSize.Height;
					w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtAbso")).Left * 72;
					r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
					rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);
					ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(4).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat);
				}
				l += r.Height;
				////----- Conc
				if ((bool)objDtReportDataTableIn.Rows.Item(MasterIdx).Item(6) == false) {
					w = (int)leftMargin;
					sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width;
					sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(5).Caption, ReportHeader1Font, (int)sngColumnWidth, newStringFormat);
					rowHeight = (int)sizStringSize.Height;

					r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
					rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);
					ev.Graphics.DrawString(objDtReportDataTableIn.Columns(5).Caption, ReportHeader1Font, hfBrush, rf);
					intLineHeigt = l + r.Height;

					if (!(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(5).ToString == "")) {
						sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(4).ToString, ReportText1Font, (int)sngColumnWidth, newStringFormat);
						rowHeight = (int)sizStringSize.Height;
						r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
						w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtConc")).Left * 72;

						rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);
						ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(MasterIdx).Item(5).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat);
					}
					l += r.Height;
				}
				////------ Details
				bool IsLeftMargin;
				int intDtlIdx;
				int intRowStart;
				for (intDtlIdx = 0; intDtlIdx <= objDtReportDetailsDataTableIn.Rows.Count - 1; intDtlIdx++) {
					if ((int)objDtReportDataTableIn.Rows.Item(MasterIdx).Item(1) == (int)objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(1)) {
						if ((bool)objDtReportDataTableIn.Rows.Item(MasterIdx).Item(6) == false) {
							IsLeftMargin = true;

						}
						if ((string)objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(0) == "Statistics on Conc") {
							IsLeftMargin = true;
							l = intRowStart;
							w = (int)leftMargin + 400;
						} else {
							IsLeftMargin = false;
							w = (int)leftMargin + 100;
							l += r.Height;
							intRowStart = l;
						}
						sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width;
						//r = New Rectangle(w, l, CInt(sngColumnWidth + 50), rowHeight)
						//rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
						//ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeaderFont, hfBrush, rf)
						sizStringSize = ev.Graphics.MeasureString(objDtReportDetailsDataTableIn.Columns(j).Caption, ReportHeader1Font, (int)sngColumnWidth, newStringFormat);
						rowHeight = (int)sizStringSize.Height;
						if (!objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(0).ToString == "") {
							//l += r.Height
							r = new Rectangle(w + 200, l, (int)sngColumnWidth - 3, rowHeight);
							rf = new Drawing.RectangleF(w - 70, l + 2, r.Width, r.Height);
							ev.Graphics.DrawString(objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(0).ToString, ReportHeaderFont, hfBrush, rf);
						}
						l += r.Height + 10;
						for (j = 2; j <= objDtReportDetailsDataTableIn.Columns.Count - 2; j++) {
							if (IsLeftMargin == false) {
								//w = CInt(leftMargin) + 100
								w = (int)leftMargin;
								w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSampName")).Left * 72;
							} else {
								w = (int)leftMargin + 400;
							}

							sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 7).Width;
							sizStringSize = ev.Graphics.MeasureString(objDtReportDetailsDataTableIn.Columns(j).Caption, ReportHeader1Font, (int)sngColumnWidth, newStringFormat);
							rowHeight = (int)sizStringSize.Height;

							r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
							rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);
							// code added by : dinesh wagh on 27.3.2009
							//rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)'code commented by : dinesh wagh on 27.3.2009
							ev.Graphics.DrawString(objDtReportDetailsDataTableIn.Columns(j).Caption, ReportHeader1Font, hfBrush, rf);
							intLineHeigt = l + r.Height;

							if (!(objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(j).ToString == "")) {
								sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 8).Width;
								sizStringSize = ev.Graphics.MeasureString(objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(j).ToString, ReportText1Font, (int)sngColumnWidth, newStringFormat);
								rowHeight = (int)sizStringSize.Height;
								w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtDtlInfo")).Left * 50;
								//72
								r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
								rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);
								ev.Graphics.DrawString(objDtReportDetailsDataTableIn.Rows.Item(intDtlIdx).Item(j).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat);
							}
							l += r.Height;
						}
					}
				}
				mMasterIdx = MasterIdx;

				//----------------------------------- commented by : dinesh wagh on 10.2.2010
				//'If (Not objDtReportDataTableIn.Rows.Item(MasterIdx) Is Nothing) And (intAddConcLimit = 0) Then
				//'    If (CType(objDtReportDataTableIn.Rows.Item(MasterIdx + 1).Item(6), Boolean) = False) Then
				//'        intAddConcLimit = 55
				//'    End If
				//'End If
				//-------------------------------------------------

				//code added by ; dinesh wagh on 10.2.2010
				//----------------------------------------------------------------
				if ((!objDtReportDataTableIn.Rows.Item(MasterIdx) == null) & (intAddConcLimit == 0)) {
					if (((bool)objDtReportDataTableIn.Rows.Item(MasterIdx).Item(6) == false)) {
						intAddConcLimit = 55;
					}
				}
				//----------------------------------------------------------

			}
			////-----

			//            Do While j <= objDtReportDataTableIn.Columns.Count - 1

			//                If IsNumeric(mobjDvReportDataView.Item(i).Item(j).ToString()) Then

			//                    If IsNothing(ColoumnFormat) Then
			//                        ColoumnFormat = New StringFormat
			//                    End If
			//                    If SetTableColoumnFormat = True Then
			//                        ColoumnFormat.Alignment = StringAlignment.Near
			//                    End If
			//                Else
			//                    If IsNothing(ColoumnFormat) Then
			//                        ColoumnFormat = New StringFormat
			//                    End If
			//                    If SetTableColoumnFormat = True Then
			//                        ColoumnFormat.Alignment = StringAlignment.Near
			//                    End If
			//                End If

			//                CurRow = 1
			//                newStringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft
			//                newStringFormat.Alignment = StringAlignment.Near

			//                If blnIsLeft = False Then


			//                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 0).Width
			//                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, CInt(sngColumnWidth), newStringFormat)
			//                    rowHeight = CInt(sizStringSize.Height)

			//                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
			//                    rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
			//                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, hfBrush, rf)
			//                    intLineHeigt = l + r.Height

			//                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 1).Width
			//                    If Not (objDtReportDataTableIn.Rows.Item(i).Item(j).ToString = "") Then
			//                        sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, CInt(sngColumnWidth), newStringFormat)
			//                        rowHeight = CInt(sizStringSize.Height)

			//                        r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
			//                        w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt1"), DataDynamics.ActiveReports.Label).Left) * 72

			//                        rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
			//                        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat)
			//                    End If
			//                    blnIsLeft = True
			//                Else
			//                    sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 2).Width
			//                    sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, CInt(sngColumnWidth), newStringFormat)
			//                    rowHeight = CInt(sizStringSize.Height)

			//                    w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable2"), DataDynamics.ActiveReports.Label).Left * 72) - 100
			//                    r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
			//                    rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)
			//                    blnIsLeft = False
			//                    ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, hfBrush, rf)
			//                    If Not (objDtReportDataTableIn.Rows.Item(i).Item(j).ToString = "") Then
			//                        sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 3).Width
			//                        sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, CInt(sngColumnWidth), newStringFormat)
			//                        rowHeight = CInt(sizStringSize.Height)
			//                        r = New Rectangle(w, l, CInt(sngColumnWidth - 3), rowHeight)
			//                        rf = New Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height)

			//                        w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt2"), DataDynamics.ActiveReports.Label).Left) * 72 - 300
			//                        rf = New Drawing.RectangleF(w, l + 2, r.Width, r.Height)
			//                        ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, Drawing.Brushes.Black, rf, ColoumnFormat)
			//                    End If
			//                    '
			//                    w = CInt(leftMargin)
			//                    l += r.Height
			//                End If
			//continuefor2:
			//                j += 1
			//            Loop

			if (intLineHeigt > l) {
				l = intLineHeigt;
			}
			if (blnIsLeft == true) {
				l += r.Height;
			}
			//   l += rowHeight
			//Next

			//CurRow = i
			PrevRowCount = i;

			float sngXPos = leftMargin;
			int intTotalGridHeight;

			//intTotalGridHeight = CInt(rectGrid.Width)
			intTotalGridHeight = l - (int)topMargin + 10;

			ev.Graphics.DrawLine(new Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight);

			for (j = CurCol; j <= objDtReportDataTableIn.Columns.Count - 1; j++) {
				// Dim sngColumnWidth As Single

				if (NextFirstCol > 0 & j >= NextFirstCol) {
					break; // TODO: might not be correct. Was : Exit For
				}
				sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width;
				sngXPos += sngColumnWidth;
				//ev.Graphics.DrawLine(New Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight)
			}

			//ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)
			//ev.Graphics.DrawLine(New Pen(Color.Black), sngXPos, topMargin, sngXPos, topMargin + intTotalGridHeight)

			sngXPos = (int)rectGrid.Right;
			// ev.Graphics.DrawLine(New Pen(Color.Black), leftMargin, topMargin + intTotalGridHeight, sngXPos, topMargin + intTotalGridHeight)

			////----- Added & Modified by Sachin Dokhale on 28.09.05
			YPosition = (float)intTotalGridHeight;
			////-----
			if (npp >= NoOfPagesPreviewed) {
				//ev.HasMorePages = True
				//IsNextPage = True
				npp -= NoOfPagesPreviewed;
			}
			//If we have more lines then print another page
			if ((CurRow < mobjDvReportDataView.Count)) {
				//ev.HasMorePages = True
				IsNextPage = false;

			} else {
				if (NextFirstCol == 0) {
					//ev.HasMorePages = False
					IsNextPage = false;
				} else {
					CurRow = 0;
					CurCol = NextFirstCol;
					//ev.HasMorePages = True
					//IsNextPage = True
				}
			}
			intIsPageReapate = false;
			divPen.Dispose();
			hfpen.Dispose();
			hbBrush.Dispose();
			hfBrush.Dispose();

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


	private void PaintHeaderCell(Graphics g, string Sentence, Font F, Brush br, ref Rectangle Bounds, int offsetx, int offsety)
	{
		int protNRowsInCaption;
		bool blnSpace;
		try {
			protNRowsInCaption = 3;

			string[] strs = new[];
			string[] tt;
			tt = Sentence.Split(' ');
			int i;
			int j;
			int n;
			j = 0;
			string s = "";
			string os;
			os = s;
			for (i = 0; i <= protNRowsInCaption - 1; i++) {
				strs(i) = "";
			}
			for (i = 0; i <= tt.Length - 1; i++) {
				if (s != "") {
					s += " " + tt(i);
				} else {
					s = tt(i);
					os = s;
				}
				int w = (int)g.MeasureString(s, F).Width;
				if (w >= Bounds.Width) {
					strs(j) = os;
					if (s != tt(i)) {
						s = tt(i);
						os = tt(i);
					} else {
						s = "";
						os = "";
					}
					if (j == protNRowsInCaption - 1 & i <= tt.Length - 1) {
						strs(j) = "...";
						break; // TODO: might not be correct. Was : Exit For
					}
					j += 1;
				} else {
					os = s;
				}
				if (i == tt.Length - 1 & j != protNRowsInCaption) {
					strs(j) = s;
				}
			}
			n = protNRowsInCaption - 1;
			int h = (Bounds.Height % F.Height) / 2;
			int intWordCount = 0;
			h = F.Height;
			for (i = 0; i <= n; i++) {
				int w = (int)g.MeasureString(strs(i), F).Width;
				if (w < Bounds.Width) {
					w = (Bounds.Width - w) / 2;
					Bounds.Height = h;
				} else {
					if (Bounds.Width > 0) {
						while (w >= Bounds.Width) {
							strs(i) = strs(i).Substring(0, strs(i).Length - 1);
							w = (int)g.MeasureString(strs(i), F).Width;
						}
					} else {
						return;
					}
					w = 0;
				}
				g.DrawString(strs(i), F, br, Bounds.X + w + offsetx, Bounds.Y + h + offsety);

				if (!(strs(i) == "")) {
					intWordCount += 1;
					//Bounds.Height = ((intWordCount) * F.Height) + 5
				}
				h += F.Height;
			}
		//If intWordCount > 1 Then
		//    Bounds.Height = Bounds.Height - F.Height
		//End If
		} catch (Exception ex) {
			MessageBox.Show(ex.Message);
		}

	}

	private float funcGetDataTableHeight(Drawing.Graphics G, DataTable objDtTableIn, Font objPrintFont, ref float sngHeightOfHeader)
	{
		int intCount;
		float sngHeightOfDataTable;

		float sngHeightOfOneRow;
		int intColumnCount;
		int intOneRowLength;
		string strOneRowString;

		ArrayList arrTemp = new ArrayList();
		float sngMAXHeightOfOneRow;
		int intCounter;
		int j;
		int headerHeight;
		SizeF CellSize;

		try {
			sngHeightOfHeader = G.MeasureString(objDtTableIn.Columns(1).Caption, objPrintFont).Height;
			///'''''''''''''''''''''''' height of Header 
			for (j = CurCol; j <= objDtTableIn.Columns.Count - 1; j++) {
				//CellSize = funcGetColumnWidth(enumReportType.EditPigment, enumReportLayoutType.Portrate, j)
				CellSize = funcGetColumnWidth(ReportType, enumReportLayoutType.Portrate, j);

				float sngColumnWidth = CellSize.Width;

				//If w + sngColumnWidth >= rectGrid.Right And j <> CurCol Then
				//    NextFirstCol = j
				//    Exit For
				//End If
				if (sngColumnWidth == 0)
					goto continuefor;

				//Dim r As New Rectangle(w, l, CInt(sngColumnWidth + 1), headerHeight)
				// Dim r As New Rectangle(New Point(w, l), CellSize.ToSize)

				//Dim rf As New Drawing.RectangleF(w, l, r.Width, r.Height)




				//ev.Graphics.DrawLine(divPen, r.X, r.Y, r.Right, r.Y)
				//ev.Graphics.DrawLine(divPen, r.X, r.Bottom, r.Right, r.Y + r.Height)
				//w += CInt(sngColumnWidth)
				headerHeight = (int)CellSize.Height;
				continuefor:
			}
			//l += r.Height 'CellSize.ToSize.Height   'headerHeight
			sngHeightOfHeader = headerHeight;
			///'''''''''''''''''''''''''''''''''''''''''''''

			//objDtTableIn.Rows.Count - 1
			for (intCount = 0; intCount <= objDtTableIn.Rows.Count - (mintNextPageCurrentRow + 1); intCount++) {
				///'NoOfRowsPerPage + CurRow - 1 '
				arrTemp.Add(0);
				for (intColumnCount = 0; intColumnCount <= objDtTableIn.Columns.Count - 1; intColumnCount++) {
					if (IsDBNull(objDtTableIn.Rows.Item(intCount).Item(intColumnCount)) == true) {
						strOneRowString = "";
					} else {
						strOneRowString = (string)objDtTableIn.Rows.Item(intCount).Item(intColumnCount);
						sngHeightOfOneRow = G.MeasureString(strOneRowString, objPrintFont).Height;
						arrTemp.Add(sngHeightOfOneRow);
					}
				}

				//To Find the Max Height of One Row 
				sngMAXHeightOfOneRow = (float)arrTemp.Item(0);
				for (intCounter = 0; intCounter <= arrTemp.Count - 1; intCounter++) {
					if (sngMAXHeightOfOneRow < (float)arrTemp.Item(intCounter)) {
						sngMAXHeightOfOneRow = (float)arrTemp.Item(intCounter);
					}
				}
				arrTemp.Clear();

				sngHeightOfDataTable = sngHeightOfDataTable + sngMAXHeightOfOneRow;
			}

			sngHeightOfDataTable += sngHeightOfHeader;
			mintNextPageCurrentRow = CurRow;
			return sngHeightOfDataTable;

		} catch (Exception ex) {
			MessageBox.Show(ex.Message);
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

	private SizeF funcGetColumnWidth(enumReportType intReportTypeIn, enumReportLayoutType intReportLayoutType, int intColumnNumberIn)
	{
		//Single

		string strReportTypeName = "";
		float sngColumnWidth = 0.0;
		float sngCellHeight = 0.0;
		SizeF ColumnCellSize;


		try {
			switch (intReportTypeIn) {
				case enumReportType.CookBook:
					strReportTypeName = "GrpHdrWorkCondition";
				case enumReportType.DataFile:
					//mintReportTablesCount = 4 Then
					if (mintReportTextTableCount >= 0) {
						strReportTypeName = "GrpHdrDatafile";
					} else {
						strReportTypeName = "GrpHdrDatafileTable";
					}
				case enumReportType.StadardGraph:
					strReportTypeName = "GrpHdrStadGraph";
				case enumReportType.SampleGraph:
					strReportTypeName = "GrpHdrSampleGraph";
				case enumReportType.PrintPeak_Valley:
					if (mintReportTextTableCount >= 0) {
						strReportTypeName = "GrpHdrSpectrum";
					} else {
						strReportTypeName = "GrpHdrPeakValley";
					}
				//strReportTypeName = "GrpHdrDatafile"
				case enumReportType.EnergySpectrum:
				case enumReportType.UVSpectrum:
				case enumReportType.Histograph:
				case enumReportType.Histograph:
				case enumReportType.Histograph:

					//If mintReportTextTableCount >= 0 Then
					strReportTypeName = "GrpHdrSpectrum";
				//Else
				//strReportTypeName = "GrpHdrPeakValley"
				//End If
				case enumReportType.RepeatResults:

					strReportTypeName = "GrpHdrRepeatResults";
				default:
					strReportTypeName = "";
			}

			int intColumnLablesCount;

			if (!strReportTypeName == "") {
				switch (intReportLayoutType) {
					case enumReportLayoutType.Portrate:
						intColumnLablesCount = mobjARPortrateReport.Sections(strReportTypeName).Controls.Count - 1;

						if (intColumnNumberIn <= intColumnLablesCount) {
							sngColumnWidth = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnNumberIn)).Width * 96;
							sngCellHeight = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnNumberIn)).Height * 96;
							if (SetTableColoumnFormat == false) {
								if (!(ColoumnFormat == null)) {
									//ColoumnFormat.Alignment = StringAlignment.Near
									ColoumnFormat.Alignment = IIf(((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnNumberIn)).Alignment() == DataDynamics.ActiveReports.TextAlignment.Justify, StringAlignment.Near, (StringAlignment)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnNumberIn)).Alignment());
								}
							}
						} else {
							sngColumnWidth = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnLablesCount)).Width * 96;
							sngCellHeight = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnLablesCount)).Height * 96;
							if (SetTableColoumnFormat == false) {
								if (!(ColoumnFormat == null)) {
									//ColoumnFormat.Alignment = StringAlignment.Near
									ColoumnFormat.Alignment = IIf(((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnLablesCount)).Alignment() == DataDynamics.ActiveReports.TextAlignment.Justify, StringAlignment.Near, (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections(strReportTypeName).Controls(intColumnLablesCount)).Alignment());
								}
							}
						}
						ColumnCellSize.Width = sngColumnWidth;

						ColumnCellSize.Height = sngCellHeight;
					case enumReportLayoutType.Landscape:
					//'intColumnLablesCount = mobjARLandScapeReport.Sections(strReportTypeName).Controls.Count - 1
					//'If intColumnNumberIn <= intColumnLablesCount Then
					//'    sngColumnWidth = CType(mobjARLandScapeReport.Sections(strReportTypeName).Controls(intColumnNumberIn), DataDynamics.ActiveReports.Label).Width * 96
					//'    sngCellHeight = CType(mobjARLandScapeReport.Sections(strReportTypeName).Controls(intColumnNumberIn), DataDynamics.ActiveReports.Label).Height * 96
					//'Else
					//'    sngColumnWidth = CType(mobjARLandScapeReport.Sections(strReportTypeName).Controls(intColumnLablesCount), DataDynamics.ActiveReports.Label).Width * 96
					//'    'sngCellHeight = CType(mobjARLandScapeReport.Sections(strReportTypeName).Controls(intColumnNumberIn), DataDynamics.ActiveReports.Label).Height * 96
					//'    sngCellHeight = CType(mobjARLandScapeReport.Sections(strReportTypeName).Controls(intColumnLablesCount), DataDynamics.ActiveReports.Label).Height * 96
					//'End If
					//'ColumnCellSize.Width = sngColumnWidth
					//'ColumnCellSize.Height = sngCellHeight
				}
			} else {
				sngColumnWidth = 0;
				sngCellHeight = 0;


			}
			//ColoumnFormat = New StringFormat


			return ColumnCellSize;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return SizeF.Empty;
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

	private bool ExportData()
	{
		//=====================================================================
		// Procedure Name        : ExportData
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Friday, March 04, 2005
		// Revisions             : 1
		//=====================================================================
		DataTable objDtExpRptTable;
		string strReportHeader;
		string strReportFooter;
		DataSet objDS;
		DataSet objDSText;
		bool blnResult;
		string strReportName;
		string strGraphImageFilePath;
		string strSpaceDiagramImageFilePath;
		Bitmap objGraphImage;
		Bitmap objSpaceDiagramImage;
		Bitmap objReportImage;
		int intTableCounter;
		ArrayList arrReportImageList;
		int intImageCounter;
		ArrayList arrReportImageCaptionList;
		AAS203Library.Method.clsReportParameters objReportParameter;
		//Dim cWait As CWaitCursor

		try {
			blnResult = false;

			strReportName = this.ReportType.ToString;
			objDS = new DataSet(strReportName);
			objDSText = new DataSet(strReportName);

			strReportHeader = mobjstructReportFormat.ReportTitleLine1 + vbCrLf + mobjstructReportFormat.ReportTitleLine2 + vbCrLf + mobjstructReportFormat.ReportTitleLine3;
			strReportFooter = mobjstructReportFormat.ReportFooterLine1;

			if (IsNothing(this.ReportDataTables) == false) {
				for (intTableCounter = 0; intTableCounter <= this.ReportDataTables.Count - 1; intTableCounter++) {
					objDtExpRptTable = ((DataTable)this.ReportDataTables.Item(intTableCounter)).Copy;
					objDS.Tables.Add(objDtExpRptTable);
				}
			}

			objDtExpRptTable = new DataTable();
			if (IsNothing(this.ReportTextList) == false) {
				for (intTableCounter = 0; intTableCounter <= this.ReportTextList.Count - 1; intTableCounter++) {
					objDtExpRptTable = ((DataTable)this.ReportTextList.Item(intTableCounter)).Copy;
					objDSText.Tables.Add(objDtExpRptTable);
				}
			}

			arrReportImageList = new ArrayList();
			arrReportImageCaptionList = new ArrayList();

			int intCount;
			if (IsNothing(marrGraphControlsList) == false) {
				for (intCount = 0; intCount <= marrGraphControlsList.Count - 1; intCount++) {
					if (IsNothing(marrGraphControlsList.Item(intCount)) == false) {
						//'If TypeOf marrGraphControlsList.Item(intCount) Is AldysGraph.AldysGraph Then
						//'    Dim objGraph As AldysGraph.AldysGraph = CType(marrGraphControlsList.Item(intCount), AldysGraph.AldysGraph)
						//'    objGraphImage = objGraph.GraphImage
						//'    arrReportImageList.Add(objGraphImage)
						//'    arrReportImageCaptionList.Add(objGraph.AldysPane.Title)
						//'End If
						//'If TypeOf marrGraphControlsList.Item(intCount) Is ColorSpaceDiagram.ColorSpaceDiagram Then
						//'    Dim objGraph As ColorSpaceDiagram.ColorSpaceDiagram = CType(marrGraphControlsList.Item(intCount), ColorSpaceDiagram.ColorSpaceDiagram)
						//'    objGraphImage = objGraph.GraphImage
						//'    arrReportImageList.Add(objGraphImage)
						//'    arrReportImageCaptionList.Add(objGraph.AldysPane.Title)
						//'End If
					}
				}
			}

			if (IsNothing(mobjDtImageList) == false) {
				for (intImageCounter = 0; intImageCounter <= mobjDtImageList.Rows.Count - 1; intImageCounter++) {
					objReportImage = (Bitmap)mobjDtImageList.Rows(intImageCounter).Item("Image");
					arrReportImageList.Add(objReportImage);
					arrReportImageCaptionList.Add((string)mobjDtImageList.Rows(intImageCounter).Item("ImageCaption"));
				}
			}

			//'dlgResult = MessageBox.Show("Select Report Format: Yes For Html  Or No For Text Report", "Export Report", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
			//blnResult = gobjMessageAdapter.ShowMessage(msgIDSelectReportFormat)
			//Application.DoEvents()
			//cWait = New CWaitCursor

			switch (blnResult) {
				case true:
				//---Html File
				//clsDataSetExport.ExportHtml(strReportName, objDS, strReportHeader, mstrPageHeader, mstrPageText, arrReportImageList, arrReportImageCaptionList)

				case false:
					//---Text File
					if (this.ReportType == enumReportType.Others) {
						clsDataSetExport.ExportRTF(strReportName, objDSText, objDS, strReportHeader, mstrPageHeader, mstrPageText);
					} else if (this.ReportType == enumReportType.DataFile) {
						clsDataSetExport.funcExportData(strReportName, objDSText, objDS, strReportHeader, this.PageHeader.TextString, mstrPageText, this.ReportFooter.TextString, DataFileReportParameter);
					}
				//clsDataSetExport.funcExportData(strReportName, objDSText, objDS, strReportHeader, mstrPageHeader, mstrPageText, strReportFooter, DataFileReportParameter)
				//clsDataSetExport.funcExportData(strReportName, objDSText, objDS, strReportHeader, Me.PageHeader.TextString, mstrPageText, Me.ReportFooter.TextString, DataFileReportParameter)
			}

			return true;

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
			//If Not cWait Is Nothing Then
			//    cWait.Dispose()
			//End If
		}

	}

	private bool eMailData()
	{
		//=====================================================================
		// Procedure Name        : eMailData
		// Parameters Passed     : 
		// Returns               : 
		// Purpose               : 
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul At Machine SOFT1
		// Created               : Friday, March 04, 2005
		// Revisions             : 1
		//=====================================================================
		DataTable objDtExpRptTable;
		string strReportHeader;
		DataSet objDS;
		int intTableCounter;

		try {
			strReportHeader = mobjstructReportFormat.ReportTitleLine1 + vbCrLf + mobjstructReportFormat.ReportTitleLine2 + vbCrLf + mobjstructReportFormat.ReportTitleLine3;

			if (IsNothing(this.ReportDataTables) == false) {
				for (intTableCounter = 0; intTableCounter <= this.ReportDataTables.Count - 1; intTableCounter++) {
					objDtExpRptTable = ((DataTable)this.ReportDataTables.Item(intTableCounter)).Copy;
					objDS.Tables.Add(objDtExpRptTable);
				}
			}

			//'clsDataSetExport.SendEMail(objDS)

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool ArrangeImagesInGrid(DataTable objDtImageListIn, ref Graphics G, int ColumnCount, float LeftMargin, float YPosition)
	{
		//=====================================================================
		// Procedure Name        : ArrangeImagesInGrid
		// Parameters Passed     : Images List with Captions as DataTable
		// Returns               : true or false
		// Purpose               : To show the layout with Images on the report
		// Description           : if single row grid is set the 
		//                         columncount = number of Images otherwise divide total 
		//                         number of controls by the column count set the user
		//                         and arrange all the Images by using horizontal and 
		//                         vertical spacing and size of the Images
		//
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : Thursday, April 07, 2005
		// Revisions             : 
		//=====================================================================
		//---if single row grid is set the columncount = number of Images
		//---otherwise divide total number of images by the column count set the user
		//---and arrange all the images by using horizontal and vertical spacing 
		//---and size of the images
		int colObjects;
		int rowCounter;
		int ColCounter;
		int ObjIndex = 0;
		double RowCount;
		int unEvenObjectsCount;
		int unEvenObjectsCounter = 0;
		bool CheckForUnEvenObjects;

		Bitmap objBitmapImage;
		RectangleF[] rectImage;
		RectangleF rectImageCaption;

		float ControlVSpacing = 10;
		float ControlHSpacing = 10;
		float sngYHeight;
		float sngYHeight2;

		try {
			if (objDtImageListIn.Rows.Count == 1) {
				ColumnCount = objDtImageListIn.Rows.Count;
			}

			if (ColumnCount > objDtImageListIn.Rows.Count) {
				return false;
			} else if (ColumnCount <= 0) {
				return false;

			} else {
				 // ERROR: Not supported in C#: ReDimStatement


				switch (ColumnCount) {
					case 1:
						sngYHeight = 0;
						sngYHeight2 = YPosition;
						for (colObjects = 0; colObjects <= objDtImageListIn.Rows.Count - 1; colObjects++) {
							objBitmapImage = (Bitmap)objDtImageListIn.Rows(colObjects).Item("Image");
							rectImage(colObjects).Height = objBitmapImage.Height;
							rectImage(colObjects).Width = objBitmapImage.Width;

							////-----
							//sngYHeight = YPosition + rectImage(colObjects).Height

							//If sngYHeight >= mintPageFooterYPosotion Then
							//CheckForUnEvenObjects = True
							//Return False
							//End If

							//sngYHeight = sngYHeight2 + objBitmapImage.Height
							//If (sngYHeight + (lineSpacing + rectImageCaption.Height)) >= mintPageFooterYPosotion Then
							//    CheckForUnEvenObjects = True
							//    Return True
							//End If
							////-----
							if (colObjects == 0) {
								//---Set First Location
								rectImage(colObjects).Location = new PointF(LeftMargin, YPosition);
							} else {
								//---Set Each Incremental Locations
								rectImage(colObjects).Location = new PointF(rectImage(colObjects - 1).Location.X, rectImage(colObjects - 1).Location.Y + rectImage(colObjects - 1).Height + ControlVSpacing);
							}

							//=====================================================================
							// Description explaining the steps followed: 
							//--- Draw Image and Image Caption 
							//=====================================================================
							G.DrawImage(objBitmapImage, rectImage(colObjects));

							string strImageCaption = (string)objDtImageListIn.Rows(colObjects).Item("ImageCaption");
							rectImageCaption.Height = G.MeasureString(strImageCaption, printFont).Height;
							rectImageCaption.Width = rectImage(colObjects).Width;
							rectImageCaption.Y = rectImage(colObjects).Y + rectImage(colObjects).Height;
							rectImageCaption.X = rectImage(colObjects).X;

							G.DrawString(strImageCaption, printFont, new Pen(Color.Black).Brush, rectImageCaption);

							rectImage(colObjects).Height += rectImageCaption.Height;
							//=====================================================================
							////-----
							sngYHeight2 = sngYHeight;
							////-----

						}

					case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
1:
						RowCount = (objDtImageListIn.Rows.Count) / ColumnCount;

						unEvenObjectsCount = (objDtImageListIn.Rows.Count) - (int)Fix(RowCount) * ColumnCount;
						//---Decide UnEven or Even no. of Columns 
						if (unEvenObjectsCount > 0) {
							RowCount = Fix(RowCount) + 1;
							CheckForUnEvenObjects = true;
						} else {
							CheckForUnEvenObjects = false;
						}
						sngYHeight = 0;
						sngYHeight2 = YPosition;


						for (rowCounter = 0; rowCounter <= (int)Fix(RowCount) - 1; rowCounter++) {


							for (ColCounter = 0; ColCounter <= ColumnCount - 1; ColCounter++) {
								objBitmapImage = (Bitmap)objDtImageListIn.Rows(ObjIndex).Item("Image");
								rectImage(ObjIndex).Height = objBitmapImage.Height;
								rectImage(ObjIndex).Width = objBitmapImage.Width;

								//'sngYHeight = sngYHeight2 + objBitmapImage.Height + (lineSpacing + rectImageCaption.Height)
								//sngYHeight = sngYHeight2 + rectImage(ObjIndex).Height + (lineSpacing + rectImageCaption.Height)
								//'sngYHeight = (lineSpacing + rectImageCaption.Height + rectImageCaption.Y)

								//If (sngYHeight) >= mintPageFooterYPosotion Then
								//    CheckForUnEvenObjects = True
								//    Return True
								//End If



								if (rowCounter == 0) {
									if (ColCounter == 0) {
										//---Set First Location
										rectImage(ObjIndex).Location = new PointF(LeftMargin, YPosition);
									} else {
										//---Set Each Next Location
										rectImage(ObjIndex).Location = new PointF(rectImage(ObjIndex - 1).Location.X + rectImage(ObjIndex - 1).Width + ControlHSpacing, rectImage(ObjIndex - 1).Location.Y);
									}
								} else {
									if (unEvenObjectsCount > 0) {
										if (rowCounter == Int(Fix(RowCount) - 1)) {
											unEvenObjectsCounter = unEvenObjectsCounter + 1;
										}
									}

									if (ColCounter == 0) {
										//---Set First Location
										rectImage(ObjIndex).Location = new PointF(rectImage(ObjIndex - (ColumnCount - 1)).Location.X - rectImage(ObjIndex - 1).Width - ControlHSpacing, rectImage(ObjIndex - 1).Location.Y + rectImage(ObjIndex - 1).Height + ControlVSpacing);
									} else {
										//---Set Each Next Location
										rectImage(ObjIndex).Location = new PointF(rectImage(ObjIndex - 1).Location.X + rectImage(ObjIndex - 1).Width + ControlHSpacing, rectImage(ObjIndex - 1).Location.Y);
									}
								}

								if (!objDtImageListIn.Rows(ObjIndex).Item("Image") == null) {
									//---Draw Image
									//=====================================================================
									// Description explaining the steps followed: 
									//--- Draw Image and Image Caption 
									//=====================================================================
									G.DrawImage(objBitmapImage, rectImage(ObjIndex));

									string strImageCaption = (string)objDtImageListIn.Rows(ObjIndex).Item("ImageCaption");
									rectImageCaption.Height = G.MeasureString(strImageCaption, printFont).Height;
									rectImageCaption.Width = rectImage(ObjIndex).Width;
									rectImageCaption.Y = rectImage(ObjIndex).Y + rectImage(ObjIndex).Height;
									rectImageCaption.X = rectImage(ObjIndex).X;

									G.DrawString(strImageCaption, printFont, new Pen(Color.Black).Brush, rectImageCaption);

									rectImage(ObjIndex).Height += rectImageCaption.Height;
									//=====================================================================

								}

								ObjIndex = ObjIndex + 1;

								if (CheckForUnEvenObjects == true) {
									if (unEvenObjectsCounter == unEvenObjectsCount) {
										break; // TODO: might not be correct. Was : Exit For
									}
								}
							}


						}

				}

			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	private bool funcDrawAllGraphs(ref PrintPageEventArgs EV, ref float sngYPositionIn, float sngLeftMarginIn)
	{

		RectangleF rectGraph;
		float sngHeightOfGraph;
		AldysGraph.AldysGraph objGraphCtrl;
		//Dim objSpaceGraphCtrl As ColorSpaceDiagram.ColorSpaceDiagram
		ArrayList arrGraphsPerPage;
		int intGraphCtrlCounter;
		int intEachGraphHeight;
		int nrperpage;
		int intNoOfGraphsPerPage;
		int intColumnsPerPage;
		int intRectGraphYPosition;
		//Dim cWait As CWaitCursor
		static bool intIsPageReapate;

		try {
			rectGraph.X += sngLeftMarginIn;
			rectGraph.Y += sngYPositionIn;
			rectGraph.Height = EV.MarginBounds.Height - sngYPositionIn;
			rectGraph.Width = EV.MarginBounds.Width;

			if (IsNothing(this.ReportGraphControls) == true) {
				return;
			}


			sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));
			rectGraph.Y = sngYPositionIn;

			//---Work out the number of pages
			intNoOfGraphsPerPage = 1;
			intEachGraphHeight = ((Control)marrGraphControlsList.Item(0)).Height;

			////----- Added by Sachin Dokhale on 28.09.05
			if (rectGraph.Height > 0) {
				intRectGraphYPosition = (int)rectGraph.Y + intEachGraphHeight;
			} else {
				intRectGraphYPosition = (int)rectGraph.Y;
				//(rectImage.Y)
			}

			if (intRectGraphYPosition >= mintPageFooterYPosotion) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//Application.DoEvents()
						//cWait = New CWaitCursor
					}

					EV.HasMorePages = false;
					EV.Cancel = true;
					return;
				}

				EV.HasMorePages = true;
				intIsPageReapate = true;
				return;
			}

			////-----

			if (mintReportLayoutType == enumReportLayoutType.Portrate) {
				intColumnsPerPage = 1;
			} else {
				intColumnsPerPage = 2;
			}

			nrperpage = (int)rectGraph.Height / intEachGraphHeight;
			if (nrperpage == 0) {
				if (intIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//Application.DoEvents()
						//cWait = New CWaitCursor

						blnPageSettingMessage = true;
					}
					EV.HasMorePages = false;
					EV.Cancel = true;
					return true;
				}
				intIsPageReapate = true;
				EV.HasMorePages = true;
				return true;
			}

			//---Work out no. of pages considering no. of columns in each page
			nrperpage = nrperpage * intColumnsPerPage;
			//intNoOfGraphsPerPage

			arrGraphsPerPage = new ArrayList();
			int intRemMod;
			int intGraphCounter;
			int intGraphCount;
			int IntHigherHight1;
			int IntHigherHight2;
			bool blnNextHeight = false;
			intGraphCounter = mintCurrentGraph;
			for (intGraphCtrlCounter = mintCurrentGraph; intGraphCtrlCounter <= nrperpage + mintCurrentGraph - 1; intGraphCtrlCounter++) {
				if (intGraphCtrlCounter >= marrGraphControlsList.Count) {
					break; // TODO: might not be correct. Was : Exit For
				}
				arrGraphsPerPage.Add(marrGraphControlsList.Item(intGraphCtrlCounter));

			}


			if (ArrangeGraphsInGrid(arrGraphsPerPage, EV.Graphics, intColumnsPerPage, sngLeftMarginIn, sngYPositionIn)) {
				//nrperpage + mintCurrentGraph - 1
				for (intGraphCount = 0; intGraphCount <= intGraphCtrlCounter - mintCurrentGraph; intGraphCount++) {

					//marrGraphControlsList.Count Then
					if (intGraphCount >= (intGraphCtrlCounter - mintCurrentGraph)) {
						break; // TODO: might not be correct. Was : Exit For
					}
					////----- Added by Sachin Dokhale on 02.09.07
					////----- Print Graph with Constant Size
					//intPrevious_Height = CType(arrGraphsPerPage.Item(intGraphCount), Control).Height
					//CType(arrGraphsPerPage.Item(intGraphCount), Control).Height = CONST_Height

					//intPrevious_Width = CType(arrGraphsPerPage.Item(intGraphCount), Control).Width
					//CType(arrGraphsPerPage.Item(intGraphCount), Control).Width = CONST_Width
					////-----

					if (mintReportLayoutType == enumReportLayoutType.Portrate) {
						//sngYPositionIn += CType(arrGraphsPerPage.Item(intGraphCount), Control).Height
						sngYPositionIn += CONST_GraphHeight;
						sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));
					} else {
						intRemMod = (int)intGraphCount % 2;
						//intRemMod = a Mod 2
						if (intRemMod == 0) {
							//IntHigherHight1 = CType(arrGraphsPerPage.Item(intGraphCount), Control).Height
							IntHigherHight1 = CONST_GraphHeight;
							IntHigherHight2 = 0;
							blnNextHeight = true;
						} else if (intRemMod == 1) {
							//IntHigherHight2 = CType(arrGraphsPerPage.Item(intGraphCount), Control).Height
							IntHigherHight2 = CONST_GraphHeight;
							blnNextHeight = false;
						}

						if (IntHigherHight1 > IntHigherHight2) {
							if (blnNextHeight == true) {
								sngYPositionIn += IntHigherHight1;
								sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));
							}
						} else {
							sngYPositionIn += IntHigherHight2 - IntHigherHight1;
							sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));
						}
					}
					////----- Added by Sachin Dokhale on 02.09.07
					////----- Set original Graph size
					//CType(arrGraphsPerPage.Item(intGraphCount), Control).Height = intPrevious_Height
					//CType(arrGraphsPerPage.Item(intGraphCount), Control).Width = intPrevious_Width
					////-----
				}

				mintCurrentGraph = intGraphCtrlCounter;
				intIsPageReapate = false;
				//If we have more Graphs then print another page
				if ((mintCurrentGraph < marrGraphControlsList.Count)) {
					EV.HasMorePages = true;
					intGraphCount = 0;
					intGraphCounter = 0;
				} else {
					EV.HasMorePages = false;
					//mintCurrentGraph = 0
				}
			}
			intIsPageReapate = false;
			return true;

			return;

			while (mintReportGraphsCount < marrGraphControlsList.Count) {
				//---For CommonGraphControl and CieGraphControl
				if (marrGraphControlsList.Item(mintReportGraphsCount) is AldysGraph.AldysGraph) {
					objGraphCtrl = (AldysGraph.AldysGraph)marrGraphControlsList.Item(mintReportGraphsCount);
					rectGraph.Height = objGraphCtrl.Height;

					if ((objGraphCtrl) is AldysGraph.AldysGraph) {
						rectGraph.Width = (float)objGraphCtrl.Height * 1.75;
					} else if ((objGraphCtrl) is AldysGraph.AldysGraph) {
						rectGraph.Width = (float)objGraphCtrl.Height * 1.5;
					}
					string strGraphTitle;
					strGraphTitle = "Graph of " + objGraphCtrl.AldysPane.XAxis.Title + " Vs. " + objGraphCtrl.AldysPane.YAxis.Title;
					//commented by deepak on 24.08.07
					//objGraphCtrl.AldysPane.Title = strGraphTitle
					objGraphCtrl.AldysPane.Title = "";
					//---Draw Common Graph
					objGraphCtrl.DrawGraphOnGraphics(EV.Graphics, (int)rectGraph.X, (int)rectGraph.Y, (int)rectGraph.Width, (int)rectGraph.Height);
					objGraphCtrl.AldysPane.Title = "";
				}

				//---For ColorSpaceDiagramGraphControl 
				//If TypeOf marrGraphControlsList.Item(mintReportGraphsCount) Is ColorSpaceDiagram.ColorSpaceDiagram Then
				//    objSpaceGraphCtrl = CType(marrGraphControlsList.Item(mintReportGraphsCount), ColorSpaceDiagram.ColorSpaceDiagram)
				//    rectGraph.Height = objSpaceGraphCtrl.Height
				//    rectGraph.Width = CSng(objSpaceGraphCtrl.Height * 1.75)

				//    Dim strGraphTitle As String
				//    If objSpaceGraphCtrl.AldysPane.IsDCDH = True Then
				//        strGraphTitle = " DC/DH Plot "
				//    Else
				//        strGraphTitle = " DA/DB Plot "
				//    End If
				//    If objSpaceGraphCtrl.AldysPane.IsLABCH = True Then
				//        strGraphTitle = " LABCH Plot "
				//    End If
				//    objSpaceGraphCtrl.AldysPane.Title = strGraphTitle
				//    objSpaceGraphCtrl.DrawGraphOnGraphics(EV.Graphics, CInt(rectGraph.X), CInt(rectGraph.Y), CInt(rectGraph.Width), CInt(rectGraph.Height))
				//    objSpaceGraphCtrl.AldysPane.Title = ""
				//End If

				//---Increment GridRect Location 
				if (mintReportLayoutType == enumReportLayoutType.Portrate) {
					sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));
					sngYPositionIn += ((Control)this.ReportGraphControls.Item(mintReportGraphsCount)).Height;

					rectGraph.X = sngLeftMarginIn;
					rectGraph.Y = sngYPositionIn;
				} else if (mintReportLayoutType == enumReportLayoutType.Landscape) {
					rectGraph.X = sngLeftMarginIn + rectGraph.Width + lineSpacing + printFont.GetHeight(EV.Graphics);
					rectGraph.Y = sngYPositionIn;
				}

				sngYPositionIn = rectGraph.Y;

				if (EV.HasMorePages == false) {
					mintReportGraphsCount += 1;
					if (!mintReportGraphsCount == this.marrGraphControlsList.Count) {
						sngHeightOfGraph = ((Control)this.marrGraphControlsList.Item(mintReportGraphsCount)).Height;

						if ((EV.MarginBounds.Height - rectGraph.Y) > (sngHeightOfGraph + lineSpacing + printFont.GetHeight(EV.Graphics))) {
							//---Continue printing on same page
							EV.HasMorePages = false;
						} else {
							//---go to the new page
							EV.HasMorePages = true;
							return;
						}
					}
				} else {
					return;
				}

			}

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			//If Not cWait Is Nothing Then
			//cWait.Dispose()
			//End If
		}
	}

	private bool ArrangeGraphsInGrid(ArrayList arrGraphListIn, ref Graphics G, int ColumnCount, float LeftMargin, float YPosition)
	{
		//=====================================================================
		// Procedure Name        : ArrangeGraphsInGrid
		// Parameters Passed     : 
		// Returns               : true or false
		// Purpose               : To show the layout with Graphs on the report
		// Description           : if single row grid is set the 
		//                         columncount = number of Graphs otherwise divide total 
		//                         number of controls by the column count set the user
		//                         and arrange all the Graphs by using horizontal and 
		//                         vertical spacing and size of the Graphs
		//
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Mangesh Shardul
		// Created               : Wednesday, April 20, 2005
		// Revisions             : 
		//=====================================================================
		//---if single row grid is set the columncount = number of Graphs
		//---otherwise divide total number of Graphs by the column count set the user
		//---and arrange all the Graphs by using horizontal and vertical spacing 
		//---and size of the Graphs
		int colObjects;
		int rowCounter;
		int ColCounter;
		int ObjIndex = 0;
		double RowCount;
		int unEvenObjectsCount;
		int unEvenObjectsCounter = 0;
		bool CheckForUnEvenObjects;

		RectangleF[] rectGraph;

		float ControlVSpacing = 10;
		float ControlHSpacing = 10;
		//Static CONST_Height = 350
		//Static CONST_Width = 550
		int intPrevious_Height;
		int intPrevious_Width;

		try {
			if (arrGraphListIn.Count == 1) {
				ColumnCount = arrGraphListIn.Count;
			}

			if (ColumnCount > arrGraphListIn.Count) {
				return false;
			} else if (ColumnCount <= 0) {
				return false;

			} else {
				 // ERROR: Not supported in C#: ReDimStatement


				switch (ColumnCount) {
					case 1:
						for (colObjects = 0; colObjects <= arrGraphListIn.Count - 1; colObjects++) {
							AldysGraph.AldysGraph objGraphCtrl;
							//Dim objSpaceGraphCtrl As ColorSpaceDiagram.ColorSpaceDiagram
							//---For CommonGraphControl and CieGraphControl
							if (arrGraphListIn.Item(colObjects) is AldysGraph.AldysGraph) {
								objGraphCtrl = (AldysGraph.AldysGraph)arrGraphListIn.Item(colObjects);

								////----- Modified by Sachin Dokhale on 03.09.07
								////----- To print the fix size of graph 
								//rectGraph(colObjects).Height = objGraphCtrl.Height
								//rectGraph(colObjects).Width = objGraphCtrl.Width
								//If TypeOf (objGraphCtrl) Is AldysGraph.AldysGraph Then
								//    rectGraph(colObjects).Width = CSng(objGraphCtrl.Height * 1.75)
								//ElseIf TypeOf (objGraphCtrl) Is AldysGraph.AldysGraph Then
								//    rectGraph(colObjects).Width = CSng(objGraphCtrl.Height * 1.5)
								//End If
								rectGraph(colObjects).Height = CONST_GraphHeight;
								rectGraph(colObjects).Width = CONST_GraphWidth;
								////-----
							}
							//If TypeOf arrGraphListIn.Item(colObjects) Is ColorSpaceDiagram.ColorSpaceDiagram Then
							//    objSpaceGraphCtrl = CType(arrGraphListIn.Item(colObjects), ColorSpaceDiagram.ColorSpaceDiagram)
							//    rectGraph(colObjects).Height = objSpaceGraphCtrl.Height
							//    rectGraph(colObjects).Width = CSng(objSpaceGraphCtrl.Height * 1.75)
							//End If

							if (colObjects == 0) {
								//---Set First Location
								rectGraph(colObjects).Location = new PointF(LeftMargin, YPosition);
							} else {
								//---Set Each Incremental Locations
								rectGraph(colObjects).Location = new PointF(rectGraph(colObjects - 1).Location.X, rectGraph(colObjects - 1).Location.Y + rectGraph(colObjects - 1).Height + ControlVSpacing);
							}
							//=====================================================================
							// Description explaining the steps followed: 
							//--- Draw Common Graph 
							//=====================================================================
							string strGraphTitle;
							if (!IsNothing(objGraphCtrl) == true) {
								strGraphTitle = "Graph of " + objGraphCtrl.AldysPane.XAxis.Title + " Vs. " + objGraphCtrl.AldysPane.YAxis.Title;
								//objGraphCtrl.AldysPane.Title = strGraphTitle
								//commented by deepak on 24.08.07
								objGraphCtrl.AldysPane.Title = "";
								objGraphCtrl.DrawGraphOnGraphics(G, (int)rectGraph(colObjects).X, (int)rectGraph(colObjects).Y, (int)rectGraph(colObjects).Width, (int)rectGraph(colObjects).Height);
								objGraphCtrl.AldysPane.Title = "";
							}
							//objGraphCtrl.Dispose()
							objGraphCtrl = null;

							//---Color Space Diagram
							//If Not IsNothing(objSpaceGraphCtrl) = True Then
							//    If objSpaceGraphCtrl.AldysPane.IsDCDH = True Then
							//        strGraphTitle = " DC/DH Plot "
							//    Else
							//        strGraphTitle = " DA/DB Plot "
							//    End If
							//    If objSpaceGraphCtrl.AldysPane.IsLABCH = True Then
							//        strGraphTitle = " LABCH Plot "
							//    End If
							//    objSpaceGraphCtrl.AldysPane.Title = strGraphTitle
							//    objSpaceGraphCtrl.DrawGraphOnGraphics(G, CInt(rectGraph(colObjects).X), CInt(rectGraph(colObjects).Y), CInt(rectGraph(colObjects).Width), CInt(rectGraph(colObjects).Height))
							//    objSpaceGraphCtrl.AldysPane.Title = ""
							//End If
							//'objSpaceGraphCtrl.Dispose()
							//objSpaceGraphCtrl = Nothing
							//=====================================================================

						}

					case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
1:
						RowCount = arrGraphListIn.Count / ColumnCount;

						unEvenObjectsCount = (arrGraphListIn.Count) - (int)Fix(RowCount) * ColumnCount;
						//---Decide UnEven or Even no. of Columns 
						if (unEvenObjectsCount > 0) {
							RowCount = Fix(RowCount) + 1;
							CheckForUnEvenObjects = true;
						} else {
							CheckForUnEvenObjects = false;
						}

						for (rowCounter = 0; rowCounter <= (int)Fix(RowCount) - 1; rowCounter++) {
							for (ColCounter = 0; ColCounter <= ColumnCount - 1; ColCounter++) {
								AldysGraph.AldysGraph objGraphCtrl;
								//Dim objSpaceGraphCtrl As ColorSpaceDiagram.ColorSpaceDiagram

								if (arrGraphListIn.Item(ObjIndex) is AldysGraph.AldysGraph) {
									objGraphCtrl = (AldysGraph.AldysGraph)arrGraphListIn.Item(ObjIndex);
									////----- Modified by Sachin Dokhale on 03.09.07
									////----- To print the fix size of graph 
									//rectGraph(ObjIndex).Height = objGraphCtrl.Height
									//rectGraph(ObjIndex).Width = objGraphCtrl.Width
									//If TypeOf (objGraphCtrl) Is AldysGraph.AldysGraph Then
									//    rectGraph(ObjIndex).Width = CSng(objGraphCtrl.Height * 1.75)
									//ElseIf TypeOf (objGraphCtrl) Is AldysGraph.AldysGraph Then
									//    rectGraph(ObjIndex).Width = CSng(objGraphCtrl.Height * 1.5)
									//End If
									rectGraph(ObjIndex).Height = CONST_GraphHeight;
									rectGraph(ObjIndex).Width = CONST_GraphWidth;
									////-----
								}
								//If TypeOf arrGraphListIn.Item(ObjIndex) Is ColorSpaceDiagram.ColorSpaceDiagram Then
								//    objSpaceGraphCtrl = CType(arrGraphListIn.Item(ObjIndex), ColorSpaceDiagram.ColorSpaceDiagram)
								//    rectGraph(ObjIndex).Height = objSpaceGraphCtrl.Height
								//    rectGraph(ObjIndex).Width = CSng(objSpaceGraphCtrl.Height * 1.75)
								//End If

								if (rowCounter == 0) {
									if (ColCounter == 0) {
										//---Set First Location
										rectGraph(ObjIndex).Location = new PointF(LeftMargin, YPosition);
									} else {
										//---Set Each Next Location
										rectGraph(ObjIndex).Location = new PointF(rectGraph(ObjIndex - 1).Location.X + rectGraph(ObjIndex - 1).Width + ControlHSpacing, rectGraph(ObjIndex - 1).Location.Y);
									}
								} else {
									if (unEvenObjectsCount > 0) {
										if (rowCounter == Int(Fix(RowCount) - 1)) {
											unEvenObjectsCounter = unEvenObjectsCounter + 1;
										}
									}

									if (ColCounter == 0) {
										//---Set First Location
										rectGraph(ObjIndex).Location = new PointF(rectGraph(ObjIndex - (ColumnCount - 1)).Location.X - rectGraph(ObjIndex - 1).Width - ControlHSpacing, rectGraph(ObjIndex - 1).Location.Y + rectGraph(ObjIndex - 1).Height + ControlVSpacing);
									} else {
										//---Set Each Next Location
										rectGraph(ObjIndex).Location = new PointF(rectGraph(ObjIndex - 1).Location.X + rectGraph(ObjIndex - 1).Width + ControlHSpacing, rectGraph(ObjIndex - 1).Location.Y);
									}
								}

								if (!arrGraphListIn.Item(ObjIndex) == null) {
									//=====================================================================
									// Description explaining the steps followed: 
									//--- Draw Common Graph And CIE Graph
									//=====================================================================
									string strGraphTitle;
									if (!IsNothing(objGraphCtrl) == true) {
										strGraphTitle = "Graph of " + objGraphCtrl.AldysPane.XAxis.Title + " Vs. " + objGraphCtrl.AldysPane.YAxis.Title;
										//commented by deepak on 24.08.07
										//objGraphCtrl.AldysPane.Title = strGraphTitle
										objGraphCtrl.AldysPane.Title = strGraphTitle;
										objGraphCtrl.DrawGraphOnGraphics(G, (int)rectGraph(ObjIndex).X, (int)rectGraph(ObjIndex).Y, (int)rectGraph(ObjIndex).Width, (int)rectGraph(ObjIndex).Height);
										objGraphCtrl.AldysPane.Title = "";
									}
									//objGraphCtrl.Dispose()
									objGraphCtrl = null;

									//--- Draw Color Space Diagram
									//If Not IsNothing(objSpaceGraphCtrl) = True Then
									//    If objSpaceGraphCtrl.AldysPane.IsDCDH = True Then
									//        strGraphTitle = " DC/DH Plot "
									//    Else
									//        strGraphTitle = " DA/DB Plot "
									//    End If
									//    If objSpaceGraphCtrl.AldysPane.IsLABCH = True Then
									//        strGraphTitle = " LABCH Plot "
									//    End If
									//    objSpaceGraphCtrl.AldysPane.Title = strGraphTitle
									//    objSpaceGraphCtrl.DrawGraphOnGraphics(G, CInt(rectGraph(ObjIndex).X), CInt(rectGraph(ObjIndex).Y), CInt(rectGraph(ObjIndex).Width), CInt(rectGraph(ObjIndex).Height))
									//    objSpaceGraphCtrl.AldysPane.Title = ""
									//End If
									//'objSpaceGraphCtrl.Dispose()
									//objSpaceGraphCtrl = Nothing
									//=====================================================================
								}

								ObjIndex = ObjIndex + 1;

								if (CheckForUnEvenObjects == true) {
									if (unEvenObjectsCounter == unEvenObjectsCount) {
										break; // TODO: might not be correct. Was : Exit For
									}
								}
							}

						}

				}

			}

			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
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

	#Region "CookBook Procedure"
	private bool funcElamentInfo(ref PrintPageEventArgs EV, float sngXPositionIn, ref float sngYPositionIn)
	{
		//=====================================================================
		// Procedure Name        : funcElamentInfo
		// Parameters Passed     : 
		// Returns               : true or false
		// Purpose               : To show the Elament Information on the report
		// Description           : 
		//
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Tuesday, Octomber 10, 2006
		// Revisions             : 
		//=====================================================================



		Drawing.Brush objBrush;
		bool SetStringBold;
		static bool intIsPageReapate;
		Drawing.RectangleF rectReportHeader;
		Font ReportHeaderFont;
		string strELE_Abriv;
		string strELE_Name;


		try {
			//    '//----- Added by Sachin Dokhale on 28.09.05
			//    mintPageFooterYPosotion = CInt(PageFooterLineY1)
			////-----
			//System.Drawing.Printing.PageSettings()
			DataDynamics.ActiveReports.ActiveReport objARLayoutReport;

			objARLayoutReport = mobjARPortrateReport;
			objBrush = new Pen(mobjReportBrushBlack.Color).Brush;
			//objBrush = New Pen(mobjReportBrushRed.Color).Brush


			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblElement")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblElement")).Font;
			strELE_Name = (string)objDtCookBookInfoRpt.Rows.Item(0).Item("NAME") + " " + (string)objDtCookBookInfoRpt.Rows.Item(0).Item("ELE_NAME");

			//rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
			sngXPositionIn = rectReportHeader.X * 100;
			rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn;
			rectReportHeader.Y = rectReportHeader.Y * 96 + sngYPositionIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = (rectReportHeader.Width * 72) * strELE_Name.Length;
			//rectReportHeader.Width * 96 
			EV.Graphics.DrawString(strELE_Name, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			strELE_Name = "At. Wt.      " + (string)Format(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"), "#0.000");

			//sngYPositionIn += rectReportHeader.Height + (lineSpacing + printFont.GetHeight(EV.Graphics))

			//rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
			rectReportHeader.X = (objARLayoutReport.PageSettings.PaperWidth * 100) - ((Len(strELE_Name) * (ReportHeaderFont.SizeInPoints)) + 30);
			rectReportHeader.Y = sngYPositionIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			EV.Graphics.DrawString(strELE_Name, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
			sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));
			blnFinishElamentInfo = true;
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			//If Not cWait Is Nothing Then
			//cWait.Dispose()
			//End If
		}
	}

	private bool funcStdSolutionTech(ref PrintPageEventArgs EV, float sngXPositionIn, ref float sngYPositionIn)
	{
		//=====================================================================
		// Procedure Name        : funcStdSolutionTech
		// Parameters Passed     : 
		// Returns               : true or false
		// Purpose               : To show the Elament Information on the report
		// Description           : 
		//
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Tuesday, Octomber 10, 2006
		// Revisions             : 
		//=====================================================================
		Drawing.Brush objBrush;
		bool SetStringBold;
		static bool intIsPageReapate;
		Drawing.RectangleF rectReportHeader;
		Font ReportHeaderFont;
		string strELE_Abriv;
		string strPrintText;
		char chrSplitChar;
		string[] arrPrintTestList;
		int intArrIndex;
		bool blnSetIsSetYPosition = false;
		const string ConstHeader1 = "PREPARATION OF STANDARD SOLUTION";
		const string ConstSubHeader1 = "Recommended Standard Materials";
		const string ConstSubHeader2 = "Solution Technique";

		try {
			DataDynamics.ActiveReports.ActiveReport objARLayoutReport;

			objARLayoutReport = mobjARPortrateReport;

			////---- Header 1
			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader1")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader1")).Font;
			strPrintText = ConstHeader1;
			objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

			//strELE_Name = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("NAME")) & " " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ELE_NAME"))
			//rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
			sngXPositionIn = rectReportHeader.X * 100;
			rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn;
			rectReportHeader.Y = rectReportHeader.Y * 50 + sngYPositionIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;

			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- Header 2
			//strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
			sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10;
			//rectReportHeader.Height 

			// Nothing Then
			if (!IsDBNull(objDtCookBookInfoRpt.Rows.Item(0).Item("STD_METRL")) == true) {

				if (!(string)objDtCookBookInfoRpt.Rows.Item(0).Item("STD_METRL") == "") {
					rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
					ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

					strPrintText = ConstSubHeader1;
					rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn;
					rectReportHeader.Y = sngYPositionIn;
					sngXPositionIn = rectReportHeader.X;
					rectReportHeader.Height = rectReportHeader.Height * 96;
					rectReportHeader.Width = rectReportHeader.Width * 96;
					//sngYPositionIn += rectReportHeader.Height
					EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

					sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10;

					//sngYPositionIn += rectReportHeader.Height + +(lineSpacing + printFont.GetHeight(EV.Graphics))

					//rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).GetBounds
					//ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font
					//sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics))

					strPrintText = (string)objDtCookBookInfoRpt.Rows.Item(0).Item("STD_METRL");

					chrSplitChar = (char)";";
					arrPrintTestList = strPrintText.Split(chrSplitChar);
					rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
					ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;
					sngYPositionIn += rectReportHeader.Y;

					for (intArrIndex = 0; intArrIndex <= UBound(arrPrintTestList); intArrIndex++) {
						strPrintText = Trim(arrPrintTestList(intArrIndex));
						rectReportHeader.Y = sngYPositionIn;
						//rectReportHeader.Y = sngYPositionIn
						rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn;
						//rectReportHeader.Y = sngYPositionIn
						rectReportHeader.Height = rectReportHeader.Height * 60;
						rectReportHeader.Width = rectReportHeader.Width * 96;
						EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
						sngYPositionIn += lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics);
						rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
						ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;
					}

					////---- Header 2 "Solution Technique

					sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics));
					//rectReportHeader.Height 
					blnSetIsSetYPosition = true;
					//strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
				}
			}


			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;


			if (!IsDBNull(objDtCookBookInfoRpt.Rows.Item(0).Item("SOLN_TECH")) == true) {
				if (!(string)objDtCookBookInfoRpt.Rows.Item(0).Item("SOLN_TECH") == "") {
					if (blnSetIsSetYPosition == false) {
						sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics));
						//rectReportHeader.Height 
					}
					strPrintText = ConstSubHeader2;

					sngXPositionIn = rectReportHeader.X * 100;

					rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn;
					rectReportHeader.Y = sngYPositionIn;
					sngXPositionIn = rectReportHeader.X;
					rectReportHeader.Height = rectReportHeader.Height * 96;
					rectReportHeader.Width = rectReportHeader.Width * 96;
					//sngYPositionIn += rectReportHeader.Height
					EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

					sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10;

					////----- 

					strPrintText = (string)objDtCookBookInfoRpt.Rows.Item(0).Item("SOLN_TECH");



					//arrPrintTestList = strPrintText.Split(chrSplitChar)
					rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
					ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;
					sngYPositionIn += rectReportHeader.Y;

					//For intArrIndex = 0 To UBound(arrPrintTestList)
					//strPrintText = Trim(arrPrintTestList(intArrIndex))
					rectReportHeader.Y = sngYPositionIn;
					//rectReportHeader.Y = sngYPositionIn
					rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn;
					//rectReportHeader.Y = sngYPositionIn
					rectReportHeader.Height = rectReportHeader.Height * 120;
					//60  '27.10.09
					rectReportHeader.Width = rectReportHeader.Width * 102;
					//96 '27.10.09
					EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

					sngYPositionIn += lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics);
				}
			}
			blnFinishStdSolutionTech = true;

			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			//If Not cWait Is Nothing Then
			//cWait.Dispose()
			//End If
		}
	}

	private bool funcWorkingConditionFixed(ref PrintPageEventArgs EV, float sngXPositionIn, ref float sngYPositionIn)
	{
		//=====================================================================
		// Procedure Name        : funcWorkingConditionFixed
		// Parameters Passed     : 
		// Returns               : true or false
		// Purpose               : To show the Elament Information on the report
		// Description           : 
		//
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Tuesday, Octomber 10, 2006
		// Revisions             : 
		//=====================================================================
		Drawing.Brush objBrush;
		bool SetStringBold;
		static bool intIsPageReapate;
		Drawing.RectangleF rectReportHeader;
		Font ReportHeaderFont;
		string strELE_Abriv;
		string strPrintText;
		const string ConstHeader1 = "RECOMMENDED INSTRUMENT PARAMETERS";
		const string ConstSubHeader1 = "Atomic Absorption";
		const string ConstSubHeader2 = "Working Conditions (fixed)";
		const string ConstSubHeader3 = "Lamp Current";
		const string ConstSubHeader4 = "Fuel";
		const string ConstSubHeader5 = "Support";
		const string ConstSubHeader6 = "Flame Stoichiometry";
		const string ConstSubHeader7 = "Working Conditions (variable)";
		try {
			DataDynamics.ActiveReports.ActiveReport objARLayoutReport;
			objARLayoutReport = mobjARPortrateReport;

			////---- Header 1
			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader1")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader1")).Font;
			strPrintText = ConstHeader1;
			objBrush = new Pen(mobjReportBrushBlack.Color).Brush;
			//objBrush = New Pen(mobjReportBrushRed.Color).Brush

			//strELE_Name = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("NAME")) & " " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ELE_NAME"))
			//rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
			sngXPositionIn = rectReportHeader.X * 100;
			rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn;
			rectReportHeader.Y = rectReportHeader.Y * 60 + sngYPositionIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;

			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- sub Header 1
			//strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
			sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15;
			//rectReportHeader.Height 

			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

			strPrintText = ConstSubHeader1;
			rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn;
			rectReportHeader.Y = sngYPositionIn;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			//sngYPositionIn += rectReportHeader.Height
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- sub Header 2
			//strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
			//sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
			sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15;
			//rectReportHeader.Height 
			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

			strPrintText = ConstSubHeader2;
			rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn + 5;
			rectReportHeader.Y = sngYPositionIn;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			//sngYPositionIn += rectReportHeader.Height
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- sub Header 3
			//strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
			//sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
			sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15;
			//rectReportHeader.Height 


			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

			strPrintText = ConstSubHeader3;
			//sngXPositionIn = rectReportHeader.X * 100
			//rectReportHeader.X = sngXPositionIn 'rectReportHeader.X * 96 + sngXPositionIn + 5
			rectReportHeader.X = rectReportHeader.X * 96 + 66;
			rectReportHeader.Y = sngYPositionIn;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			//sngYPositionIn += rectReportHeader.Height
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- detals 1
			strPrintText = (string)Format(objDtCookBookInfoRpt.Rows.Item(0).Item("CURRENT"), "#0.0") + " mA";

			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;
			rectReportHeader.X = rectReportHeader.X * 96 + 300;
			//rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
			rectReportHeader.Y = sngYPositionIn + (float)0.5;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- sub Header 3
			//strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
			//sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
			sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15;
			//rectReportHeader.Height 

			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

			strPrintText = ConstSubHeader4;
			//sngXPositionIn = rectReportHeader.X * 100
			//rectReportHeader.X = sngXPositionIn 'rectReportHeader.X * 96 + sngXPositionIn + 5
			rectReportHeader.X = rectReportHeader.X * 96 + 66;
			rectReportHeader.Y = sngYPositionIn;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			//sngYPositionIn += rectReportHeader.Height
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- detals 2
			if ((bool)objDtCookBookInfoRpt.Rows.Item(0).Item("FUEL") == false) {
				strPrintText = "Acetylene";
			} else {
				strPrintText = "None";
				//CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUEL"))
			}


			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;
			//rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn + 200
			rectReportHeader.X = rectReportHeader.X * 96 + 300;
			rectReportHeader.Y = sngYPositionIn + (float)0.5;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- sub Header 3
			//strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
			//sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
			sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15;
			//rectReportHeader.Height 

			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

			strPrintText = ConstSubHeader5;
			//sngXPositionIn = rectReportHeader.X * 100
			//rectReportHeader.X = sngXPositionIn 'rectReportHeader.X * 96 + sngXPositionIn + 5
			rectReportHeader.X = rectReportHeader.X * 96 + 66;
			rectReportHeader.Y = sngYPositionIn;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			//sngYPositionIn += rectReportHeader.Height
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- detals 3
			//strPrintText = ConstSubHeader4
			if ((bool)objDtCookBookInfoRpt.Rows.Item(0).Item("SUPPORT") == false) {
				strPrintText = "Air";
			} else {
				strPrintText = "Nitrous Oxide";
				//CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUEL"))
			}

			//strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("SUPPORT"))

			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;
			rectReportHeader.X = rectReportHeader.X * 96 + 300;
			//rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
			rectReportHeader.Y = sngYPositionIn + (float)0.5;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- sub Header 3
			//strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
			//sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
			sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15;
			//rectReportHeader.Height 

			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

			strPrintText = ConstSubHeader6;
			//sngXPositionIn = rectReportHeader.X * 100
			//rectReportHeader.X = sngXPositionIn 'rectReportHeader.X * 96 + sngXPositionIn + 5
			rectReportHeader.X = rectReportHeader.X * 96 + 66;
			rectReportHeader.Y = sngYPositionIn;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			//sngYPositionIn += rectReportHeader.Height
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			////---- detals 4
			//strPrintText = ConstSubHeader4
			strPrintText = (string)objDtCookBookInfoRpt.Rows.Item(0).Item("FLAME_STO");
			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;
			rectReportHeader.X = rectReportHeader.X * 96 + 300;
			//rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn
			rectReportHeader.Y = sngYPositionIn + (float)0.5;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 128;
			//96 ''27.10.09
			rectReportHeader.Width = rectReportHeader.Width * 96;
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			//sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics))    'rectReportHeader.Height 
			blnFinishWorkingConditionFixed = true;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			//If Not cWait Is Nothing Then
			//cWait.Dispose()
			//End If
		}
	}

	private bool funcWorkingConditionVariable(ref PrintPageEventArgs EV, float sngXPositionIn, ref float sngYPositionIn, float sngLeftMarginIn)
	{
		//=====================================================================
		// Procedure Name        : funcWorkingConditionVariable
		// Parameters Passed     : 
		// Returns               : true or false
		// Purpose               : To show the Elament Information on the report
		// Description           : 
		//
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Tuesday, Octomber 10, 2006
		// Revisions             : 
		//=====================================================================
		Drawing.Brush objBrush;
		bool SetStringBold;
		static bool intIsPageReapate;
		Drawing.RectangleF rectReportHeader;
		Font ReportHeaderFont;
		string strELE_Abriv;
		string strPrintText;
		//Const ConstHeader1 As String = "RECOMMENDED INSTRUMENT PARAMETERS"
		//Const ConstSubHeader1 As String = "Atomic Absorption"
		const string ConstSubHeader1 = "Working Conditions (variable)";
		const string ConstSubHeader2 = "Notes ";


		try {
			DataDynamics.ActiveReports.ActiveReport objARLayoutReport;
			objARLayoutReport = mobjARPortrateReport;

			////---- sub Header 2
			//strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
			//sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
			//sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15    'rectReportHeader.Height 
			objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

			strPrintText = ConstSubHeader1;
			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;


			sngXPositionIn = rectReportHeader.X * 100;
			rectReportHeader.X = rectReportHeader.X * 96 + (sngXPositionIn * 2);

			sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10;
			//rectReportHeader.Height 

			//rectReportHeader.X = rectReportHeader.X * 96 + 5
			rectReportHeader.Y = sngYPositionIn;
			sngXPositionIn = rectReportHeader.X;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			//sngYPositionIn += rectReportHeader.Height
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			sngYPositionIn += lineSpacing + printFont.GetHeight(EV.Graphics) + 10;

			//---5.Draw the Grid Tables from DataTable
			if (EV.HasMorePages == false) {
				funcDrawGridTables(EV, sngYPositionIn, sngLeftMarginIn);
			}


			if (!(IsDBNull(objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_AA")) == true)) {
				if (!((string)objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_AA") == "")) {
					strPrintText = ConstSubHeader2;
					float sngSubHeaderWidth;
					rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
					ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

					sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10;
					//rectReportHeader.Height 
					rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn;
					//rectReportHeader.X = rectReportHeader.X * 96 + 5
					rectReportHeader.Y = sngYPositionIn;
					sngXPositionIn = rectReportHeader.X;
					rectReportHeader.Height = rectReportHeader.Height * 96;
					rectReportHeader.Width = rectReportHeader.Width * 96;
					sngSubHeaderWidth = ReportHeaderFont.Size * strPrintText.Length * 72;
					// (EV.Graphics)'(EV.Graphics))    'rectReportHeader.Width

					//sngYPositionIn += rectReportHeader.Height
					EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

					strPrintText = (string)objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_AA");

					rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
					ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;

					//sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
					rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn + 30;
					//rectReportHeader.X = rectReportHeader.X * 96 + 5
					rectReportHeader.Y = sngYPositionIn;
					sngXPositionIn = rectReportHeader.X;
					rectReportHeader.Height = rectReportHeader.Height * 96;
					rectReportHeader.Width = rectReportHeader.Width * 96;
					sngYPositionIn += rectReportHeader.Height;
					EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
				}
			}
			//sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
			blnFinishWorkingConditionVariable = true;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			//If Not cWait Is Nothing Then
			//cWait.Dispose()
			//End If
		}
	}

	private bool funcFlameEmission(ref PrintPageEventArgs EV, float sngXPositionIn, ref float sngYPositionIn)
	{
		//=====================================================================
		// Procedure Name        : funcFlameEmission
		// Parameters Passed     : 
		// Returns               : true or false
		// Purpose               : To show the Elament Information on the report
		// Description           : 
		//
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Tuesday, Octomber 10, 2006
		// Revisions             : 
		//=====================================================================
		Drawing.Brush objBrush;
		bool SetStringBold;
		static bool blnIsPageReapate;
		Drawing.RectangleF rectReportHeader;
		Font ReportHeaderFont;
		string strELE_Abriv;
		string strPrintText;
		//Dim divPen As Pen
		Pen divPen = new Pen(Color.Black);
		//mobjReportDataGrid.GridLineColor)
		Pen hfpen = new Pen(Color.Black);
		//mobjReportDataGrid.HeaderForeColor)
		const string ConstSubHeader1 = "Flame Emission";
		const string ConstSubHeader2 = "Notes ";
		const string ConstSubHeader3 = "Wavelength";
		const string ConstSubHeader4 = "Bandwidth";
		const string ConstSubHeader5 = "Fuel";
		const string ConstSubHeader6 = "Support";

		float sngFlameBoxHeight;
		Drawing.Region lineFlameEmi;
		float leftMargin;
		//= rectGrid.Left
		float topMargin;
		//= rectGrid.Top

		int w;
		int l;
		//Dim hfpen As New Pen(Color.Black)   'mobjReportDataGrid.HeaderForeColor)
		SolidBrush hbBrush = new SolidBrush(Color.White);
		//mobjReportDataGrid.HeaderBackColor)
		SolidBrush hfBrush = new SolidBrush(Color.Black);
		//mobjReportDataGrid.HeaderForeColor)
		SizeF CellSize;
		float sngFrameBottomYPosition;
		float sngXEMSPosition;
		float sngLastWordLen;
		try {

			if (IsDBNull(objDtCookBookInfoRpt.Rows.Item(0).Item("WVEMS")) == true) {
				blnFinishFlameEmission = true;
				blnFinishFlameEmissionNotes = true;
				return true;
			}
			if ((string)objDtCookBookInfoRpt.Rows.Item(0).Item("WVEMS") == "0") {
				blnFinishFlameEmission = true;
				blnFinishFlameEmissionNotes = true;
				return true;
			}
			DataDynamics.ActiveReports.ActiveReport objARLayoutReport;
			objARLayoutReport = mobjARPortrateReport;
			rectReportHeader = ((DataDynamics.ActiveReports.Shape)objARLayoutReport.Sections("Detail").Controls("FlameShape")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;


			if (blnFinishFlameEmission == false) {

				sngFlameBoxHeight = sngYPositionIn + (rectReportHeader.Height * 72) + ((lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) * 2) + 10;


				if (sngFlameBoxHeight >= mintPageFooterYPosotion) {
					if (blnIsPageReapate == true) {
						if (blnPageSettingMessage == false) {
							//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
							Application.DoEvents();
							//cWait = New CWaitCursor
						}

						EV.HasMorePages = false;
						EV.Cancel = true;
						blnFinishFlameEmission = true;
						return false;
						//Exit Function
					}

					EV.HasMorePages = true;
					blnIsPageReapate = true;
					blnFinishFlameEmission = false;
					return true;
				//Exit Function

				} else if (sngYPositionIn >= mintPageFooterYPosotion) {
					if (blnIsPageReapate == true) {
						if (blnPageSettingMessage == false) {
							//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
							Application.DoEvents();
							//cWait = New CWaitCursor
						}

						EV.HasMorePages = false;
						EV.Cancel = true;
						blnFinishFlameEmission = true;
						//Exit Function
						return true;

					}

					EV.HasMorePages = true;
					blnIsPageReapate = true;
					blnFinishFlameEmission = false;
					return true;
					//Exit Function
				}

				strPrintText = ConstSubHeader1;
				objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

				rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
				ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

				//sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
				sngXPositionIn = rectReportHeader.X * 96 + sngXPositionIn + 5;

				rectReportHeader.X = sngXPositionIn + 10;
				//rectReportHeader.X * 96 + sngXPositionIn + 5
				//rectReportHeader.X = rectReportHeader.X * 96 + 5
				rectReportHeader.Y = sngYPositionIn;

				//sngXPositionIn = rectReportHeader.X
				rectReportHeader.Height = rectReportHeader.Height * 96;
				rectReportHeader.Width = rectReportHeader.Width * 96;
				//sngYPositionIn += rectReportHeader.Height
				EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
				sngYPositionIn += rectReportHeader.Height;

				////////////---------------------




				sngXPositionIn = 50;
				CellSize.Width = ((DataDynamics.ActiveReports.Shape)objARLayoutReport.Sections("Detail").Controls("FlameShape")).Width * 96;
				CellSize.Height = ((DataDynamics.ActiveReports.Shape)objARLayoutReport.Sections("Detail").Controls("FlameShape")).Height * 96;
				l = (int)sngYPositionIn;
				//CInt(CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).Left)
				w = (int)sngXPositionIn;
				//CInt(CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).Width)

				Rectangle r = new Rectangle(new Point(w, l), CellSize.ToSize);

				Drawing.RectangleF rf = new Drawing.RectangleF(w, l, r.Width, r.Height);
				EV.Graphics.DrawLine(divPen, r.X, r.Y, r.Right, r.Y);
				EV.Graphics.DrawLine(divPen, r.X, r.Bottom, r.Right, r.Y + r.Height);
				//EV.Graphics.DrawLine(New Pen(Color.Black), r.X, r.Y, r.X, r.Y + r.Height)
				//EV.Graphics.DrawLine(New Pen(Color.Black), r.Width + r.X, r.Y, r.Width + r.X, r.Y + r.Height)
				EV.Graphics.DrawLine(divPen, r.X, r.Y, r.X, r.Y + r.Height);
				EV.Graphics.DrawLine(divPen, r.Width + r.X, r.Y, r.Width + r.X, r.Y + r.Height);
				////----- Calulate Frame Bottom Y position
				sngFrameBottomYPosition = r.Y + r.Height;

				////---- sub Header 2
				//strELE_Name = "At. Wt.      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ATWT"))
				//sngYPositionIn += rectReportHeader.Height + (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15   'rectReportHeader.Height 
				//sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 15    'rectReportHeader.Height 



				//rectFlameEmi(0) = CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).GetBounds
				//rectFlameEmi(0).Y = sngYPositionIn

				//EV.Graphics.DrawRectangles(New Pen(objBrush, 2.5), rectFlameEmi)
				//EV.Graphics.DrawLine(New Pen(objBrush, 2.5))



				//rectReportReactangle = CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Shape).GetBounds
				//ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font
				//CType(objARLayoutReport.Sections("Detail").Controls("FlameShape"), DataDynamics.ActiveReports.Line).Draw()


				//ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("lblHeader2"), DataDynamics.ActiveReports.Label).Font

				sngXEMSPosition = sngXPositionIn;
				////----- Wavelength
				strPrintText = ConstSubHeader3;
				objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

				rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
				ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

				sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics));
				//rectReportHeader.Height 
				rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 5;
				sngXPositionIn = rectReportHeader.X;
				//rectReportHeader.X = rectReportHeader.X * 96 + 5
				rectReportHeader.Y = sngYPositionIn;
				//- 5
				sngXEMSPosition = rectReportHeader.X;
				rectReportHeader.Height = rectReportHeader.Height * 96;
				//rectReportHeader.Width = (ReportHeaderFont.GetHeight(EV.Graphics)) 'rectReportHeader.Width * 96
				rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size);
				//sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)
				sngLastWordLen = 112.5;
				//sngYPositionIn += rectReportHeader.Height
				EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
				//sngYPositionIn += rectReportHeader.Height
				sngYPositionIn = rectReportHeader.Y;

				////-------Text

				//strPrintText = ""
				//Else
				strPrintText = (string)Format(objDtCookBookInfoRpt.Rows.Item(0).Item("WVEMS"), "#0.00") + " nm";
				objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

				rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
				ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;

				//sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
				rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 100;
				//rectReportHeader.X = rectReportHeader.X * 96 + 5
				rectReportHeader.Y = sngYPositionIn;
				//- 5
				//sngXEMSPosition = rectReportHeader.X
				rectReportHeader.Height = rectReportHeader.Height * 96;
				//rectReportHeader.Width = (ReportHeaderFont.GetHeight(EV.Graphics)) 'rectReportHeader.Width * 96
				rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size);
				//sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)
				//sngYPositionIn += rectReportHeader.Height
				EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
				//sngYPositionIn += rectReportHeader.Height
				//sngYPositionIn = rectReportHeader.Y

				////----- Bandwidth
				strPrintText = ConstSubHeader4;
				objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

				rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
				ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

				//sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
				//sngXPositionIn = rectReportHeader.X * 96 + sngXPositionIn + 5
				rectReportHeader.X = sngXEMSPosition + sngLastWordLen + 250;
				rectReportHeader.Y = sngYPositionIn;
				//sngXPositionIn = rectReportHeader.X
				rectReportHeader.Height = rectReportHeader.Height * 96;
				//rectReportHeader.Width = rectReportHeader.Width * 96
				rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size);
				//sngYPositionIn += rectReportHeader.Height
				EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
				sngXEMSPosition = rectReportHeader.X;
				sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size);

				////-------Text
				if (!(string)objDtCookBookInfoRpt.Rows.Item(0).Item("SLITEMS") == "0") {
					strPrintText = (string)Format(objDtCookBookInfoRpt.Rows.Item(0).Item("SLITEMS"), "0.0") + " nm.";

					objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

					rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
					ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;

					//sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
					//rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 30
					rectReportHeader.X = sngXEMSPosition + sngLastWordLen + 90;
					rectReportHeader.Y = sngYPositionIn;
					//- 5
					//sngXEMSPosition = rectReportHeader.X
					rectReportHeader.Height = rectReportHeader.Height * 96;
					//rectReportHeader.Width = (ReportHeaderFont.GetHeight(EV.Graphics)) 'rectReportHeader.Width * 96
					rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size);
					//sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)
					//sngYPositionIn += rectReportHeader.Height
					EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
					//sngYPositionIn += rectReportHeader.Height
					//sngYPositionIn = rectReportHeader.Y
				}

				sngYPositionIn += lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics));

				////----- Fuel
				strPrintText = ConstSubHeader5;

				objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

				rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
				ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

				sngXEMSPosition = sngXPositionIn;
				sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics));
				//rectReportHeader.Height 
				rectReportHeader.X = sngXEMSPosition;
				//rectReportHeader.X * 96 + sngXPositionIn + 5
				//rectReportHeader.X = rectReportHeader.X * 96 + 5
				rectReportHeader.Y = sngYPositionIn;
				//- 5
				//sngXEMSPosition = rectReportHeader.X
				rectReportHeader.Height = rectReportHeader.Height * 96;
				rectReportHeader.Width = rectReportHeader.Width * 96;
				//sngYPositionIn += rectReportHeader.Height
				EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
				sngYPositionIn = rectReportHeader.Y;
				////------------
				//strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS"))
				if ((bool)objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS") == false) {
					strPrintText = "Acetylene";
					//CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS"))
				} else {
					strPrintText = "None";
					//strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS"))
				}


				objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

				rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
				ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;

				//sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
				rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 100;
				//rectReportHeader.X = rectReportHeader.X * 96 + 5
				rectReportHeader.Y = sngYPositionIn;
				//- 5
				//sngXEMSPosition = rectReportHeader.X
				rectReportHeader.Height = rectReportHeader.Height * 96;
				//rectReportHeader.Width = (ReportHeaderFont.GetHeight(EV.Graphics)) 'rectReportHeader.Width * 96
				rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size);
				//sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)
				//sngYPositionIn += rectReportHeader.Height
				EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

				////----- Support
				strPrintText = ConstSubHeader6;
				objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

				rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
				ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

				//sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
				//sngXPositionIn = rectReportHeader.X * 96 + sngXPositionIn + 5
				rectReportHeader.X = sngXEMSPosition + sngLastWordLen + 260;
				//rectReportHeader.X = rectReportHeader.X * 96 + 5
				rectReportHeader.Y = sngYPositionIn;
				//sngXPositionIn = rectReportHeader.X
				rectReportHeader.Height = rectReportHeader.Height * 96;
				//rectReportHeader.Width = rectReportHeader.Width * 96
				rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size);
				//sngYPositionIn += rectReportHeader.Height
				EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
				sngXEMSPosition = rectReportHeader.X;

				//sngYPositionIn += rectReportHeader.Height
				////-------Text

				//strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("SUPPORTEMS"))
				if ((bool)objDtCookBookInfoRpt.Rows.Item(0).Item("SUPPORTEMS") == false) {
					strPrintText = "Air";
					//CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS"))
				} else {
					strPrintText = "Nitrous Oxide";
					//strPrintText = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("FUELEMS"))
				}

				objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

				rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
				ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;

				//sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
				//rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 30
				rectReportHeader.X = sngXEMSPosition + sngLastWordLen + 90;
				rectReportHeader.Y = sngYPositionIn;
				//- 5
				//sngXEMSPosition = rectReportHeader.X
				rectReportHeader.Height = rectReportHeader.Height * 96;
				//rectReportHeader.Width = (ReportHeaderFont.GetHeight(EV.Graphics)) 'rectReportHeader.Width * 96
				rectReportHeader.Width = strPrintText.Length * (ReportHeaderFont.Size);
				//sngLastWordLen = strPrintText.Length * (ReportHeaderFont.Size)
				//sngYPositionIn += rectReportHeader.Height
				EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
				//sngYPositionIn += rectReportHeader.Height
				//sngYPositionIn = rectReportHeader.Y
				//End If
				sngYPositionIn += lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics));

				sngXEMSPosition = sngXPositionIn;
				sngYPositionIn = sngFlameBoxHeight;

			} else {
				//sngYPositionIn = sngFlameBoxHeight
			}

			if ((sngFrameBottomYPosition + lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics))) >= mintPageFooterYPosotion) {
				EV.HasMorePages = true;
				blnIsPageReapate = true;

				blnFinishFlameEmission = true;
				blnFinishFlameEmissionNotes = false;
				return true;
			}

			bool blnCheckFlameEmissionNotes;
			blnCheckFlameEmissionNotes = IsDBNull(objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_EMS"));

			//If (objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_EMS")) IsDBNull Then
			if (blnCheckFlameEmissionNotes == true) {
				blnFinishFlameEmissionNotes = true;
				return true;
			}


			if (!((string)objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_EMS") == "")) {

				strPrintText = ConstSubHeader2;
				float sngSubHeaderWidth;
				rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
				ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;
				objBrush = new Pen(mobjReportBrushBlack.Color).Brush;
				if (blnFinishFlameEmission == true & blnFinishFlameEmissionNotes == false) {
					//sngYPositionIn += sngYPositionIn
					sngYPositionIn += sngFrameBottomYPosition + lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics));
					//sngXPositionIn = rectReportHeader.X * 100
					sngXEMSPosition = 15;
				} else {
					sngYPositionIn = sngFrameBottomYPosition + lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics));
				}
				//sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 

				rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition;

				//rectReportHeader.X = rectReportHeader.X * 96 + 5
				rectReportHeader.Y = sngYPositionIn;
				sngXEMSPosition = rectReportHeader.X;
				rectReportHeader.Height = rectReportHeader.Height * 96;
				rectReportHeader.Width = rectReportHeader.Width * 96;
				sngSubHeaderWidth = ReportHeaderFont.Size * strPrintText.Length * 72;
				// (EV.Graphics)'(EV.Graphics))    'rectReportHeader.Width

				//sngYPositionIn += rectReportHeader.Height
				EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

				strPrintText = (string)objDtCookBookInfoRpt.Rows.Item(0).Item("NOTES_EMS");

				rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
				ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;

				//sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
				rectReportHeader.X = rectReportHeader.X * 96 + sngXEMSPosition + 30;
				//rectReportHeader.X = rectReportHeader.X * 96 + 5
				rectReportHeader.Y = sngYPositionIn;
				sngXPositionIn = rectReportHeader.X;
				rectReportHeader.Height = rectReportHeader.Height * 96;
				rectReportHeader.Width = rectReportHeader.Width * 96;
				sngYPositionIn += rectReportHeader.Height;
				EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
				blnFinishFlameEmissionNotes = true;
			} else {
				blnFinishFlameEmissionNotes = true;
			}
			////--------------
			//sngYPositionIn = sngFlameBoxHeight
			blnFinishFlameEmission = true;
			return true;
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			//If Not cWait Is Nothing Then
			//cWait.Dispose()
			//End If
		}
	}

	private bool funcInterference(ref PrintPageEventArgs EV, float sngXPositionIn, ref float sngYPositionIn)
	{
		//=====================================================================
		// Procedure Name        : ArrangeGraphsInGrid
		// Parameters Passed     : 
		// Returns               : true or false
		// Purpose               : To show the Elament Information on the report
		// Description           : 
		//
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Tuesday, Octomber 10, 2006
		// Revisions             : 
		//=====================================================================

		Drawing.Brush objBrush;
		bool SetStringBold;
		static bool blnIsPageReapate;
		Drawing.RectangleF rectReportHeader;
		Font ReportHeaderFont;

		string strPrintText;
		//Dim divPen As Pen


		const string ConstSubHeader1 = "Interferance";

		float sngYPosInterference;

		try {
			if (sngYPositionIn >= mintPageFooterYPosotion) {
				if (blnIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						//Application.DoEvents()
						//cWait = New CWaitCursor
					}

					EV.HasMorePages = false;
					EV.Cancel = true;
					return;
				}

				EV.HasMorePages = true;
				blnIsPageReapate = true;
				return;
			}

			DataDynamics.ActiveReports.ActiveReport objARLayoutReport;
			objARLayoutReport = mobjARPortrateReport;
			strPrintText = (string)objDtCookBookInfoRpt.Rows.Item(0).Item("INTERFEREN");
			//objBrush = New Pen(mobjReportBrushBlack.Color).Brush

			//rectReportHeader = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).GetBounds
			//ReportHeaderFont = CType(objARLayoutReport.Sections("Detail").Controls("Label1"), DataDynamics.ActiveReports.Label).Font

			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;

			//sngYPositionIn += (ReportHeaderFont.GetHeight(EV.Graphics))      'rectReportHeader.Height 
			//sngYPosInterference = sngYPositionIn + lineSpacing + ((ReportHeaderFont.GetHeight(EV.Graphics)) * 4)      'rectReportHeader.Height 
			sngYPosInterference = sngYPositionIn + lineSpacing + (ReportHeaderFont.GetHeight(EV.Graphics)) + 10;

			//sngYPosInterference = sngYPositionIn + lineSpacing + ((rectReportHeader.Height) * 4)       'rectReportHeader.Height 


			sngYPosInterference += ((strPrintText.Length) * ReportHeaderFont.Size) / (rectReportHeader.Width * (ReportHeaderFont.Size - 2)) + 10;
			sngYPosInterference += (ReportHeaderFont.GetHeight(EV.Graphics));
			//rectReportHeader.X = rectReportHeader.X * 96 + sngXPositionIn + 5
			//rectReportHeader.X = rectReportHeader.X * 96 + 5
			//rectReportHeader.Y = sngYPositionIn - 5
			//sngXPositionIn = rectReportHeader.X
			//rectReportHeader.Height = rectReportHeader.Height * 96

			if (sngYPosInterference >= mintPageFooterYPosotion) {
				if (blnIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						Application.DoEvents();
						//cWait = New CWaitCursor
					}

					EV.HasMorePages = false;
					EV.Cancel = true;
					blnFinishInterference = true;
					return false;
					//Exit Function
				}

				EV.HasMorePages = true;
				blnIsPageReapate = true;
				blnFinishInterference = false;
				return true;
			//Exit Function

			} else if (sngYPositionIn >= mintPageFooterYPosotion) {
				if (blnIsPageReapate == true) {
					if (blnPageSettingMessage == false) {
						//Call gobjMessageAdapter.ShowMessage(ConstPageSettingOutofRange)
						Application.DoEvents();
						//cWait = New CWaitCursor
					}

					EV.HasMorePages = false;
					EV.Cancel = true;
					blnFinishInterference = false;
					//Exit Function
					return true;

				}

				EV.HasMorePages = true;
				blnIsPageReapate = true;
				blnFinishInterference = false;
				return true;
				//Exit Function
			}

			strPrintText = ConstSubHeader1;
			objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblHeader2")).Font;

			sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10;
			//rectReportHeader.Height 
			sngXPositionIn = rectReportHeader.X * 96 + 5;
			rectReportHeader.X = sngXPositionIn + 10;
			//rectReportHeader.X * 96 + sngXPositionIn + 5
			//rectReportHeader.X = rectReportHeader.X * 96 + 5
			rectReportHeader.Y = sngYPositionIn;

			//sngXPositionIn = rectReportHeader.X
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;
			//sngYPositionIn += rectReportHeader.Height

			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			sngYPositionIn += rectReportHeader.Height;


			////----- Details

			strPrintText = (string)objDtCookBookInfoRpt.Rows.Item(0).Item("INTERFEREN");
			objBrush = new Pen(mobjReportBrushBlack.Color).Brush;

			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("Label1")).Font;

			//sngYPositionIn += (lineSpacing + ReportHeaderFont.GetHeight(EV.Graphics)) + 10    'rectReportHeader.Height 
			sngXPositionIn = rectReportHeader.X * 96 + sngXPositionIn + 5;
			rectReportHeader.X = sngXPositionIn + 10;
			//rectReportHeader.X * 96 + sngXPositionIn + 5
			//rectReportHeader.X = rectReportHeader.X * 96 + 5
			rectReportHeader.Y = sngYPositionIn;

			//sngXPositionIn = rectReportHeader.X

			//rectReportHeader.Height = rectReportHeader.Height * 96
			//RptHi = rectReportHeader.Height * 96
			rectReportHeader.Height = ((strPrintText.Length) * ReportHeaderFont.Size) / (rectReportHeader.Width * (ReportHeaderFont.Size - 2)) + 10;
			// * 96 
			rectReportHeader.Width = rectReportHeader.Width * 96;
			//sngYPositionIn += rectReportHeader.Height
			EV.Graphics.DrawString(strPrintText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());
			sngYPositionIn += rectReportHeader.Height;
			////-----


			blnFinishInterference = true;
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			return false;
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
			//If Not cWait Is Nothing Then
			//cWait.Dispose()
			//End If
		}
	}

	private bool funcGetCookBookStruct(ref DataTable DtmElamentInfo, DataTable DtElamentDetails)
	{

		//mElamentInfo.ElamentAbrivation = DtmElamentInfo.Rows.Item(0).Item(0)
		//mDtElamentDetails()


	}

	#End Region

	#Region "Data file Report Procedure"

	private bool funcDatafileElamentInfo(ref PrintPageEventArgs EV, float sngXPositionIn, ref float sngYPositionIn, int mintMethodID, int mintRunNo)
	{
		//=====================================================================
		// Procedure Name        : funcDatafileElamentInfo
		// Parameters Passed     : 
		// Returns               : true or false
		// Purpose               : To show the Quantitative Information on the report
		// Description           : 
		//
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin Dokhale
		// Created               : Sunday, Feb 25, 2007
		// Revisions             : 
		//=====================================================================



		Drawing.Brush objBrush;
		bool SetStringBold;
		static bool intIsPageReapate;
		Drawing.RectangleF rectReportHeader;
		Font ReportHeaderFont;
		string strELE_Abriv;
		string strELE_Name;
		const string Const_QuantitativeReportFor = "Quantitative Report for";
		const string Const_RunNO = "Rune No: ";
		const string Const_Analysed = "Analysed On :";

		string strText;

		try {
			//    '//----- Added by Sachin Dokhale on 28.09.05
			//    mintPageFooterYPosotion = CInt(PageFooterLineY1)
			////-----
			//System.Drawing.Printing.PageSettings()
			DataDynamics.ActiveReports.ActiveReport objARLayoutReport;


			objARLayoutReport = mobjARPortrateReport;
			objBrush = new Pen(mobjReportBrushBlack.Color).Brush;
			//objBrush = New Pen(mobjReportBrushRed.Color).Brush


			rectReportHeader = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblElement")).GetBounds;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)objARLayoutReport.Sections("Detail").Controls("lblElement")).Font;

			//strELE_Name = CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ELE_NAME"))

			rectReportHeader.X = 100;
			//((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2)   'rectReportHeader.X * 96 + sngXPositionIn
			rectReportHeader.Y = rectReportHeader.Y * 96 + sngYPositionIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = (rectReportHeader.Width * 72) * Const_QuantitativeReportFor.Length;
			//rectReportHeader.Width * 96 

			EV.Graphics.DrawString(Const_QuantitativeReportFor, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());


			//sngYPositionIn += rectReportHeader.Height + (lineSpacing + printFont.GetHeight(EV.Graphics))
			rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 2);
			//rectReportHeader.X * 96 + sngXPositionIn
			rectReportHeader.Y = sngYPositionIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;

			//strELE_Name = "      " & CStr(objDtCookBookInfoRpt.Rows.Item(0).Item("ELE_NAME"))
			strELE_Name = "      " + gobjMethodCollection.item(mintMethodID).InstrumentCondition.ElementID;
			// QuantitativeDataCollection(mintRunNo).  

			//mintMethodID()

			EV.Graphics.DrawString(strELE_Name, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 4);
			//rectReportHeader.X * 96 + sngXPositionIn
			rectReportHeader.Y = sngYPositionIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;

			strText = Const_RunNO + (string)objDtDatafileRpt.Rows.Item(0).Item("RUNNO");

			EV.Graphics.DrawString(strText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 4);
			//rectReportHeader.X * 96 + sngXPositionIn
			rectReportHeader.Y = sngYPositionIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;

			strText = Const_Analysed;
			//CStr(objDtDatafileRpt.Rows.Item(0).Item("RUNNO"))

			EV.Graphics.DrawString(strText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 4);
			//rectReportHeader.X * 96 + sngXPositionIn
			rectReportHeader.Y = sngYPositionIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;

			strText = Const_Analysed;
			//CStr(objDtDatafileRpt.Rows.Item(0).Item("RUNNO"))

			EV.Graphics.DrawString(strText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			rectReportHeader.X = ((objARLayoutReport.PageSettings.PaperWidth * 100) / 2) - ((Len(strELE_Name) * ReportHeaderFont.SizeInPoints) / 4);
			//rectReportHeader.X * 96 + sngXPositionIn
			rectReportHeader.Y = sngYPositionIn;
			rectReportHeader.Height = rectReportHeader.Height * 96;
			rectReportHeader.Width = rectReportHeader.Width * 96;

			strText = (string)objDtDatafileRpt.Rows.Item(0).Item("ANALYSEDON");
			EV.Graphics.DrawString(strText, ReportHeaderFont, objBrush, rectReportHeader, new StringFormat());

			sngYPositionIn += (lineSpacing + printFont.GetHeight(EV.Graphics));

			blnFinishElamentInfo = true;
			return true;

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.ErrorMessage = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
			gobjErrorHandler.ProcessError(ErrorHandler.ErrorHandler.EnumErrorType.Critical, ex);
			return false;
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

	private void subDatafileInitInfo(ref System.Drawing.Printing.PrintPageEventArgs ev, Drawing.RectangleF rectGrid, DataTable objDtReportDataTableIn, enumReportType intReportTypeIn, ref float YPosition)
	{
		//=====================================================================
		// Procedure Name        :   subDatafileInitInfo
		// Parameters Passed     :   rectGrid is Drawing.RectangleF, objDtReportDataTableIn As DataTable
		//                       :   intReportTypeIn is the  enumReportType data type
		// Parameters Affected   :   ev is the System.Drawing.Printing.PrintPageEventArgs
		//                       :   YPosition is the Y axis postion of the report
		// Returns               :   None
		// Purpose               :   Print the data of report data file header
		// Description           :   Print the data of report data file header
		// Assumptions           :   None
		// Dependencies          :   None
		// Author                :   Sachin Dokhale
		// Created               : 
		// Revisions             : 
		//=====================================================================

		bool blnIsLeft = false;
		Font ReportHeader1Font;
		Font ReportHeaderFont;
		Font ReportText1Font;
		Font ReportHeader2Font;
		Font ReportText2Font;
		float sngColumnWidth;
		Rectangle r;
		Drawing.RectangleF rf;
		SizeF sizStringSize;
		StringFormat newStringFormat = new StringFormat();
		int intLineHeigt;
		Drawing.Color clrMangeta;
		Drawing.Color FontColor;
		int i;
		int j;
		int w;
		int l;
		float leftMargin = rectGrid.Left;
		int rowHeight;
		SolidBrush hfBrush = new SolidBrush(Color.Black);

		try {
			rectGrid.Y = YPosition;
			float topMargin = rectGrid.Top;
			l = (int)topMargin;
			//l += headerHeight

			w = (int)leftMargin;
			if (!(objDtReportDataTableIn.TableName == "Quantitative Report")) {
				return;
			}
			ReportText1Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtAbso")).Font;
			ReportHeaderFont = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("lblHeader")).Font;
			ReportHeader1Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("Abso")).Font;
			ReportHeader2Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("Abso")).Font;
			ReportText2Font = ((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtAbso")).Font;


			//rowHeight = CInt(ReportText1Font.GetHeight(ev.Graphics)) + 1
			rowHeight = (int)ReportHeaderFont.GetHeight(ev.Graphics) + 1;
			l += rowHeight;
			//If Not objDtReportDataTableIn.Rows.Item(0).Item(0).ToString = "" Then

			if (!objDtReportDataTableIn.Columns(j).Caption == "") {
				//sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, j).Width
				sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width;
				w = sngColumnWidth / 2;
				r = new Rectangle(w, l, (int)sngColumnWidth, rowHeight);
				rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);
				ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeaderFont, hfBrush, rf);
				hfBrush.Color = clrMangeta.Black;
				l += r.Height + 10;

				sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 4).Width;
				w = (int)leftMargin;
				r = new Rectangle(w, l, (int)sngColumnWidth, rowHeight);
				rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);
				ev.Graphics.DrawString(objDtReportDataTableIn.Columns(1).Caption, ReportHeaderFont, hfBrush, rf);


				if (!objDtReportDataTableIn.Rows.Item(0).Item(1).ToString == "") {
					r = new Rectangle(w + 200, l, (int)sngColumnWidth - 30, rowHeight);
					rf = new Drawing.RectangleF(w + 205, l + 2, r.Width, r.Height);

					ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(0).Item(1).ToString, ReportHeaderFont, hfBrush, rf);
					hfBrush.Color = clrMangeta.Black;
				}
				l += r.Height + 10;
			}

			j = 2;


			while (j <= objDtReportDataTableIn.Columns.Count - 1) {


				if (IsNumeric(objDtReportDataTableIn.Rows(i).Item(j).ToString())) {
					if (IsNothing(ColoumnFormat)) {
						ColoumnFormat = new StringFormat();
					}
					if (SetTableColoumnFormat == true) {
						ColoumnFormat.Alignment = StringAlignment.Near;
					}
				} else {
					if (IsNothing(ColoumnFormat)) {
						ColoumnFormat = new StringFormat();
					}
					if (SetTableColoumnFormat == true) {
						ColoumnFormat.Alignment = StringAlignment.Near;
					}
				}

				CurRow = 1;
				newStringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
				newStringFormat.Alignment = StringAlignment.Near;


				if (blnIsLeft == false) {

					sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 0).Width;
					sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, (int)sngColumnWidth, newStringFormat);
					rowHeight = (int)sizStringSize.Height;

					r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
					rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);

					ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader1Font, hfBrush, rf);
					intLineHeigt = l + r.Height;

					//sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 1).Width
					sngColumnWidth = 200;
					if (!(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString == "")) {
						sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, (int)sngColumnWidth, newStringFormat);
						rowHeight = (int)sizStringSize.Height;

						r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
						//w += CInt(CType(mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtStdSampName"), DataDynamics.ActiveReports.Label).Left) * 72
						w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrRepeatResults").Controls("TxtAbso")).Left * 72;

						rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);

						ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText1Font, Drawing.Brushes.Black, rf, ColoumnFormat);
					}
					blnIsLeft = true;
				} else {
					sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 2).Width;
					//sngColumnWidth = 200
					sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, (int)sngColumnWidth, newStringFormat);
					rowHeight = (int)sizStringSize.Height;

					w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("TxtLable2")).Left * 72 - 100;
					r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);

					rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);
					blnIsLeft = false;
					ev.Graphics.DrawString(objDtReportDataTableIn.Columns(j).Caption, ReportHeader2Font, hfBrush, rf);
					if (!(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString == "")) {
						//sngColumnWidth = funcGetColumnWidth(intReportTypeIn, enumReportLayoutType.Portrate, 3).Width
						sngColumnWidth = 200;
						sizStringSize = ev.Graphics.MeasureString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, (int)sngColumnWidth, newStringFormat);
						rowHeight = (int)sizStringSize.Height;
						r = new Rectangle(w, l, (int)sngColumnWidth - 3, rowHeight);
						rf = new Drawing.RectangleF(w + 5, l + 2, r.Width, r.Height);

						w += (int)((DataDynamics.ActiveReports.Label)mobjARPortrateReport.Sections("GrpHdrDatafile").Controls("Txt2")).Left * 72 - 300;
						rf = new Drawing.RectangleF(w, l + 2, r.Width, r.Height);

						ev.Graphics.DrawString(objDtReportDataTableIn.Rows.Item(i).Item(j).ToString, ReportText2Font, Drawing.Brushes.Black, rf, ColoumnFormat);
					}
					//
					w = (int)leftMargin;
					l += r.Height;
				}
				continuefor2:
				j += 1;
			}
			l += r.Height;
			//Draw line after report header detalis
			ev.Graphics.DrawLine(new Pen(Color.Black), leftMargin, l, leftMargin + rectGrid.Width, l);

			YPosition = l;
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

	#End Region

}

public class clsReportHeaderFormat
{
	//*********************************************************************
	// File Header       : clsReportHeaderFormat 
	// File Name 		: clsPrintDocument.vb
	// Author			: Sachin Dokhale
	// Date/Time			: 22 Jan 07
	// Description		: To set the Header format
	//**********************************************************************

	#Region " Private Variable"
		#End Region
	System.Drawing.ContentAlignment m_Alignment;

	public clsReportHeaderFormat()
	{
		base.New();

		//This call is required by the Component Designer.
		//InitializeComponent()
		//Add any initialization after the InitializeComponent() call
		////----- Set default initialise the of Report
		////-----
		m_Alignment = ContentAlignment.MiddleLeft;
	}

	public System.Drawing.ContentAlignment Alignment {
		get { Alignment = m_Alignment; }
		set { m_Alignment = Value; }
	}



}
