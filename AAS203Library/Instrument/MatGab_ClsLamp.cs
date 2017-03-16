namespace Instrument
{
	[Serializable()]
	public class ClsLamp : ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor
		public ClsLamp()
		{
			dblWVZero = 0.0;
			LampParametersCollection = new ClsLampParametersCollection();
			EMSCondition = new ClsEMSCondition();
		}

		//---Copy Constructor
		public ClsLamp(ClsLamp rhs)
		{
			dblWVZero = rhs.WavelengthZero;
			LampParametersCollection = rhs.LampParametersCollection.Clone();
			EMSCondition = rhs.EMSCondition.Clone();
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the ClsLamp
		public object System.ICloneable.Clone()
		{
			return new ClsLamp(this);
		}

		#End Region

		#Region " Private Variables "

		private double dblWVZero;
		public ClsLampParametersCollection LampParametersCollection;

		public ClsEMSCondition EMSCondition;
		#End Region

		#Region " Public Properties "

		public double WavelengthZero {
			get { return dblWVZero; }
			set { dblWVZero = Value; }
		}

		#End Region

	}
}

