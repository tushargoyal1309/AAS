namespace Method
{
	[Serializable()]
	public class clsReportParameters : ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor
		public clsReportParameters()
		{
			blnWeightVolumeDilution = false;
			blnAbsorbance = false;
			blnStandards = false;
			blnMethodInfo = false;
			blnAnalysisParameters = false;
			blnInstrumentCondition = false;
			blnReportHeaderAndFooter = false;
			blnReportFooter = false;
			blnDate = false;
			blnLogo = false;
			dblLeft = 0.0;
			dblTop = 0.0;
			dblBottom = 0.0;
			strReportHeader = "";
			strReportFooter = "";
		}

		//---Copy Constructor
		public clsReportParameters(clsReportParameters rhs)
		{
			blnWeightVolumeDilution = rhs.IsWeightVolumeDilution;
			blnAbsorbance = rhs.IsAbsorbance;
			blnStandards = rhs.IsStandards;
			blnMethodInfo = rhs.IsMethodInfo;
			blnAnalysisParameters = rhs.IsAnalysisParameters;
			blnInstrumentCondition = rhs.IsInstrumentCondition;
			blnReportHeaderAndFooter = rhs.IsReportHeaderAndFooter;
			blnReportFooter = rhs.blnReportFooter;
			blnDate = rhs.blnDate;
			blnLogo = rhs.blnLogo;
			dblLeft = rhs.dblLeft;
			dblTop = rhs.dblTop;
			dblBottom = rhs.dblBottom;
			strReportHeader = rhs.ReportHeader;
			strReportFooter = rhs.ReportFooter;
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsAnalysisParameters
		public object System.ICloneable.Clone()
		{
			return new clsReportParameters(this);
		}

		#End Region

		#Region " Private variables "

		private bool blnWeightVolumeDilution = false;
		private bool blnAbsorbance = false;
		private bool blnStandards = false;
		private bool blnMethodInfo = false;
		private bool blnAnalysisParameters = false;
		private bool blnInstrumentCondition = false;
		private bool blnReportHeaderAndFooter = false;
		private bool blnReportFooter = false;
		private bool blnDate = false;
		private bool blnLogo = false;
		private double dblLeft = 0.0;
		private double dblTop = 0.0;
		private double dblBottom = 0.0;
		private string strReportHeader = "";

		private string strReportFooter = "";
		#End Region

		#Region " Public Properties "

		public bool IsWeightVolumeDilution {
			get { return blnWeightVolumeDilution; }
			set { blnWeightVolumeDilution = Value; }
		}

		public bool IsAbsorbance {
			get { return blnAbsorbance; }
			set { blnAbsorbance = Value; }
		}

		public bool IsStandards {
			get { return blnStandards; }
			set { blnStandards = Value; }
		}

		public bool IsMethodInfo {
			get { return blnMethodInfo; }
			set { blnMethodInfo = Value; }
		}

		public bool IsAnalysisParameters {
			get { return blnAnalysisParameters; }
			set { blnAnalysisParameters = Value; }
		}

		public bool IsInstrumentCondition {
			get { return blnInstrumentCondition; }
			set { blnInstrumentCondition = Value; }
		}

		public bool IsReportHeaderAndFooter {
			get { return blnReportHeaderAndFooter; }
			set { blnReportHeaderAndFooter = Value; }
		}

		//Public Property IsReportFooter() As Boolean
		//    Get
		//        Return blnReportFooter
		//    End Get
		//    Set(ByVal Value As Boolean)
		//        blnReportFooter = Value
		//    End Set
		//End Property

		//Public Property IsDate() As Boolean
		//    Get
		//        Return blnDate
		//    End Get
		//    Set(ByVal Value As Boolean)
		//        blnDate = Value
		//    End Set
		//End Property

		//Public Property IsLogo() As Boolean
		//    Get
		//        Return blnLogo
		//    End Get
		//    Set(ByVal Value As Boolean)
		//        blnLogo = Value
		//    End Set
		//End Property

		//Public Property LeftMargin() As Double
		//    Get
		//        Return dblLeft
		//    End Get
		//    Set(ByVal Value As Double)
		//        dblLeft = Value
		//    End Set
		//End Property

		//Public Property TopMargin() As Double
		//    Get
		//        Return dblTop
		//    End Get
		//    Set(ByVal Value As Double)
		//        dblTop = Value
		//    End Set
		//End Property

		//Public Property BottomMargin() As Double
		//    Get
		//        Return dblBottom
		//    End Get
		//    Set(ByVal Value As Double)
		//        dblBottom = Value
		//    End Set
		//End Property

		public string ReportHeader {
			get { return strReportHeader; }
			set { strReportHeader = Value; }
		}

		public string ReportFooter {
			get { return strReportFooter; }
			set { strReportFooter = Value; }
		}

		#End Region

	}

}
