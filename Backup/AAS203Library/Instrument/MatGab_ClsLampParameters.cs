namespace Instrument
{

	[Serializable()]
	public class ClsLampParameters : ICloneable
	{

		#Region " Private Variables "

		private string strElementName;
		private bool blnMel;
		private int intAtomicNumber;
		private double dblCurrent;
		private double dblWavelength;
		private double dblSlitWidth;
		private int intMode;
		private bool blnBurner;

		private int intLampOptimizePosition;
		#End Region

		#Region " Public Properties "

		public string ElementName {
			get { return strElementName; }
			set { strElementName = Value; }
		}

		public bool Mel {
			get { return blnMel; }
			set { blnMel = Value; }
		}

		public int AtomicNumber {
			get { return intAtomicNumber; }
			set { intAtomicNumber = Value; }
		}

		public double Current {
			get { return dblCurrent; }
			set { dblCurrent = Value; }
		}

		public double Wavelength {
			get { return dblWavelength; }
			set { dblWavelength = Value; }
		}

		public double SlitWidth {
			get { return dblSlitWidth; }
			set { dblSlitWidth = Value; }
		}

		public double Mode {
			get { return intMode; }
			set { intMode = Value; }
		}

		public bool Burner {
			get { return blnBurner; }
			set { blnBurner = Value; }
		}

		public int LampOptimizePosition {
			get { return intLampOptimizePosition; }
			set { intLampOptimizePosition = Value; }
		}

		#End Region

		#Region " Public Functions "

		//---Default Constructor
		public ClsLampParameters()
		{
			strElementName = "";
			blnMel = false;
			intAtomicNumber = 0;
			dblCurrent = 0.0;
			dblWavelength = 0.0;
			dblSlitWidth = 0.0;
			intMode = 0;
			blnBurner = false;
			intLampOptimizePosition = 0;
		}

		//---Copy Constructor
		public ClsLampParameters(ClsLampParameters rhs)
		{
			strElementName = rhs.ElementName;
			blnMel = rhs.Mel;
			intAtomicNumber = rhs.AtomicNumber;
			dblCurrent = rhs.Current;
			dblWavelength = rhs.Wavelength;
			dblSlitWidth = rhs.SlitWidth;
			intMode = rhs.Mode;
			blnBurner = rhs.Burner;
			intLampOptimizePosition = rhs.LampOptimizePosition;
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the ClsLampParameters
		public object System.ICloneable.Clone()
		{
			return new ClsLampParameters(this);
		}

		#End Region

	}
}

