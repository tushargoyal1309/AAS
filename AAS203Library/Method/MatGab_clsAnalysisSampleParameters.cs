
namespace Method
{
	[Serializable()]
	public class clsAnalysisSampleParameters : ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor
		public clsAnalysisSampleParameters()
		{
			mintSampNumber = 0;
			mintSampPosNumber = -1;
			//0 to -1 by Pankaj for autosampler on 10Sep 07
			mdblnSamp = 0.0;
			mstrSampleName = "";
			mdblWeight = 0.0;
			mdblVolume = 0.0;
			mdblDilutionFactor = 0.0;
			mdblAbs = 0.0;
			mdblConc = 0.0;
			mblnUsed = false;
			AbsRepeat = new clsAbsRepeat();
		}

		//---Copy Constructor
		public clsAnalysisSampleParameters(clsAnalysisSampleParameters rhs)
		{
			mintSampNumber = rhs.SampNumber;
			mintSampPosNumber = rhs.SampPosNumber;
			mdblnSamp = rhs.nSamp;
			mstrSampleName = rhs.SampleName;
			mdblWeight = rhs.Weight;
			mdblVolume = rhs.Volume;
			mdblDilutionFactor = rhs.DilutionFactor;
			mdblAbs = rhs.Abs;
			mdblConc = rhs.Conc;
			mblnUsed = rhs.Used;
			//'AbsRepeat = rhs.AbsRepeat commented on 10.03.09
			AbsRepeat = rhs.AbsRepeat.Clone;
			//10.03.09
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsAnalysisSampleParameters
		public object System.ICloneable.Clone()
		{
			return new clsAnalysisSampleParameters(this);
		}

		#End Region

		#Region " Private Variables "

		private int mintSampNumber;
		private int mintSampPosNumber;
		private double mdblnSamp;
		private string mstrSampleName;
		private double mdblWeight;
		private double mdblVolume;
		private double mdblDilutionFactor;
		private double mdblAbs;
		private double mdblConc;

		private bool mblnUsed;

		public clsAbsRepeat AbsRepeat;
		#End Region

		#Region " Public Properties "

		public int SampNumber {
			get { return mintSampNumber; }
			set { mintSampNumber = Value; }
		}

		public int SampPosNumber {
			get { return mintSampPosNumber; }
			set { mintSampPosNumber = Value; }
		}

		public double nSamp {
			get { return mdblnSamp; }
			set { mdblnSamp = Value; }
		}

		public string SampleName {
			get { return mstrSampleName; }
			set { mstrSampleName = Value; }
		}

		public double Weight {
			get { return mdblWeight; }
			set { mdblWeight = Value; }
		}

		public double Volume {
			get { return mdblVolume; }
			set { mdblVolume = Value; }
		}

		public double DilutionFactor {
			get { return mdblDilutionFactor; }
			set { mdblDilutionFactor = Value; }
		}

		public double Abs {
			get { return mdblAbs; }
			set { mdblAbs = Value; }
		}

		public double Conc {
			get { return mdblConc; }
			set { mdblConc = Value; }
		}

		public bool Used {
			get { return mblnUsed; }
			set { mblnUsed = Value; }
		}

		#End Region

	}

}

