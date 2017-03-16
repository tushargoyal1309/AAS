
namespace Method
{
	[Serializable()]
	public class clsAbsRepeat : ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor
		public clsAbsRepeat()
		{
			BasicStat = new clsBasicStat();
			AbsRepeatData = new clsAbsRepeatDataCollection();
		}

		//---Copy Constructor
		public clsAbsRepeat(clsAbsRepeat rhs)
		{
			BasicStat = rhs.BasicStat.Clone();
			AbsRepeatData = rhs.AbsRepeatData.Clone();
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsAbsRepeat
		public object System.ICloneable.Clone()
		{
			return new clsAbsRepeat(this);
		}

		#End Region

		#Region " Public Variables "

		public clsBasicStat BasicStat;

		public clsAbsRepeatDataCollection AbsRepeatData;
		#End Region

	}

}

