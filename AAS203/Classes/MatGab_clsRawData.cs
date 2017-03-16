public class clsRawData
{

	public enum enumSampleType
	{
		BLANK = 0,
		STANDARD = 1,
		SAMPLE = 2
	}

	private int mintSampleID;
	private enumSampleType mintSampleType;
	private string mstrSampleName;
	private int mintTotalReadings;

	private clsRawDataReadings mobjReadings;

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

	public void AddReadings(double dblConcentration, double dblAbsorbance)
	{
		clsRawDataReadings.RAW_DATA objRawData;

		if (IsNothing(mobjReadings)) {
			mobjReadings = new clsRawDataReadings();
		}

		objRawData = new clsRawDataReadings.RAW_DATA();
		objRawData.Concentration = dblConcentration;
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

}
