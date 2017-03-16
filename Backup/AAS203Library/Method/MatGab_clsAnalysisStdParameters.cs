
namespace Method
{
	[Serializable()]
	public class clsAnalysisStdParameters : ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor
		public clsAnalysisStdParameters()
		{
			mintPositionNumber = -1;
			// 0 to -1 'by Pankaj for autosampler on 10Sep 07 
			mintStdNumber = 0;
			mstrStdName = "";
			mdblConcentration = 0.0;
			mdblAbs = 0.0;
			mdblnStd = 0.0;
			mblnUsed = false;
			AbsRepeat = new clsAbsRepeat();
		}

		//---Copy Constructor
		public clsAnalysisStdParameters(clsAnalysisStdParameters rhs)
		{
			mintPositionNumber = rhs.PositionNumber;
			mintStdNumber = rhs.StdNumber;
			mstrStdName = rhs.StdName;
			mdblConcentration = rhs.Concentration;
			mdblAbs = rhs.Abs;
			mdblnStd = rhs.nStd;
			mblnUsed = rhs.Used;
			AbsRepeat = rhs.AbsRepeat.Clone();
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsAnalysisStdParameters
		public object System.ICloneable.Clone()
		{
			return new clsAnalysisStdParameters(this);
		}

		#End Region

		#Region " Private Variables "

		private int mintPositionNumber;
		private int mintStdNumber;
		private string mstrStdName;
		private double mdblConcentration;
		private double mdblAbs;
		private double mdblnStd;

		private bool mblnUsed;

		public clsAbsRepeat AbsRepeat;
		#End Region

		#Region " Public Properties "

		public int StdNumber {
			get { return mintStdNumber; }
			set { mintStdNumber = Value; }
		}

		public int PositionNumber {
			get { return mintPositionNumber; }
			set { mintPositionNumber = Value; }
		}

		public string StdName {
			get { return mstrStdName; }
			set { mstrStdName = Value; }
		}

		public double Concentration {
			get { return mdblConcentration; }
			set { mdblConcentration = Value; }
		}

		public double Abs {
			get { return mdblAbs; }
			set { mdblAbs = Value; }
		}

		public double nStd {
			get { return mdblnStd; }
			set { mdblnStd = Value; }
		}

		public bool Used {
			get { return mblnUsed; }
			set { mblnUsed = Value; }
		}

		#End Region

	}

}
