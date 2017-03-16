public class clsRawDataCollection : CollectionBase
{

	public clsRawData this[int index] {
		get { return (clsRawData)InnerList.Item(index); }
	}

	public int Add(clsRawData value)
	{
		return InnerList.Add(value);
	}

}
