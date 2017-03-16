namespace Analysis
{

	[Serializable()]
	public class clsRawData : ICloneable
	{

		#Region " Constructors and Destructors "

		//---Default Constructor
		public clsRawData()
		{
			mintSampleID = 0;
			mintSampleType = enumSampleType.BLANK;
			mstrSampleName = "";
			mintTotalReadings = 0;
			mobjReadings = new clsRawDataReadings();
		}

		//---Copy Constructor
		public clsRawData(clsRawData rhs)
		{
			mintSampleID = rhs.SampleID;
			mintSampleType = rhs.SampleType;
			mstrSampleName = rhs.SampleName;
			mintTotalReadings = rhs.TotalReadings;
			mobjReadings = rhs.Readings.Clone();
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsRawData
		public object System.ICloneable.Clone()
		{
			return new clsRawData(this);
		}

		#End Region

		#Region " Public enums, constants.. "

		public enum enumSampleType
		{
			BLANK = 0,
			STANDARD = 1,
			SAMPLE = 2
		}

		#End Region

		#Region " Private Variables "

		private int mintSampleID;
		private enumSampleType mintSampleType;
		private string mstrSampleName;
		private int mintTotalReadings;

		private clsRawDataReadings mobjReadings;
		#End Region

		#Region " Public Properties "

		public int SampleID {
			get { return mintSampleID; }
			set { mintSampleID = Value; }
		}

		public enumSampleType SampleType {
			get { return mintSampleType; }
			set { mintSampleType = Value; }
		}

		public string SampleName {
			get { return mstrSampleName; }
			set { mstrSampleName = Value; }
		}

		public int TotalReadings {
			get {
				if (!IsNothing(mobjReadings)) {
					mintTotalReadings = mobjReadings.Count;
				} else {
					mintTotalReadings = 0;
				}
				return mintTotalReadings;
			}
		}

		public clsRawDataReadings Readings {
			get { return mobjReadings; }
		}

		#End Region

		#Region " Public Functions "

		public void AddReadings(double dblXTime, double dblAbsorbance)
		{
			clsRawDataReadings.RAW_DATA objRawData;

			if (IsNothing(mobjReadings)) {
				mobjReadings = new clsRawDataReadings();
			}

			objRawData = new clsRawDataReadings.RAW_DATA();
			objRawData.XTime = dblXTime;
			objRawData.Absorbance = dblAbsorbance;
			mobjReadings.Add(objRawData);

		}

		public void ClearReadings()
		{
			if (!IsNothing(mobjReadings))
				mobjReadings.Clear();
		}

		public void DeleteReading(clsRawDataReadings.RAW_DATA objRawData)
		{
			mobjReadings.Remove(objRawData);
		}

		#End Region

	}

}
