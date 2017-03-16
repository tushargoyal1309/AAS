
namespace Method
{
	[Serializable()]
	public class clsBasicStat : ICloneable
	{

		#Region " Public Function "

		//---Default Constructor
		public clsBasicStat()
		{
			 // ERROR: Not supported in C#: ReDimStatement

			 // ERROR: Not supported in C#: ReDimStatement

			 // ERROR: Not supported in C#: ReDimStatement

			 // ERROR: Not supported in C#: ReDimStatement

			 // ERROR: Not supported in C#: ReDimStatement

			 // ERROR: Not supported in C#: ReDimStatement

			 // ERROR: Not supported in C#: ReDimStatement

		}

		//---Copy Constructor
		public clsBasicStat(clsBasicStat rhs)
		{
			TotData = rhs.TotData;
			ZAvg = rhs.ZAvg;
			ZSigma = rhs.ZSigma;
			Var = rhs.Var;
			CV = rhs.CV;
			Min = rhs.Min;
			Max = rhs.Max;
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsBasicStat
		public object System.ICloneable.Clone()
		{
			return new clsBasicStat(this);
		}

		#End Region

		#Region " Public Variables "

		public int[] TotData;
		public double[] ZAvg;
		public double[] ZSigma;
		public double[] Var;
		public double[] CV;
		public double[] Min;

		public double[] Max;
		#End Region

	}

}

