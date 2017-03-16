
namespace Method
{
	[Serializable()]
	public class clsAnalysisParameters : ICloneable
	{

		#Region " Public Function "

		//---Default Constructor
		public clsAnalysisParameters()
		{
			mstrAnalystName = "";
			mstrLabName = "";
			mintMeasurementMode = 0;
			mintIntegrationTime = 0;
			mintNumOfSamples = 0;
			mintNumOfSampleRepeats = 0;
			mintNumOfStdRepeats = 0;
			mblnBlankAfterEverySampleOrStd = false;
			mintUnit = 0;
			mintNumOfDecimalPlaces = 0;
			mDtAnaDate = Now;
			mblnBlank = false;
		}

		//---Copy Constructor
		public clsAnalysisParameters(clsAnalysisParameters rhs)
		{
			mstrAnalystName = rhs.AnalystName;
			mDtAnaDate = rhs.Analysis_Date;
			mstrLabName = rhs.LabName;
			mintMeasurementMode = rhs.MeasurementMode;
			mintIntegrationTime = rhs.IntegrationTime;
			mintNumOfSamples = rhs.NumOfSamples;
			mintNumOfSampleRepeats = rhs.NumOfSampleRepeats;
			mintNumOfStdRepeats = rhs.NumOfStdRepeats;
			mintNumOfDecimalPlaces = rhs.NumOfDecimalPlaces;
			mblnBlankAfterEverySampleOrStd = rhs.IsBlankAfterEverySampleOrStd;
			mblnBlank = rhs.IsBlank;
			mintUnit = rhs.Unit;
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsAnalysisParameters
		public object System.ICloneable.Clone()
		{
			return new clsAnalysisParameters(this);
		}

		#End Region

		#Region " Private Variables "

		private string mstrAnalystName;
		private string mstrLabName;
		private int mintMeasurementMode;
		private int mintIntegrationTime;
		private int mintNumOfSamples;
		private int mintNumOfSampleRepeats;
		private int mintNumOfStdRepeats;
		private bool mblnBlankAfterEverySampleOrStd;
		private int mintUnit;
		private int mintNumOfDecimalPlaces;
		private System.DateTime mDtAnaDate;

		private bool mblnBlank;
		#End Region

		#Region " Public Properties "

		public string AnalystName {
			get { return mstrAnalystName; }
			set { mstrAnalystName = Value; }
		}

		public string LabName {
			get { return mstrLabName; }
			set { mstrLabName = Value; }
		}

		public int MeasurementMode {
			get { return mintMeasurementMode; }
			set { mintMeasurementMode = Value; }
		}

		public int IntegrationTime {
			get { return mintIntegrationTime; }
			set { mintIntegrationTime = Value; }
		}

		public int NumOfSamples {
			get { return mintNumOfSamples; }
			set { mintNumOfSamples = Value; }
		}

		public int NumOfSampleRepeats {
			get { return mintNumOfSampleRepeats; }
			set { mintNumOfSampleRepeats = Value; }
		}

		public int NumOfStdRepeats {
			get { return mintNumOfStdRepeats; }
			set { mintNumOfStdRepeats = Value; }
		}

		public bool IsBlankAfterEverySampleOrStd {
			get { return mblnBlankAfterEverySampleOrStd; }
			set { mblnBlankAfterEverySampleOrStd = Value; }
		}

		public int Unit {
			get { return mintUnit; }
			set { mintUnit = Value; }
		}

		public int NumOfDecimalPlaces {
			get { return mintNumOfDecimalPlaces; }
			set { mintNumOfDecimalPlaces = Value; }
		}

		public System.DateTime Analysis_Date {
			get { return mDtAnaDate; }
			set { mDtAnaDate = Value; }
		}

		public bool IsBlank {
			get { return mblnBlank; }
			set { mblnBlank = Value; }
		}

		#End Region

	}

}
