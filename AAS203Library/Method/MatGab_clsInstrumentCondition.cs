
[Serializable()]
public class clsInstrumentCondition
{

	private string strElementName;
	private int intElementNumber;
	private int intTurretNumber;
	private double dblLampCurrent;
	private double dblWavelength;
	private double dblSlitWidth;

	private bool blnBurnerYesNo;
	public string ElementName {
		get { ElementName = strElementName; }
		set { strElementName = Value; }
	}

	public int ElementNumber {
		get { ElementNumber = intElementNumber; }
		set { intElementNumber = Value; }
	}

	public int TurretNumber {
		get { TurretNumber = intTurretNumber; }
		set { intTurretNumber = Value; }
	}

	public double LampCurrent {
		get { LampCurrent = dblLampCurrent; }
		set { dblLampCurrent = Value; }
	}

	public double Wavelength {
		get { Wavelength = dblWavelength; }
		set { dblWavelength = Value; }
	}

	public double SlitWidth {
		get { SlitWidth = dblSlitWidth; }
		set { dblSlitWidth = Value; }
	}

	public bool Burner {
		get { Burner = blnBurnerYesNo; }
		set { blnBurnerYesNo = Value; }
	}

}
