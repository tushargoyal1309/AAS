
namespace Method
{

	[Serializable()]
	public class clsQuantitativeData : ICloneable, IDisposable
	{
		//**********************************************************************
		// File Header       
		// File Name 		:   clsQuantitativeData.vb
		// Author			:   Mangesh Shardul
		// Date/Time			:   25-Jan-2007 05:15 pm
		// Description		:   Class to hold Quantitative Analysis Data of 
		//                       Standards and Samples, Analysis & Report Parameters
		// Assumptions       :	
		// Dependencies      :   clsMethod, clsAnalysisParameters, clsReportParameters
		//                       clsAnalysisStdParametersCollection, clsAnalysisSampleParametersCollection
		//**********************************************************************

		#Region " Private Member Variables "

		private string mstrRunNumber;
		private enumCalculationMode mintCalculationMode;
		private clsInstrumentParameters mobjInstParameters;
		private clsAnalysisParameters mobjAnalysisParameters;
		private clsReportParameters mobjReportParameters;
		private clsAnalysisStdParametersCollection mobjStandardData;
		private clsAnalysisSampleParametersCollection mobjSampleData;
		private Analysis.clsRawDataCollection mobjAnalysisRawData;
		//Private mobjLastStandardData As clsAnalysisStdParameters
		//Private mobjLastSampleData As clsAnalysisSampleParameters

		#End Region

		#Region " Public Enums, Constants, structures .. "

		public enum enumCalculationMode
		{
			DIRECT = -1,
			RATIONAL = 0,
			LINEAR = 1,
			QUADRATIC = 2,
			CUBIC = 3,
			FOURTH_ORDER = 4,
			FIFTH_ORDER = 5
		}

		#End Region

		#Region " Public Properties "

		public string RunNumber {
			get { return mstrRunNumber; }
			set { mstrRunNumber = Value; }
		}

		public enumCalculationMode CalculationMode {
			get { return mintCalculationMode; }
			set { mintCalculationMode = Value; }
		}

		public clsAnalysisParameters AnalysisParameters {
			get { return mobjAnalysisParameters; }
			set { mobjAnalysisParameters = Value; }
		}

		public clsReportParameters ReportParameters {
			get { return mobjReportParameters; }
			set { mobjReportParameters = Value; }
		}

		public clsAnalysisStdParametersCollection StandardDataCollection {
			get { return mobjStandardData; }
			set { mobjStandardData = Value; }
		}

		public clsAnalysisSampleParametersCollection SampleDataCollection {
			get { return mobjSampleData; }
			set { mobjSampleData = Value; }
		}

		public Analysis.clsRawDataCollection AnalysisRawData {
			get { return mobjAnalysisRawData; }
			set { mobjAnalysisRawData = Value; }
		}

		public clsInstrumentParameters InstrumentParameterForRunNumber {
			get { return mobjInstParameters; }
			set { mobjInstParameters = Value; }
		}

		//Public Property LastStandardData() As clsAnalysisStdParameters
		//    Get
		//        Return mobjLastStandardData
		//    End Get
		//    Set(ByVal Value As clsAnalysisStdParameters)
		//        mobjLastStandardData = Value
		//    End Set
		//End Property

		//Public Property LastSampleData() As clsAnalysisSampleParameters
		//    Get
		//        Return mobjLastSampleData
		//    End Get
		//    Set(ByVal Value As clsAnalysisSampleParameters)
		//        mobjLastSampleData = Value
		//    End Set
		//End Property

		#End Region

		#Region " Public functions "

		//---Default Constructor
		public clsQuantitativeData()
		{
			//=====================================================================
			// Procedure Name        : New [Constructor]
			// Parameters Passed     : None
			// Returns               : None
			// Purpose               : To initialize the member variables
			// Description           : 
			// Assumptions           : 
			// Dependencies          : 
			// Author                : Mangesh Shardul
			// Created               : 25-Jan-2007 05:20 pm
			// Revisions             : 1
			//=====================================================================
			mstrRunNumber = "";
			mintCalculationMode = enumCalculationMode.DIRECT;
			mobjAnalysisParameters = new clsAnalysisParameters();
			mobjReportParameters = new clsReportParameters();
			mobjStandardData = new clsAnalysisStdParametersCollection();
			mobjSampleData = new clsAnalysisSampleParametersCollection();
			mobjAnalysisRawData = new Analysis.clsRawDataCollection();
			//mobjLastStandardData = New clsAnalysisStdParameters
			//mobjLastSampleData = New clsAnalysisSampleParameters
		}

		//---Copy Constructor
		public clsQuantitativeData(clsQuantitativeData rhs)
		{
			//=====================================================================
			// Procedure Name        : New [Copy Constructor]
			// Parameters Passed     : None
			// Returns               : None
			// Purpose               : To initialize the member variables
			// Description           : 
			// Assumptions           : 
			// Dependencies          : 
			// Author                : Mangesh Shardul
			// Created               : 25-Jan-2007 05:20 pm
			// Revisions             : 1
			//=====================================================================
			mstrRunNumber = rhs.RunNumber;
			mintCalculationMode = rhs.CalculationMode;
			mobjAnalysisParameters = rhs.AnalysisParameters.Clone();
			mobjReportParameters = rhs.ReportParameters.Clone();
			mobjStandardData = rhs.StandardDataCollection.Clone();
			mobjSampleData = rhs.SampleDataCollection.Clone();
			mobjAnalysisRawData = rhs.AnalysisRawData.Clone();
			//mobjLastStandardData = rhs.LastStandardData.Clone
			//mobjLastSampleData = rhs.LastSampleData.Clone
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsQuantitativeData
		public object System.ICloneable.Clone()
		{
			return new clsQuantitativeData(this);
		}

		public void System.IDisposable.Dispose()
		{
			//=====================================================================
			// Procedure Name        : Dispose [Constructor]
			// Parameters Passed     : None
			// Returns               : None
			// Purpose               : To dispose off the member variables
			// Description           : 
			// Assumptions           : 
			// Dependencies          : 
			// Author                : Mangesh Shardul
			// Created               : 25-Jan-2007 05:20 pm
			// Revisions             : 1
			//=====================================================================
			mstrRunNumber = null;
			mintCalculationMode = null;
			mobjAnalysisParameters = null;
			mobjReportParameters = null;
			mobjStandardData = null;
			mobjSampleData = null;
			//mobjLastStandardData = Nothing
			//mobjLastSampleData = Nothing
		}

		#End Region

	}

}
