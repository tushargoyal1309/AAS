namespace FuelConditions
{
	[Serializable()]
	public class clsFuelData : ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor

		public clsFuelData()
		{
		}

		//---Copy Constructor

		public clsFuelData(clsFuelData rhs)
		{
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsAbsRepeat
		public object System.ICloneable.Clone()
		{
			return new clsFuelData(this);
		}

		#End Region

		#Region "Private Variables"
		private string mstrElementName;
		private int mintAtomicNumber;
		private double mdblBurnerHeight;
		private double mdblNVStep;
			#End Region
		private bool mblnIsAAFlame;

		#Region "Public Properties"
		public string ElementName {
			get { return mstrElementName; }
			set { mstrElementName = Value; }
		}

		public int AtomicNumber {
			get { return mintAtomicNumber; }
			set { mintAtomicNumber = Value; }
		}

		public double BurnerHeight {
			get { return mdblBurnerHeight; }
			set { mdblBurnerHeight = Value; }
		}

		public double NVStep {
			get { return mdblNVStep; }
			set { mdblNVStep = Value; }
		}

		public bool IsAAFlame {
			get { return mblnIsAAFlame; }
			set { mblnIsAAFlame = Value; }
		}

		#End Region

	}
}
