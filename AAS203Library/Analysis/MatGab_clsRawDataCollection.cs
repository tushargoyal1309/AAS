
namespace Analysis
{

	[Serializable()]
	public class clsRawDataCollection : CollectionBase, ICloneable, IDisposable
	{

		//---Default Constructor
		public clsRawDataCollection()
		{

		}

		//---Copy Constructor
		public clsRawDataCollection(clsRawDataCollection rhs)
		{
			base.New();
			clsRawData item;
			foreach ( item in rhs) {
				innerlist.Add(item.Clone());
			}
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsRawDataCollection
		public object System.ICloneable.Clone()
		{
			return new clsRawDataCollection(this);
		}

		public void System.IDisposable.Dispose()
		{
			innerlist.Clear();
		}

		public clsRawData this[int index] {
////----- Modified by Sachin Dokhale 
//Return CType(InnerList.Item(index), clsRawData)
			get { return InnerList.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		public int Add(clsRawData value)
		{
			return InnerList.Add(value);
		}

	}

}
