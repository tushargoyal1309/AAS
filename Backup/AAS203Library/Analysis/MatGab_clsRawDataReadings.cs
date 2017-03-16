namespace Analysis
{

	[Serializable()]
	public class clsRawDataReadings : CollectionBase, ICloneable
	{

		[Serializable()]
		public struct RAW_DATA
		{
			public double XTime;
			public double Absorbance;
		}

		//---Default Constructor
		public clsRawDataReadings()
		{

		}

		//---Copy Constructor
		public clsRawDataReadings(clsRawDataReadings rhs)
		{
			base.New();
			RAW_DATA item;
			foreach ( item in rhs) {
				innerlist.Add(item);
			}
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsRawDataReadings
		public object System.ICloneable.Clone()
		{
			return new clsRawDataReadings(this);
		}

		public RAW_DATA this[int index] {
			get { return (RAW_DATA)InnerList.Item(index); }
		}

		public int Add(RAW_DATA value)
		{
			return InnerList.Add(value);
		}

		public void Remove(RAW_DATA value)
		{
			if (InnerList.Contains(value)) {
				InnerList.Remove(value);
			}
		}

	}

}
