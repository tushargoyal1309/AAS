
[Serializable()]
public class clsAnalysisStdConcentration
{

	private int intSrNumber;
	private string strStdName;

	private double dblConcentration;
	public int SrNumber {
		get { SrNumber = intSrNumber; }
		set { intSrNumber = Value; }
	}

	public string StdName {
		get { StdName = strStdName; }
		set { strStdName = Value; }
	}

	public double Concentration {
		get { Concentration = dblConcentration; }
		set { dblConcentration = Value; }
	}

}
