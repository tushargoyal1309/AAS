public class clsRawDataReadings : CollectionBase
{

	public struct RAW_DATA
	{
		public double Concentration;
		public double Absorbance;
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
