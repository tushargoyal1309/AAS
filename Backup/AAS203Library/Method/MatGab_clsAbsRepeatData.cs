
namespace Method
{
	[Serializable()]
	public class clsAbsRepeatData : ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor
		public clsAbsRepeatData()
		{
			mdblConcentration = 0.0;
			mdblAbs = 0.0;
			mdblUsed = false;
		}

		//---Copy Constructor
		public clsAbsRepeatData(clsAbsRepeatData rhs)
		{
			mdblConcentration = rhs.Concentration;
			mdblAbs = rhs.Abs;
			mdblUsed = rhs.Used;
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsAbsRepeatData
		public object System.ICloneable.Clone()
		{
			return new clsAbsRepeatData(this);
		}

		#End Region

		#Region " Private Variables "

		private double mdblConcentration;
		private double mdblAbs;

		private bool mdblUsed;
		#End Region

		#Region " Public Properties "

		public double Concentration {
			get { return mdblConcentration; }
			set { mdblConcentration = Value; }
		}

		public double Abs {
			get { return mdblAbs; }
			set { mdblAbs = Value; }
		}

		public bool Used {
			get { return mdblUsed; }
			set { mdblUsed = Value; }
		}

		#End Region

	}

}

