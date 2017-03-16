namespace Instrument
{
	[Serializable()]
	public class ClsEMSCondition : ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor
		public ClsEMSCondition()
		{
			strElementName = "";
			intAtomicNumber = 0;
			dblWavelength = 0.0;
			dblSlitWidth = 0.0;
		}

		//---Copy Constructor
		public ClsEMSCondition(ClsEMSCondition rhs)
		{
			strElementName = rhs.ElementName;
			intAtomicNumber = rhs.AtomicNumber;
			dblWavelength = rhs.Wavelength;
			dblSlitWidth = rhs.SlitWidth;
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the ClsEMSCondition
		public object System.ICloneable.Clone()
		{
			return new ClsEMSCondition(this);
		}

		#End Region

		#Region " Private Variables "

		private string strElementName;
		private int intAtomicNumber;
		private double dblWavelength;

		private double dblSlitWidth;
		#End Region

		#Region " Public Properties "

		public string ElementName {
			get { return strElementName; }
			set { strElementName = Value; }
		}

		public int AtomicNumber {
			get { return intAtomicNumber; }
			set { intAtomicNumber = Value; }
		}

		public double Wavelength {
			get { return dblWavelength; }
			set { dblWavelength = Value; }
		}

		public double SlitWidth {
			get { return dblSlitWidth; }
			set { dblSlitWidth = Value; }
		}

		#End Region

	}
}

